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
			Login();


		}

		private static void Login()
		{
			Console.WriteLine($"Login: {Environment.NewLine}Are you a 'S'tudent" +
				$" or a 'T'eacher? {Environment.NewLine}Enter 'S' or 'T'");
			var input = Console.ReadLine();
			switch (input)
			{
				case "S":
					//student
					break;

				case "T":
					//Teacher
					break;

				default:
					Console.WriteLine("Try again please");
					break;
			}

		}

		private void BookEntrance()
		{
			var diskBook = new DiskBook("DiskBook");
			diskBook.GradeAdded += OnGradeAdded;
			EnterGrades(diskBook);
		}

		private static void EnterGrades(IBook book)
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
