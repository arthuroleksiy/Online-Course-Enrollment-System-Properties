using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Course_Enrollment_System_Properties.Domain
{
    public class Course
    {
        public string Id { get; }
        public int Capacity { get; }

        private readonly List<Student> _students = new();

        public Course(string id, int capacity)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Invalid course id");

            if (capacity <= 0)
                throw new ArgumentException("Capacity must be positive");

            Id = id;
            Capacity = capacity;
        }

        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

        public int FreeSeats => Capacity - _students.Count;

        public bool IsFull => _students.Count >= Capacity;

        // Записує студента на курс.
        // Повертає false (і нічого не змінює), якщо студент уже записаний або курс заповнений.
        public bool Enroll(Student student)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student));

            if (_students.Contains(student))
                return false;

            if (IsFull)
                return false;

            _students.Add(student);
            return true;
        }

        // Скасовує запис студента.
        // Кидає InvalidOperationException, якщо такого студента на курсі немає.
        public void Unenroll(string studentId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);

            if (student is null)
                throw new InvalidOperationException("Student is not enrolled in this course");

            _students.Remove(student);
        }

        public bool IsEnrolled(string studentId) => _students.Any(s => s.Id == studentId);

        public override string ToString() => $"Course({Id}, {_students.Count}/{Capacity})";
    }
}
