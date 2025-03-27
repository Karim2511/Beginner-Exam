using OOP_Exam.Models;
using OOP_Exam.Utilities;

namespace OOP_Exam.Questions
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, List<Answer> answers, Answer correctAnswer)
            : base(header, body, mark, answers, correctAnswer)
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