namespace SchoolProject.Services
{
    public interface IPrintService
    {
        void ListOfAllAssignments();
        void ListOfAllAssignmentsPerCourse();
        void ListOfAllCourses();
        void ListofAllStudents();
        void ListOfAllStudentsPerCourse();
        void ListOfAllStudentsThatBelongToMoreThanOneCourse();
        void ListOfAllTrainers();
        void ListOfAllTrainersPerCourse();
        void ListOfStudentsPerCoursePerAssignment();
        void PrintData();
    }
}