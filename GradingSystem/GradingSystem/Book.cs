using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public class NamedObject
	{
		public readonly string Name;

		public NamedObject(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				Name = name;
			}
		}
	}


	public class Book : NamedObject
	{
		/*	Using a readonly access modifier lets the name only be set in the 
			constructor or when it is initialised */
		public event GradeAddedDelegate GradeAdded;

		private List<double> grades;

		//	This is a constructor and runs when the class is instantiated
		public Book(string name) : base(name)
		{
			grades = new List<double>();
		}

		//	This is a public method which takes a parameter
		public void AddGrade(params double[] grade)
		{
			foreach (double number in grade)
			{
				if (number >= Statistics.MINGRADE && number <= Statistics.MAXGRADE)
				{
					grades.Add(number);
					GradeAdded?.Invoke(this, new EventArgs());
				}
				else
				{
					throw new ArgumentException($"Invalid {nameof(grade)}");
				}
			}

		}

		/*	The another method can have the same name if it has a different
			method signature, this can be achieved by taking different 
			parameters */
		public void AddGrade(char letter)
		{
			switch (letter)
			{
				case 'A':
					AddGrade(90);
					break;

				case 'B':
					AddGrade(80);
					break;

				case 'C':
					AddGrade(70);
					break;

				case 'D':
					AddGrade(60);
					break;

				default:
					AddGrade(0);
					break;
			}
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

			switch (result.Average)
			{
				case var grade when grade >= 90.0:
					result.Letter = 'A';
					break;

				case var grade when grade >= 80.0:
					result.Letter = 'B';
					break;

				case var grade when grade >= 70.0:
					result.Letter = 'C';
					break;

				case var grade when grade >= 60.0:
					result.Letter = 'D';
					break;

				default:
					result.Letter = 'F';
					break;
			}

			return result;
		}
	}
}
