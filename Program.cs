using System.Diagnostics;

namespace ExamSystem
{
    // بسم الله الرحمن الرحيم 
    // أنا في الواقع اضفت حاجات تانية فوق اللي مطلوب ف التاسك
    // بارك الله فيكم وجزاكم الله خيرا

    /* 
     برده فيه حاجة انا مش مستخدم النيم سبيسس 
    system or system.collections.generic or system.Threading
    عشان بس الفيرجن من الدوت نت بتاعتي 9.0 ف مثلا لو الفيرجن للباشمهندس بتقوله ان فيه ايرورز 
    ف ممكن يدخلها عنده ويضيف النيم سبيسس 
     */

    public static class AnimatedConsole
    {
        // this animation will be for Console.Write() 
        public static void WriteAnimated(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        // this animation will be for Console.WriteLine() 
        public static void WriteLineAnimated(string text, int delay = 30)
        {
            WriteAnimated(text, delay);
            Console.WriteLine();
        }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }
    }

    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Question(string header, string body, int mark, List<Answer> answers, Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answers;
            CorrectAnswer = correctAnswer;
        }

        public abstract void DisplayQuestion();
    }

    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, Answer correctAnswer)
            : base(header, body, mark, new List<Answer> { new Answer(1, "True"), new Answer(2, "False") }, correctAnswer)
        { }

        public override void DisplayQuestion()
        {
            AnimatedConsole.WriteLineAnimated($"\n{Header}: {Body} (Mark: {Mark})", 30);
            foreach (var ans in AnswerList)
            {
                AnimatedConsole.WriteLineAnimated($"{ans.AnswerId}. {ans.AnswerText}", 50);
            }
        }
    }

    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, List<Answer> answers, Answer correctAnswer)
            : base(header, body, mark, answers, correctAnswer)
        { }

        public override void DisplayQuestion()
        {
            AnimatedConsole.WriteLineAnimated($"\n{Header}: {Body} (Mark: {Mark})", 50);
            foreach (var ans in AnswerList)
            {
                AnimatedConsole.WriteLineAnimated($"{ans.AnswerId}. {ans.AnswerText}", 30);
            }
        }
    }

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

        public abstract void ShowExam();

        public virtual void TakeExam()
        {
            AnimatedConsole.WriteLineAnimated($"\nExam is starting! You have {Duration} minute(s) to complete it", 50);
            AnimatedConsole.WriteLineAnimated("Please answer each question as it appears", 25);

            int score = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Dictionary<string, int> studentResponses = new Dictionary<string, int>();

            foreach (var question in Questions)
            {
                if (stopwatch.Elapsed.TotalMinutes >= Duration)
                {
                    AnimatedConsole.WriteLineAnimated("\nTime's up!", 25);
                    break;
                }

                question.DisplayQuestion();
                AnimatedConsole.WriteAnimated("Your answer (enter the answer number): ", 25);
                string input = Console.ReadLine();
                int selectedAnswer;
                if (!int.TryParse(input, out selectedAnswer))
                {
                    AnimatedConsole.WriteLineAnimated("Invalid input! This question will be marked as incorrect", 30);
                    continue;
                }
                studentResponses[question.Header] = selectedAnswer;

                if (selectedAnswer == question.CorrectAnswer.AnswerId)
                {
                    score += question.Mark;
                }
            }

            stopwatch.Stop();
            AnimatedConsole.WriteLineAnimated($"\nExam submitted! Your total score is: {score}\n", 30);
            AnimatedConsole.WriteLineAnimated("Review of your answers:", 20);
            foreach (var question in Questions)
            {
                if (studentResponses.ContainsKey(question.Header))
                {
                    int studentAnswer = studentResponses[question.Header];
                    string outcome = studentAnswer == question.CorrectAnswer.AnswerId
                        ? "Correct"
                        : $"Incorrect (Correct answer: {question.CorrectAnswer.AnswerText})";
                    AnimatedConsole.WriteLineAnimated($"{question.Header} - Your Answer: {studentAnswer} => {outcome}", 50);
                }
                else
                {
                    AnimatedConsole.WriteLineAnimated($"{question.Header} - No answer provided", 25);
                }
            }
        }
    }

    public class FinalExam : Exam
    {
        public FinalExam(int duration, int numQuestions) : base(duration, numQuestions) { }

        public override void ShowExam()
        {
            AnimatedConsole.WriteLineAnimated("\nFinal Exam: (Questions will appear during the exam)", 30);
        }
    }

    public class PracticalExam : Exam
    {
        public PracticalExam(int duration, int numQuestions) : base(duration, numQuestions) { }

        public override void ShowExam()
        {
            AnimatedConsole.WriteLineAnimated("\nPractical Exam: (Questions will appear during the exam)", 30);
        }

        public override void TakeExam()
        {
            AnimatedConsole.WriteLineAnimated($"\nExam is starting! You have {Duration} minute(s) to complete it");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var question in Questions)
            {
                if (stopwatch.Elapsed.TotalMinutes >= Duration)
                {
                    AnimatedConsole.WriteLineAnimated("\nTime's up!", 25);
                    break;
                }

                question.DisplayQuestion();
                AnimatedConsole.WriteAnimated("Your answer (enter the answer number): ", 25);
                string input = Console.ReadLine();
                int selectedAnswer;
                if (!int.TryParse(input, out selectedAnswer))
                {
                    AnimatedConsole.WriteLineAnimated("Invalid input! This question will be marked as incorrect", 20);
                    continue;
                }

                if (selectedAnswer == question.CorrectAnswer.AnswerId)
                {
                    AnimatedConsole.WriteLineAnimated("Correct!", 20);
                }
                else
                {
                    AnimatedConsole.WriteLineAnimated($"Incorrect. The correct answer is: {question.CorrectAnswer.AnswerText}", 25);
                }
            }

            stopwatch.Stop();
            AnimatedConsole.WriteLineAnimated("\nExam completed", 50);
        }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
        }

        public void DisplayExamMetadata()
        {
            AnimatedConsole.WriteLineAnimated($"\nSubject: {SubjectName} (ID: {SubjectId})", 50);
            AnimatedConsole.WriteLineAnimated($"Exam Duration: {Exam.Duration} minute(s), Number of Questions: {Exam.NumQuestions}", 50);
        }
    }

    public class CloneableSubject : Subject, ICloneable, IComparable<CloneableSubject>
    {
        public CloneableSubject(int subjectId, string subjectName) : base(subjectId, subjectName) { }

        public object Clone()
        {
            return new CloneableSubject(SubjectId, SubjectName);
        }

        public int CompareTo(CloneableSubject other)
        {
            return this.SubjectId.CompareTo(other.SubjectId);
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Name: {SubjectName}";
        }
    }

    class Program
    {
        static void Main()
        {
            Answer ans1 = new Answer(1, "True");
            Answer ans2 = new Answer(2, "False");

            Answer ans3 = new Answer(1, "Python");
            Answer ans4 = new Answer(2, "Java");
            Answer ans5 = new Answer(3, "C#");

            Answer ans6 = new Answer(1, "class");
            Answer ans7 = new Answer(2, "public");
            Answer ans8 = new Answer(3, "void");

            TrueFalseQuestion q1 = new TrueFalseQuestion("Q1", "C# is an OOP language?", 5, ans1);
            MCQQuestion q2 = new MCQQuestion(
                "Q2",
                "Which programming language is a interpreted language?",
                10,
                new List<Answer> { ans3, ans4, ans5 },
                ans3
            );

            MCQQuestion q3 = new MCQQuestion(
                "Q3",
                "Which keyword is used to define a class in C#?",
                8,
                new List<Answer> { ans6, ans7, ans8 },
                ans6
            );

            FinalExam finalExam = new FinalExam(duration: 1, numQuestions: 2);
            finalExam.Questions.Add(q1);
            finalExam.Questions.Add(q2); 

            PracticalExam practicalExam = new PracticalExam(duration: 1, numQuestions: 2);
            practicalExam.Questions.Add(q3); 
            practicalExam.Questions.Add(new TrueFalseQuestion("Q4", "C# supports multiple inheritance?", 5, ans2));

            Subject subject1 = new Subject(101, "Computer Science");
            subject1.CreateExam(finalExam);

            Subject subject2 = new Subject(102, "Software Engineering");
            subject2.CreateExam(practicalExam);

            subject1.DisplayExamMetadata();
            AnimatedConsole.WriteLineAnimated("\nStarting Final Exam for Computer Science:", 50);
            subject1.Exam.TakeExam();

            subject2.DisplayExamMetadata();
            AnimatedConsole.WriteLineAnimated("\nStarting Practical Exam for Software Engineering:", 50);
            subject2.Exam.TakeExam();

            AnimatedConsole.WriteLineAnimated("\nPress any key to exit", 50);
            Console.ReadKey();
        }

    }
}