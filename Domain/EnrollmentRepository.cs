using System;
using System.Collections.Generic;

namespace Online_Course_Enrollment_System_Properties.Domain
{
    public class EnrollmentRepository
    {
        private readonly Dictionary<string, Course> _courses = new();

        // Зберігає курс. Повторне збереження курсу з тим самим Id замінює попередній запис.
        public void Save(Course course)
        {
            if (course is null)
                throw new ArgumentNullException(nameof(course));

            _courses[course.Id] = course;
        }

        // Кидає KeyNotFoundException, якщо курсу з таким Id немає.
        public Course Get(string courseId)
        {
            if (!_courses.TryGetValue(courseId, out var course))
                throw new KeyNotFoundException("Course not found");

            return course;
        }

        public bool Exists(string courseId) => _courses.ContainsKey(courseId);

        public IReadOnlyCollection<Course> All() => _courses.Values;
    }
}
