using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University
{
    public class Student
    {
        private string name;


        public Student(string name , string FN, Dictionary<Subject,double> subjects )
        {
            this.Name = name;
            this.FacNum = FN;
            this.classes = subjects;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value != "")
                {
                    name = value;
                }
            }
        }

        private string facNum;

        public string FacNum
        {
            get { return facNum; }
            set
            {
                if (value.Length == 5)
                {
                    facNum = value;
                }
            }
        }
        
        private Dictionary<Subject, double> classes = new Dictionary<Subject, double>();
        public Dictionary<Subject,double> Classes
        {
            get { return classes; }
            set { }
        }
        public double GetMark(Subject key)
        {
            double result=0;

            if (classes.Keys.Any(w=>w.Name==key.Name))
            {
                result = classes[classes.Keys.First(w => w.Name == key.Name)];
            }

            return result;
        }

        public void AddMark(Subject key, double value)
        {
            if (classes.ContainsKey(key))
            {
                classes[key] = value;
            }
            else
            {
                classes.Add(key, value);
            }
        }

        public int ClassesCount()
        {
            return classes.Count;
        }

        public void ReturnClasses()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in classes)
            {
                sb.Append(item.Key + " ");
            }
            Console.WriteLine(sb.ToString());
        }

        public double AverageMark()
        {
            double sum=0.0;
            foreach (var item in classes)
            {
                sum += item.Value;
            }
            return sum/classes.Count ;
        }

        public void OutputInfo()
        {
            Console.WriteLine($"Student name : {this.name} , Student number : {this.facNum}");
            Console.WriteLine("Marks: ");
            foreach (var item in classes)
            {
                
                Console.WriteLine($"{item.Key.Name} : {item.Value}");
            }
        }

    }
}
