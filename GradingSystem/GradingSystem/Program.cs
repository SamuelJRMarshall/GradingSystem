using System;
using System.Text.RegularExpressions;

/// <summary>
/// This code was created whilst following the C# Fundamentals course on Pluralsight
/// </summary>

namespace GradingSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			var book = new Book("Book");
			book.GradeAdded += OnGradeAdded;
			EnterGrades(book);
		}

		private static void EnterGrades(Book book)
		{
			while (true)
			{
				Console.WriteLine("Enter a grade or 'q' to quit");
				var input = Console.ReadLine();

				if (input == "q")
				{
					break;
				}

				try
				{
					//TODO
					#region
					//var isNumeric = int.TryParse(input, out int n);
					//bool containsLetter = Regex.IsMatch(myString, "[A-Z]");
					#endregion
					var grade = double.Parse(input);
					book.AddGrade(grade);
				}
				catch (FormatException ex)
				{
					Console.WriteLine(ex);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex);
				}
			}
		}

		static void OnGradeAdded(object sender, EventArgs e)
		{
			
		}
	}
}
