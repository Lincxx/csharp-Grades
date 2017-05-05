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
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, this is the grade book program");

            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75f);

            GradeStatistics stats =  book.ComputeStatistics();

            synth.Speak(nameof(stats.AverageGrade ) + " " + stats.AverageGrade);
            synth.Speak(nameof(stats.HighestGrade) + " " + stats.HighestGrade);
            synth.Speak(nameof(stats.LowestGrade) + " " + stats.LowestGrade);
                     
        }
    }
}
