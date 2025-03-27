using OOP_Exam.Models;

namespace OOP_Exam.Questions
{
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
}