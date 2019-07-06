using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public class InMemoryBook : Book
	{
		public override event GradeAddedDelegate GradeAdded;

		public InMemoryBook ( string name ) : base ( name )
		{
			Grades = new List<double> ( );
		}

		public override void AddGrade ( params double[ ] grade )
		{
			foreach ( double number in grade )
			{
				if ( number >= Statistics.MINGRADE && number <= Statistics.MAXGRADE )
				{
					Grades.Add ( number );
					GradeAdded?.Invoke ( this, new EventArgs ( ) );
				}
				else
				{
					Console.WriteLine ( $"Invalid {nameof ( grade )}" );
				}
			}

		}
	}
}
