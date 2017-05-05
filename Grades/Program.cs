using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics stats =  book.ComputeStatistics();

            Console.WriteLine(nameof(stats.AverageGrade ) + " " + stats.AverageGrade);
            Console.WriteLine(nameof(stats.HighestGrade) + " " + stats.HighestGrade);
            Console.WriteLine(nameof(stats.LowestGrade) + " " + stats.LowestGrade);

                      
        }
    }
}
