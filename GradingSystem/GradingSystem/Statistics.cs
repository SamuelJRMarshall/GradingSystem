using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public class Statistics
	{
		public double Average
		{
			get
			{
				return Sum / Count;
			}
		}

		public double High, Low;
		public const double MAXGRADE = 100, MINGRADE = 0;
		public double Sum;
		public int Count;

		public char Letter
		{
			get
			{
				switch (Average)
				{
					case var grade when grade >= 90.0:
						return 'A';

					case var grade when grade >= 80.0:
						return 'B';

					case var grade when grade >= 70.0:
						return 'C';

					case var grade when grade >= 60.0:
						return 'D';

					default:
						return 'F';
				}
			}
		}

		public Statistics(List<double> numbers)
		{
			Count = 0;
			Sum = 0.0;
			High = MINGRADE;
			Low = MAXGRADE;
			Add(numbers);
		}

		public void Add(List<double> numbers)
		{
			foreach (var number in numbers)
			{
				Sum += number;
				Count += 1;
				Low = Math.Min(number, Low);
				High = Math.Max(number, High);
			}
		}


		
	}
}
