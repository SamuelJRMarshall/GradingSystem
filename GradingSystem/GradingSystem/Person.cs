using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public class Person
	{
		public int Year
		{
			get;
		}

		const int MINYEAR = 7;
		const int MAXYEAR = 13;

		public string Name
		{
			get;

		}

		private string ID;

		public Person ( string iD, string name = "?", int year = 7 )
		{
			ID = iD;

			if ( !string.IsNullOrEmpty ( name ) )
			{
				Name = name;
			}

			if ( year >= MINYEAR && year <= MAXYEAR )
			{
				Year = year;
			}

		}

		public Person ( )
		{
		}
	}
}
