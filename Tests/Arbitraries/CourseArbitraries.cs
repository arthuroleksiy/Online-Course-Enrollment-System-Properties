using FsCheck;
using FsCheck.Fluent;
using Online_Course_Enrollment_System_Properties.Domain;

namespace Online_Course_Enrollment_System_Properties.Tests.Arbitraries
{
    // Зразки з проєкту лекції: FuelTankGen (залежні значення), VehicleGen (генератор з генератора).
    public static class CourseArbitraries
    {
        // Student: Id — непорожній рядок, напр. Gen.Choose(1, 20).Select(n => $"S{n}").
        // Невеликий діапазон робить збіги Id частими — це корисно для правила
        // «один студент не записується двічі».
        public static Arbitrary<Student> Student()
        {
            throw new NotImplementedException();
        }

        // Course: Id — непорожній рядок, Capacity >= 1. Включіть граничний випадок Capacity = 1.
        public static Arbitrary<Course> Course()
        {
            throw new NotImplementedException();
        }

        // Масив студентів (Student[]) окремо писати не потрібно:
        // FsCheck сам побудує його з генератора Student(), як Vehicle[] у тестах автопарку (FleetPropertyTests).
    }
}
