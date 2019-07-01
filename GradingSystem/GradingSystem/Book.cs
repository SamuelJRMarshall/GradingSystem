using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
    public class Book
    {
		/// Using a readonly access modifier lets the name only be set in the 
		/// constructor or when it is initialised
        public readonly string Name;
        private List<double> grades = new List<double>();

		// This is a constructor and runs when the class is instantiated
		public Book(string name)
        {
            Name = name;
        }

		// This is a public method which takes a parameter
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

		/// The another method can have the same name if it has a different
		/// method signature, this can be achieved by taking different 
		/// parameters
		public void AddGrade(char grade)
		{

		}

		public Statistics GetStatistics()
		{
			var result = new Statistics();

			foreach (var grade in grades)
			{
				result.Low = Math.Min(grade, result.Low);
				result.High = Math.Max(grade, result.High);
				result.Average += grade;
			}
			result.Average /= grades.Count;

			return result;
		}
    }
}
