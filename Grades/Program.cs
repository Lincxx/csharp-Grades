﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            //GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook()
        {

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello, this is the grade book program");

            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

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
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75f);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("something went wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        //static void WriteResult(string description, int result)
        //{
        //   Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        //static void OnNameChanged(object sender, NameChangeEventArgs args)
        //{
         //   Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}

      
    }
}
