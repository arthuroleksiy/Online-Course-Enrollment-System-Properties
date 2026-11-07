using System;

namespace Online_Course_Enrollment_System_Properties.Domain
{
    public class Student
    {
        public string Id { get; }

        public Student(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Invalid student id");

            Id = id;
        }

        // Два об'єкти Student з однаковим Id вважаються одним і тим самим студентом.
        public override bool Equals(object? obj) => obj is Student other && other.Id == Id;

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"Student({Id})";
    }
}
