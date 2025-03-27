using OOP_Exam.Questions;
using OOP_Exam.Utilities;
using System.Diagnostics;
using System.Threading;

namespace OOP_Exam.Exams
{
    public abstract class Exam
    {
        public int Duration { get; set; }
        public int NumQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int duration, int numQuestions)
        {
            Duration = duration;
            NumQuestions = numQuestions;
            Questions = new List<Question>();
        }
        public virtual void TakeExam(bool showAnswersAfterEachQuestion = false)
        {
            AnimatedConsole.WriteLineAnimated($"\nExam is starting! You have {Duration} minutes to complete it", 30);
            AnimatedConsole.WriteLineAnimated("Please answer each question as it appears", 25);

            int score = 0;
            Dictionary<string, int> SAnswers = new Dictionary<string, int>();

            CancellationTokenSource cts = new CancellationTokenSource();
            Task examTimer = Task.Delay(Duration * 60 * 1000, cts.Token);

            foreach (var question in Questions)
            {
                AnimatedConsole.WriteLineAnimated("\n" + new string('=', 50), 20);

                question.DisplayQuestion();
                AnimatedConsole.WriteAnimated("Your answer (enter the answer number): ", 25);

                Task<string> inputTask = Task.Run(() => Console.ReadLine(), cts.Token);

                Task completedTask = Task.WhenAny(inputTask, examTimer).Result;

                if (completedTask == examTimer)
                {
                    AnimatedConsole.WriteLineAnimated("\ntime's up, The exam is ove", 30);
                    break;
                }

                string input = inputTask.Result;
                if (!int.TryParse(input, out int selectedAnswer))
                {
                    AnimatedConsole.WriteLineAnimated("Invalid input! This question will be marked as incorrect", 30);
                    continue;
                }

                SAnswers[question.Header] = selectedAnswer;

                if (selectedAnswer == question.CorrectAnswer.AnswerId)
                {
                    score += question.Mark;
                }

                // PracticalExam
                if (showAnswersAfterEachQuestion)
                {
                    string outcome = selectedAnswer == question.CorrectAnswer.AnswerId
                        ? "Correct!"
                        : $"Incorrect! The correct answer is: {question.CorrectAnswer.AnswerText}";
                    AnimatedConsole.WriteLineAnimated(outcome, 40);
                }
            }

            cts.Cancel();
            AnimatedConsole.WriteLineAnimated($"\nExam submitted! Your total score is: {score}\n", 30);

            // FinalExam
            if (!showAnswersAfterEachQuestion)
            {
                AnimatedConsole.WriteLineAnimated("\nReview of your answers:", 20);
                foreach (var question in Questions)
                {
                    if (SAnswers.ContainsKey(question.Header))
                    {
                        int studentAnswer = SAnswers[question.Header];
                        string outcome = studentAnswer == question.CorrectAnswer.AnswerId
                            ? "Correct"
                            : $"Incorrect (Correct answer: {question.CorrectAnswer.AnswerText})";
                        AnimatedConsole.WriteLineAnimated($"{question.Header} - Your Answer: {studentAnswer} => {outcome}", 30);
                    }
                    else
                    {
                        AnimatedConsole.WriteLineAnimated($"{question.Header} - No answer provided", 25);
                    }
                }
            }
        }
    }
}
