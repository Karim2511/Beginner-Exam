using OOP_Exam.Utilities;

namespace OOP_Exam.Exams
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int duration, int numQuestions) : base(duration, numQuestions) { }
        public override void TakeExam(bool showAnswersAfterEachQuestion = false)
        {
            base.TakeExam(true);
        }
    }
}