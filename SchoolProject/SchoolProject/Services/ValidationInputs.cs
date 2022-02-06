using SchoolProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolProject.Services
{
    class ValidationInputs
    {

        public static string AddAnother(string variable)
        {
            Console.WriteLine($"Would you like to create another {variable}?. Y/N");
            string input = Console.ReadLine();
            while (input.ToUpper().Trim() != "Y" && input.ToUpper().Trim() != "N")
            {
                Console.WriteLine("Incorrect input. Try again with Y or N.");
                input = Console.ReadLine();


            }

            return input;
        }

        public static string GetName(string typeOfName)
        {
            Regex reg = new Regex(@"^+[A-Z]|[a-z]{3,15}\z");
            Console.WriteLine($"Enter the {typeOfName} name");
            string firstName = Console.ReadLine();
            while (!reg.IsMatch(firstName))
            {
                Console.WriteLine($"Enter a valid {typeOfName}name between 3 and 15 charachters. Do not include numbers");
                firstName = Console.ReadLine();
            }
            return firstName;
        }
        public static int GetTuitionFees()
        {
            int tuitionFees = 0;
            Console.WriteLine("Give the Tuition Fees of the Student");
            while (!int.TryParse(Console.ReadLine(), out tuitionFees))
            {
                Console.WriteLine("You have give wrong tuition fees please try again");

            }

            return tuitionFees;
        }
        public static DateTime GetDate(string typeOfDate)
        {

            DateTime date;

            Console.WriteLine($"Give the {typeOfDate}  in this format--> month/day/Year ");
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("You have given wrong Date please try again");
            }
            return date;

        }
        public static string GetSubject()
        {
            Console.WriteLine("Give the Trainers subject");
            return Console.ReadLine();

        }
        public static string GetTitle(string type)
        {
            Console.WriteLine($"Give the {type}'s title ");
            return Console.ReadLine();
        }
        public static int GetMark(string type)
        {
            Regex reg = new Regex(@"^+[0-9]{1,3}\z");
            Console.WriteLine($"Enter the Assignment's {type} mark");
            string oralMark = Console.ReadLine();
            while (!reg.IsMatch(oralMark))
            {
                Console.WriteLine($"!The {type} Mark cannot include letters and cannot be more than 3 digits!");
                oralMark = Console.ReadLine();
            }
            return Convert.ToInt32(oralMark);

        }
        public static string GetDescription()
        {
            Console.WriteLine("Give the Description of the assignment");
            return Console.ReadLine();
        }



        public static string GetCourseTitle()
        {
            Console.WriteLine("Please enter a valid Course Title. Valid Titles start with 'CB(int number)'  ");
            string courseTitle = Console.ReadLine();

            while (!(ValidationInputs.IsValidCourseTitle(courseTitle)))
            {
                Console.WriteLine("Invalid input. Please enter a valid Course Title. Valid Titles start with 'CB(int number)'");
                courseTitle = Console.ReadLine();
            }

            courseTitle = courseTitle.ToUpper();


            return courseTitle;
        }

       
        public static string GetCourseStream()
        {
            Console.WriteLine("Please enter a valid Course Stream. Valid inputs: JAVA, C#, PYTHON, JAVASCRIPT");
            string courseStream = Console.ReadLine();

            while (!(IsValidCourseStream(courseStream)))
            {
                Console.WriteLine("Invalid input. Please enter a valid Course Stream.Valid inputs: JAVA, C#, PYTHON, JAVASCRIPT");
                courseStream = Console.ReadLine();
            }


            return (courseStream);
        }

       
        public static string GetCourseType()
        {
            Console.WriteLine("Please enter a valid Course Type. Valid inputs: FULLTIME,PARTTIME");
            string courseType = Console.ReadLine();

            while (!IsValidCourseType(courseType))
            {
                Console.WriteLine("Invalid input. Please enter a valid Course Type. Valid inputs: FULLTIME,PARTTIME");
                courseType = Console.ReadLine();
            }


            return (courseType);
        }

        public static bool IsValidCourseTitle(string courseTitle)
        {
            if (!((courseTitle.Length == 3) || (courseTitle.Length == 4)))
            {
                return false;
            }

            if (!((courseTitle.Substring(0, 2) == "cb") || (courseTitle.Substring(0, 2) == "CB")))
            {
                return false;
            }

            string integerPartOfTitle = courseTitle.Substring(2);

            foreach (char character in integerPartOfTitle)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return true;
        }

       
        public static bool IsValidCourseStream(string courseStream)
        {
            string CourseStreamUpperCase = courseStream.ToUpper().Trim();
            string[] validInputsArray = new string[4] { "JAVA", "C#", "PYTHON", "JAVASCRIPT" };

            return Array.Exists(validInputsArray, element => element == CourseStreamUpperCase);
        }

        public static bool IsValidCourseType(string courseType)
        {
            string CourseTypeUpperCase = courseType.ToUpper();
            string[] validInputsArray = new string[2] { "FULLTIME", "PARTTIME" };

            return Array.Exists(validInputsArray, element => element == CourseTypeUpperCase);
        }


        public static bool Question(string question)
        {
            bool loopControlVariable = true;
            Console.WriteLine($"{question}");
            string userResponse = (Console.ReadLine()).ToUpper().Trim();
            while (userResponse != "N" && userResponse != "Y")
            {
                Console.WriteLine($"Invalid input. {question}");
                userResponse = (Console.ReadLine()).ToUpper().Trim();
            }
            loopControlVariable = (userResponse == "N") ? false : true;

            return loopControlVariable; // returns false or True
        }





    }
}
