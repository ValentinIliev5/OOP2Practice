using System;
using System.Collections.Generic;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Student pesho = new Student("pesho", "01234", new Dictionary<Subject, double>());
            Student gosho = new Student("gosho", "01235", new Dictionary<Subject, double>());
            Specialty se = new Specialty("se", 1);
            

            se.AddStudent(pesho);
            se.AddStudent(gosho);

            
           
            for (int i = 0; i < 3; i++)
            {
                pesho.AddMark(se.CommonSubjects[i], rnd.Next(2, 7));
                gosho.AddMark(se.CommonSubjects[i], rnd.Next(2, 7));
            }
            for (int i = 0; i < 2; i++)
            {
                pesho.AddMark(se.ElectiveSubjects[i], rnd.Next(2, 7));
                gosho.AddMark(se.ElectiveSubjects[i], rnd.Next(2, 7));
            }


            pesho.OutputInfo();
            gosho.OutputInfo();
            se.PrintInfo();
            Console.WriteLine(se.GetStudentsBySubject(se.ElectiveSubjects[0]).Count); // studenti v predmet
            Console.WriteLine($"{se.GetAvgScore(se.ElectiveSubjects[0]):f2}"); //sreden uspeh po predmet
            se.GetTopStudents(2); // top studenti
        }

    }
}
