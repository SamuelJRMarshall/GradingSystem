using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public interface IBook
	{
		void AddGrade(params double[] grade);
		Statistics GetStatistics();
		string Name { get; }
		List<double> Grades { get; set; }
		event GradeAddedDelegate GradeAdded;
	}
}
