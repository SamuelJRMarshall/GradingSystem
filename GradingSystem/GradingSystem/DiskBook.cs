using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GradingSystem
{
	public class DiskBook : Book
	{
		public override event GradeAddedDelegate GradeAdded;

		public DiskBook(string name) : base(name)
		{
			Grades = new List<double>();
			LoadFile();
		}

		public override void AddGrade(params double[] grade)
		{
			foreach (double number in grade)
			{
				if (number >= Statistics.MINGRADE && number <= Statistics.MAXGRADE)
				{
					using (var writer = File.AppendText($"{Name}.txt"))
					{
						writer.WriteLine(number);
					}

					GradeAdded?.Invoke(this, new EventArgs());
				}
				else
				{
					throw new ArgumentException($"Invalid {nameof(grade)}");
				}
			}

		}

		public void LoadFile()
		{
			using (var reader = File.OpenText($"{Name}.txt"))
			{
				var line = reader.ReadLine();
				while (line != null)
				{
					var number = double.Parse(line);
					Grades.Add(number);
					line = reader.ReadLine();
				}
			}
		}
	}
}
