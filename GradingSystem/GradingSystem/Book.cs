using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public abstract class Book : NamedObject, IBook
	{
		public Book(string name) : base(name)
		{

		}

		public List<double> Grades { get; set; }

		public abstract event GradeAddedDelegate GradeAdded;

		public abstract void AddGrade(params double[] grade);

		public virtual Statistics GetStatistics()
		{
			var result = new Statistics(Grades);
			return result;
		}

		public virtual void AddGrade(char letter)
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

	}
}
