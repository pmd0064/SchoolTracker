using System;
using System.Collections.Generic;

namespace SchoolTracker
{
    enum School
    {

        Hogwarts,
        Harvard,
        Yael

    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Logger.Log("Tracker started", priority:0);
            PayRoll payroll = new PayRoll();
            payroll.PayAll();
            bool adding = true;

            while (adding)
            {
                try
                {
                    Logger.Log("Adding new student");

                    Student newStudent = new Student();

                    newStudent.Name = Util.Console.Ask("Name: ");

                    newStudent.Grade = Util.Console.AskInt("Grade: ");

                    newStudent.School = (School) Util.Console.AskInt("School ID: \n(0:Hogwarts High, 1:Harvard High, 2:Yael High)\n");

                    newStudent.Birthday = Util.Console.Ask("Birthday: ");

                    newStudent.Address = Util.Console.Ask("Address: ");

                    newStudent.Phone = Util.Console.Ask("Phone Number: ");

                    students.Add(newStudent);
                    Student.Count++;
                    Console.WriteLine("Student #{0}", Student.Count);

                    if (Util.Console.Ask("Another?  [Y/n]\n").ToLower() != "y")
                    {
                        adding = false;
                    }
            }
                catch (FormatException msg)
            {

                Console.WriteLine(msg.Message);

            }
            catch (Exception)
            {

                Console.WriteLine("Error, try again!");

            }
        }

            ShowGrade("Tom");
            foreach (Student student in students)
            {

                Console.WriteLine("{0}: {1}", student.Name, student.Grade);
               
            }
            Exports();
        }
        
        static void Import()
        {
            Student importedStudent = new Student("Jenny",86,"Birfday","Addy","phone");
            Console.WriteLine(importedStudent.Name);
        }

        static void Exports()
        {
            foreach (Student student in students)
            {
                switch (student.School)
                {
                    case School.Hogwarts:
                        Console.WriteLine("Exporting to Hogwarts High");
                        break;
                    case School.Harvard:
                        Console.WriteLine("Exporting to Harvard High");
                        break;
                    case School.Yael:
                        Console.WriteLine("Exporting to Yael High");
                        break;
                }
            }
        }

        static void ShowGrade(string name)
        {

            var found = students.Find(student => student.Name == name);

            Console.WriteLine("{0}'s Grade: {1}", found.Name, found.Grade);

        }

    }
    class Member
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


    }
    class Student : Member
    {
        static public int Count { get; set; } = 0;

        public int Grade { get; set; }
        public string Birthday { get; set; }
        public School School { get; set; }

        public Student()
        {

        }

        public Student(string name, int grade, string birthday, string address, string phone)
        {
            Name = name;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            Phone = phone;
        }

    }
}

