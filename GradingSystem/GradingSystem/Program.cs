using System;

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

			while(true)
			{
				Console.WriteLine("Enter a grade or 'q' to quit");
				var input = Console.ReadLine();

				if(input == "q")
				{
					break;
				}

				var grade = double.Parse(input);
				book.AddGrade(grade);
			}
        }
    }
}
