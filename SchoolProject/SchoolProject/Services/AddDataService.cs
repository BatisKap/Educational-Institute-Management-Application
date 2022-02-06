using SchoolProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    public class AddDataService : IAddDataService
    {
        public void InsertStudents()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine($"Create the form of Students" + Environment.NewLine);
                Console.WriteLine($"Do you want to add Student(s)?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {
                        input = ValidationInputs.AddAnother("Student");

                        if (input.ToUpper().Trim() == "Y")
                        {
                            Student student = new Student()
                            {
                                FirstName = ValidationInputs.GetName("First"),
                                LastName = ValidationInputs.GetName("Last"),
                                DateOfBirth = ValidationInputs.GetDate("Students Birthday"),
                                TuitionFees = ValidationInputs.GetTuitionFees()


                            };

                            db.students.Add(student);
                            db.SaveChanges();

                        }
                        else
                        {
                            break;
                        }

                    }
                }

            }
        }
        public void InsertTrainers()
        {
            using (SchoolContext db = new SchoolContext())
            {

                Console.Clear();
                Console.WriteLine($"Create the form of Trainers" + Environment.NewLine);
                Console.WriteLine($"Do you want to add Trainer(s)?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {
                        input = ValidationInputs.AddAnother("Trainer");

                        if (input.ToUpper().Trim() == "Y")
                        {
                            Trainer trainer = new Trainer()
                            {
                                FirstName = ValidationInputs.GetName("first name"),
                                LastName = ValidationInputs.GetName("last name"),
                                Subject = ValidationInputs.GetSubject()

                            };


                            db.trainers.Add(trainer);
                            db.SaveChanges();
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
        }

        public void InsertAssignments()
        {
            using (SchoolContext db = new SchoolContext())
            {

                Console.Clear();
                Console.WriteLine($"Create the list of Assignments" + Environment.NewLine);
                Console.WriteLine($"Do you want to add Assignment(s)?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {

                        input = ValidationInputs.AddAnother("Assignment");


                        if (input.ToUpper().Trim() == "Y")
                        {



                            Assignment assignment = new Assignment()
                            {
                                Title = ValidationInputs.GetTitle("Assignment"),
                                Description = ValidationInputs.GetDescription(),
                                SubDateTime = ValidationInputs.GetDate("Due Date of the Assignment"),
                                OralMark = ValidationInputs.GetMark("Oral Mark"),
                                TotalMark = ValidationInputs.GetMark("Total Mark")

                            };


                            db.assignments.Add(assignment);
                            db.SaveChanges();

                        }
                        else
                        {
                            break;
                        }
                    }





                }

            }
        }

        public void InsertCourses()
        {
            using (SchoolContext db = new SchoolContext())
            {

                Console.Clear();
                Console.WriteLine($"Create the form of Courses" + Environment.NewLine);
                Console.WriteLine($"Do you want to add Course(s)?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {
                        input = ValidationInputs.AddAnother("Course");

                        if (input.ToUpper().Trim() == "Y")
                        {
                            Course course = new Course()
                            {
                                Title = ValidationInputs.GetCourseTitle(),
                                Stream = ValidationInputs.GetCourseStream(),
                                Type = ValidationInputs.GetCourseType(),
                                Start_Date = ValidationInputs.GetDate("Course Start Date"),
                                End_Date = ValidationInputs.GetDate("Course End Date")


                            };


                            db.courses.Add(course);
                            db.SaveChanges();
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
        }

        public void InsertStudentsPerCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine($"Add Students per course" + Environment.NewLine);
                Console.WriteLine($"Do you want to add Student(s) per Course?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {
                        input = ValidationInputs.AddAnother("StudentPerCourse");

                        if (input.ToUpper().Trim() == "Y")
                        {
                            Student student = new Student()
                            {
                                FirstName = ValidationInputs.GetName("First"),
                                LastName = ValidationInputs.GetName("Last"),
                                DateOfBirth = ValidationInputs.GetDate("Students Birthday"),
                                TuitionFees = ValidationInputs.GetTuitionFees()


                            };

                            var courses = string.Join("\n", db.courses.Select(x => x));
                            Console.WriteLine(courses);
                            Console.WriteLine();
                            Console.WriteLine("Please add one  id of the above courses ");


                            Regex reg = new Regex(@"^\d+$");

                            var inputcourseId = Console.ReadLine();
                            while (!reg.IsMatch(inputcourseId))
                            {
                                Console.WriteLine("The id must include only digits");
                                inputcourseId = Console.ReadLine();
                            }

                            db.students.Add(student);
                            student.courses.Add(db.courses.AsEnumerable().Single(x => x.Id == int.Parse(inputcourseId)));
                            db.SaveChanges();

                        }
                        else
                        {
                            break;
                        }

                    }
                }

            }
        }

        public void InsertTrainersPerCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {
                Console.Clear();
                Console.WriteLine($"Add Trainers per course" + Environment.NewLine);
                Console.WriteLine($"Do you want to add Trainer(s) per Course?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {
                        input = ValidationInputs.AddAnother("TrainerPerCourse");

                        if (input.ToUpper().Trim() == "Y")
                        {
                            Trainer trainer = new Trainer()
                            {
                                FirstName = ValidationInputs.GetName("first name"),
                                LastName = ValidationInputs.GetName("last name"),
                                Subject = ValidationInputs.GetSubject()

                            };

                            var courses = string.Join("\n", db.courses.Select(x => x));
                            Console.WriteLine(courses);
                            Console.WriteLine();
                            Console.WriteLine("Please add one  id of the above courses ");


                            Regex reg = new Regex(@"^\d+$");

                            var inputcourseId = Console.ReadLine();
                            while (!reg.IsMatch(inputcourseId))
                            {
                                Console.WriteLine("The id must include only digits");
                                inputcourseId = Console.ReadLine();
                            }

                            db.trainers.Add(trainer);
                            trainer.courses.Add(db.courses.AsEnumerable().Single(x => x.Id == int.Parse(inputcourseId)));
                            db.SaveChanges();

                        }
                        else
                        {
                            break;
                        }

                    }
                }

            }
        }

        public void InsertAssignmentsPerStudentPerCourse()
        {
            using (SchoolContext db = new SchoolContext())
            {

                Console.Clear();
                Console.WriteLine($"Add data to the list of Assignments per Student per Course" + Environment.NewLine);
                Console.WriteLine($"Do you want to add data?.Answer Y or N");
                var input = Console.ReadLine();
                while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
                {
                    Console.WriteLine("Incorrect input. Try again with Y or N.");
                    input = Console.ReadLine();
                }
                if (input.ToUpper().Trim() == "Y")
                {

                    while (true)
                    {

                        input = ValidationInputs.AddAnother("input of an  assignment and add it into a course");


                        if (input.ToUpper().Trim() == "Y")
                        {



                            Assignment assignment = new Assignment()
                            {
                                Title = ValidationInputs.GetTitle("Assignment"),
                                Description = ValidationInputs.GetDescription(),
                                SubDateTime = ValidationInputs.GetDate("Due Date of the Assignment"),
                                OralMark = ValidationInputs.GetMark("Oral Mark"),
                                TotalMark = ValidationInputs.GetMark("Total Mark")

                            };


                            var courses = string.Join("\n", db.courses.Select(x => x));
                            Console.WriteLine(courses);
                            Console.WriteLine();
                            Console.WriteLine("Please add one  id of the above courses ");


                            Regex reg = new Regex(@"^\d+$");

                            var inputcourseId = Console.ReadLine();
                            while (!reg.IsMatch(inputcourseId))
                            {
                                Console.WriteLine("The id must include only digits");
                                inputcourseId = Console.ReadLine();
                            }

                            db.assignments.Add(assignment);
                            assignment.courses.Add(db.courses.AsEnumerable().Single(x => x.Id == int.Parse(inputcourseId)));
                            db.SaveChanges();


                        }
                        else
                        {
                            break;
                        }
                    }





                }

            }
        }


        public void InsertData()
        {

            bool showQuestion = ValidationInputs.Question("Would you like to insert courses? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertCourses();

                ;
            }



            showQuestion = ValidationInputs.Question("Would you like to insert students? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertStudents();
            }

            showQuestion = ValidationInputs.Question("Would you like to insert trainers? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertTrainers();
            }

            showQuestion = ValidationInputs.Question("Would you like to insert Assignments? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertAssignments();
            }

            showQuestion = ValidationInputs.Question("Would you like to insert students per course? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertStudentsPerCourse();
            }

            showQuestion = ValidationInputs.Question("Would you like to insert trainers per course? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertTrainersPerCourse();
            }



            showQuestion = ValidationInputs.Question("Would you like to insert assignments per student per course? Please press 'Y' for yes or 'N' for no.");
            if (showQuestion)
            {
                Console.Clear();
                InsertAssignmentsPerStudentPerCourse();
            }




        }


    }
}
