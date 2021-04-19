using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University
{
    public class Specialty
    {
        Random random = new Random();//izpolzva se za random izbiratelen predmet

        public Specialty(string name, int year)
        {
            this.name = name;
            this.year = year;
        }



        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        private int studentsCount = 0;

        public int StudentsCount
        {
            get { return studentsCount; }
            set { studentsCount = value; }
        }


        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }



        private List<Subject> commonSubjects = new List<Subject> { new Subject("Math"), new Subject("OOP"), new Subject("OOP2") };
        private List<Subject> electiveSubjects = new List<Subject> { new Subject("Robotika"), new Subject("Android") };



        public List<Subject> CommonSubjects
        {
            get { return commonSubjects; }
        }
        public List<Subject> ElectiveSubjects
        {
            get { return electiveSubjects; }
        }



        private List<Student> students = new List<Student>();

        public void AddElective(string name)
        {
            electiveSubjects.Add(new Subject(name));
        }

        public void AddCommon(string name)
        {
            commonSubjects.Add(new Subject(name));
        }



        public void AddStudent(Student student)
        {
            students.Add(student);
            foreach (var item in commonSubjects)
            {
                student.AddMark(item, 0);
            }
            student.AddMark(electiveSubjects[random.Next(electiveSubjects.Count)], 0);
            this.studentsCount++;
        }



        public void PrintInfo()
        {
            Console.WriteLine($"{this.name}");
            Console.Write("Common subjects: ");
            foreach (var item in commonSubjects)
            {
                Console.Write($" {item.Name} , ");
            }
            Console.WriteLine();
            Console.Write("Elective subjects: ");
            foreach (var item in electiveSubjects)
            {
                Console.Write($" {item.Name} ,  ");
            }
            Console.WriteLine();
            Console.WriteLine($"Students {this.studentsCount}");
        }



        public List<Student> GetStudentsBySubject(Subject subject)
        {
            List<Student> studentsInSubject = new List<Student>();
            foreach (var item in students)
            {
                if (item.Classes.Keys.Contains(subject))
                {
                    studentsInSubject.Add(item);
                }
            }
            return studentsInSubject;
        }



        public double GetAvgScore(Subject subject)
        {
            double sum = 0.0;
            foreach (var item in students)
            {
                if (item.Classes.Keys.Contains(subject))
                {
                    sum += item.Classes.First(w => w.Key == subject).Value;
                }
            }
            return sum / GetStudentsBySubject(subject).Count;
        }



        public List<double> TopMarks()
        {
            List<double> TopMarksList = new List<double>();
            foreach (var item in students)
            {
                if (!TopMarksList.Contains(item.AverageMark()))
                {
                    TopMarksList.Add(item.AverageMark());
                }

            }
            TopMarksList.Sort(); TopMarksList.Reverse();
            return TopMarksList;
        }



        public void GetTopStudents(int n)
        {
            List<double> topMarks = TopMarks();
            if (!(topMarks.Count >= n)) n = topMarks.Count;

            for (int i = 0; i < n; i++)
            {
                foreach (var item in students)
                {
                    if (item.AverageMark() == topMarks[i])
                    {
                        Console.WriteLine($"{i + 1} : {item.Name} , {item.AverageMark()}");
                    }
                }
            }

        }
    }
}
