using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public class PrintService : IPrintService
    {



        public void ListofAllStudents()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----Students------");
                //var query = db.students.Select(x => x);
                //Console.WriteLine(query); // uncomment if you want to see the query
                
                var students = string.Join("\n", db.students.Select(x => x));
                Console.WriteLine(students);
                Console.ReadKey();
                Console.Clear();


            }
        }

        public void ListOfAllAssignments()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----Assignments------");
                //var query = db.assignments.Select(x => x);
                //Console.WriteLine(query); // uncomment if you want to see the query
                var assignments = string.Join("\n", db.assignments.Select(x => x));
                Console.WriteLine(assignments);
                Console.ReadKey();
                Console.Clear();



            }
        }

        public void ListOfAllTrainers()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----Trainers------");
                //var query = db.trainers.Select(x => x);
                //Console.WriteLine(query); // uncomment if you want to see the query
                var trainers = string.Join("\n", db.trainers.Select(x => x));
                Console.WriteLine(trainers);
                Console.ReadKey();
                Console.Clear();



            }
        }

        public void ListOfAllCourses()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----Courses------");
                //var query = db.courses.Select(x => x);
                //Console.WriteLine(query); // uncomment if you want to see the query
                var courses = string.Join("\n", db.courses.Select(x => x));
                Console.WriteLine(courses);
                Console.ReadKey();
                Console.Clear();



            }
        }



        public void ListOfAllStudentsPerCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----Students Per Course------");
                foreach (var course in db.courses)
                    if (course.students.Count != 0)
                    {
                        Console.WriteLine(course.Stream + " " + course.Type + "\n" + string.Join
                      ("\n", course.students.Select(y => "\t" + y.Id + " " + y.FirstName + " " + y.LastName)));
                    }
                    else
                    {
                        Console.WriteLine("*************");
                        Console.WriteLine(course.Stream + " " + course.Type + "\n has no any  students");
                        Console.WriteLine("*************");

                    }
                    Console.ReadKey();
                    Console.Clear();





            }
        }

        public void ListOfAllTrainersPerCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----Trainers Per Course------");
                foreach (var course in db.courses)
                    if (course.trainers.Count!=0)
                    {
                        Console.WriteLine(course.Stream + " " + course.Type + "\n" + string.Join
                       ("\n", course.trainers.Select(y => "\t" + y.Id + " " + y.FirstName + " " + y.LastName)));
                        Console.WriteLine("*************");
                    }
                
                    else
                    {
                        Console.WriteLine("*************");
                        Console.WriteLine(course.Stream + " " + course.Type + "\n has no any  trainers");
                        Console.WriteLine("*************");


                    }
                    Console.ReadKey();
                    Console.Clear();


            }
        }

        public void ListOfAllAssignmentsPerCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {
                    
                    

                        Console.Clear();
                        Console.WriteLine("----Assignments Per Course------");
                        foreach (var course in db.courses)
                    if (course.assignments.Count!=0)
                    {
                        Console.WriteLine("*************");
                        Console.WriteLine(course.Stream + " " + course.Type + "\n" + string.Join
                           ("\n", course.assignments.Select(y => "\t" + y.Id + " " + y.Title + " " + y.Description)));
                        Console.WriteLine("*************");

                    }
                    else
                    {
                        Console.WriteLine("*************");
                        Console.WriteLine(course.Stream + " " + course.Type + "\n has no any assignments");
                        Console.WriteLine("*************");


                    }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ListOfStudentsPerCoursePerAssignment()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----List of Student Per Course per Assignment------");
                foreach (var student in db.students.Where(x => x.courses.Count() != 0))
                {

                    Console.WriteLine("--------------------------");
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                    Console.WriteLine("--------------------------");



                    foreach (var course in student.courses)
                    {

                        Console.WriteLine("\n" + course.Stream + " " + course.Type);
                        foreach (var assignment in course.assignments)
                        {
                            Console.WriteLine("\n\t" + string.Join("\n\t", assignment));
                        }

                    }

                }
                Console.WriteLine("***************");
                Console.WriteLine(string.Join("\n", db.students.
                  Where(x => x.courses.Count() == 0).Select
                  (x => x.FirstName + " " + x.LastName + " has not been added to a Course")));
                Console.ReadKey();
                Console.Clear();
            }
        }


        public void ListOfAllStudentsThatBelongToMoreThanOneCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine("----List of students that belong to more than one Courses  ------");
                //var query = db.students.
                //    Where(x => x.courses.Count() > 1).Select(x => x.FirstName + " " + x.LastName);
                //Console.WriteLine(query); // uncomment to see query
                var listofStudInMoreThOne = string.Join("\n", db.students.
                    Where(x => x.courses.Count() > 1).Select(x => x.FirstName + " " + x.LastName));
                Console.WriteLine(listofStudInMoreThOne);
                Console.ReadKey();
                Console.Clear();



            }
        }

        public void PrintData()
        {
            bool showQuestion = ValidationInputs.Question("Would you like to print all courses? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllCourses();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all students? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListofAllStudents();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all trainers? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllTrainers();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all assignments? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllAssignments();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all students per course? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllStudentsPerCourse();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all trainers per course? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllTrainersPerCourse();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all assignments per course? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllAssignmentsPerCourse();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all assignments per student? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfStudentsPerCoursePerAssignment();
            }

            showQuestion = ValidationInputs.Question("Would you like to print all students with more than one courses? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                ListOfAllStudentsThatBelongToMoreThanOneCourse();
            }


        }





    }
}
