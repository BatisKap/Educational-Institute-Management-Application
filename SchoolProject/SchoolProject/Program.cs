using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SchoolProject.Entities;
using SchoolProject.Services;


namespace SchoolProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintService printData = new PrintService();
            printData.PrintData();

            AddDataService addData = new AddDataService();

            addData.InsertData();


        }


       


    }
} 
    
