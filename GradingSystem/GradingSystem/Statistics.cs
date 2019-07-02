using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
    public class Statistics
    {
		public double Average, High, Low;
		public const double MAXGRADE = 100, MINGRADE =0;
		public char Letter;
		public Statistics()
		{
			Average = 0.0;
			High = MINGRADE;
			Low = MAXGRADE;
		}
    }
}
