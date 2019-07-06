using System;
using System.Collections.Generic;
using System.Text;

namespace GradingSystem
{
	public class Teacher : Person
	{
		//enum Subjects { Maths, English, Biology };
		//enum Deparments { Engineering, Literature, Science  };
		//enum Honorifics { Mr, Miss, Mrs, Ms, Prof, Doc};

		public string Subject;
		public string Deparment;
		public string Honorific;

		public Teacher ( string iD ) : base ( iD )
		{

		}
	}
}
