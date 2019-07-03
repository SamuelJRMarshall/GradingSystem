using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public class NamedObject
	{
		public string Name
		{
			get; set;
		}

		public NamedObject(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				Name = name;
			}
		}
	}
}
