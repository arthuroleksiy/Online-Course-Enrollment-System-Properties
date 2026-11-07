using System;
using System.Linq;

namespace Online_Course_Enrollment_System_Properties.Domain
{
    public class EnrollmentService
    {
        private readonly EnrollmentRepository _repo;

        public EnrollmentService(EnrollmentRepository repo)
        {
            _repo = repo;
        }

        public Course CreateCourse(string courseId, int capacity)
        {
            if (_repo.Exists(courseId))
                throw new InvalidOperationException("Course already exists");

            var course = new Course(courseId, capacity);
            _repo.Save(course);
            return course;
        }

        // Завантажує курс, записує студента, зберігає курс.
        public bool Enroll(string courseId, Student student)
        {
            var course = _repo.Get(courseId);
            var result = course.Enroll(student);
            _repo.Save(course);
            return result;
        }

        public void Unenroll(string courseId, string studentId)
        {
            var course = _repo.Get(courseId);
            course.Unenroll(studentId);
            _repo.Save(course);
        }

        // Кількість курсів, на які записаний студент.
        public int CoursesOf(string studentId)
            => _repo.All().Count(c => c.IsEnrolled(studentId));

        // Загальна кількість записів по всіх курсах.
        public int TotalEnrollments()
            => _repo.All().Sum(c => c.Students.Count);
    }
}
