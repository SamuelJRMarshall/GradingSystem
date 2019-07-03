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

		public Person(string name, int year)
		{
			if (!string.IsNullOrEmpty(name))
			{
				Name = name;
			}

			if(year >= MINYEAR && year <= MAXYEAR)
			{
				Year = year;
			}
		}
	}
}
