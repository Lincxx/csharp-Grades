using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeBook
    {
        private List<float> grades;

        public GradeBook()
        {
             grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            return new GradeStatistics();
        }


        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }


    }
}
