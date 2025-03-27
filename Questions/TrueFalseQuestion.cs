using OOP_Exam.Models;
using OOP_Exam.Utilities;

namespace OOP_Exam.Questions
{
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
                AnimatedConsole.WriteLineAnimated($"{ans.AnswerId}. {ans.AnswerText}", 30);
            }
        }
    }
}