using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        private List<float> grades;
        private string _name = "Empty";
        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                if (_name != value && NameChanged != null)
                {
                    NameChangeEventArgs args = new NameChangeEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;

            }
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public event NameChangedDelegate NameChanged;



        public GradeBook()
        {
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count();

            return stats;
        }




        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }


    }
}
