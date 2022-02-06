namespace SchoolProject.Services
{
    public interface IAddDataService
    {
        void InsertAssignments();
        void InsertAssignmentsPerStudentPerCourse();
        void InsertCourses();
        void InsertData();
        void InsertStudents();
        void InsertStudentsPerCourse();
        void InsertTrainers();
        void InsertTrainersPerCourse();
    }
}