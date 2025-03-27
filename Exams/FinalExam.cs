using OOP_Exam.Utilities;

namespace OOP_Exam.Exams
{
    public class FinalExam : Exam
    {
        public FinalExam(int duration, int numQuestions) : base(duration, numQuestions) { }

        public override void TakeExam(bool showAnswersAfterEachQuestion = false)
        {
            base.TakeExam(false);
        }
    }
}