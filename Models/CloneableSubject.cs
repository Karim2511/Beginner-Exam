namespace OOP_Exam.Models
{
    public class CloneableSubject : Subject, ICloneable, IComparable<CloneableSubject>
    {
        public CloneableSubject(int subjectId, string subjectName) : base(subjectId, subjectName) { }

        public object Clone()
        {
            return new CloneableSubject(SubjectId, SubjectName);
        }

        public int CompareTo(CloneableSubject other)
        {
            return SubjectId.CompareTo(other.SubjectId);
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Name: {SubjectName}";
        }
    }
}