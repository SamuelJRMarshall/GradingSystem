using System;
using System.Text.RegularExpressions;

namespace GradingSystem
{
	class Program
	{
		static void Main ( string[ ] args )
		{

			Login ( );
		}

		private static void Login ( )
		{
			Console.WriteLine ( $"Login: {Environment.NewLine} Enter your 6 Digit ID" );
			var person = new Person ( );
			FindById ( Console.ReadLine ( ), out person );
		}

		private static void FindById ( string input, out Person person )
		{
			if ( input.Length == 6 )
			{
				switch ( input )
				{
					case var i when i.Contains ( "T" ):
						person = new Teacher ( input );
						break;

					default:
						var student = new Student ( input );
						break;
				}
			}
			else
			{
				Console.WriteLine ( "Incorrect ID, please try again, the ID must be in the format '######'" );
				FindById ( Console.ReadLine ( ), out person );
			}
		}


		private void OldBookEntrance ( )
		{
			var diskBook = new DiskBook ( "DiskBook" );
			diskBook.GradeAdded += OnGradeAdded;
			EnterGrades ( diskBook );
		}

		private static void EnterGrades ( IBook book )
		{
			while ( true )
			{
				Console.WriteLine ( "Enter a grade or 'q' to quit" );
				var input = Console.ReadLine ( );

				if ( input == "q" )
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
					var grade = double.Parse ( input );
					book.AddGrade ( grade );
				}
				catch ( FormatException ex )
				{
					Console.WriteLine ( ex );
				}
				catch ( ArgumentException ex )
				{
					Console.WriteLine ( ex );
				}
			}
		}

		static void OnGradeAdded ( object sender, EventArgs e )
		{

		}
	}
}
