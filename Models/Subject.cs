using OOP_Exam.Exams;
using OOP_Exam.Utilities;

namespace OOP_Exam.Models
{
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

        public void DisplayExamInformation()
        {
            AnimatedConsole.WriteLineAnimated($"\nSubject: {SubjectName} (ID: {SubjectId})", 30);
            AnimatedConsole.WriteLineAnimated($"Exam Duration: {Exam.Duration} minute(s), Number of Questions: {Exam.NumQuestions}", 30);
        }
    }
}