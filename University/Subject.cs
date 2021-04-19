using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    public class Subject
    {
        private string name;

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
        public Subject(string name)
        {
            this.Name = name;
        }

    }
}
