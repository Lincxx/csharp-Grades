using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello, this is the grade book program");

            GradeBook book = new GradeBook();
            book.Name = "Jeremy Gradebook";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics stats =  book.ComputeStatistics();

            //synth.Speak(nameof(stats.AverageGrade ) + " " + stats.AverageGrade);
            //synth.Speak(nameof(stats.HighestGrade) + " " + stats.HighestGrade);
            //synth.Speak(nameof(stats.LowestGrade) + " " + stats.LowestGrade);

            //Console.WriteLine(nameof(stats.AverageGrade) + " " + stats.AverageGrade);
            //Console.WriteLine(nameof(stats.HighestGrade) + " " + stats.HighestGrade);
            //Console.WriteLine(nameof(stats.LowestGrade) + " " + stats.LowestGrade);
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("HighestGrade", (int)stats.HighestGrade);
            WriteResult("LowestGrade", stats.LowestGrade);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:C}");
        }
    }
}
