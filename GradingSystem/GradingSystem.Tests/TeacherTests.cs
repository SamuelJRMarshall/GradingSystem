using System;
using Xunit;
using GradingSystem;

namespace GradingSystem.Tests
{
	public class TeacherTests
	{
		[Theory]
		[InlineData("Mr Philips", 8, "Maths", "Engineering", "Mr")]
		[InlineData("Miss Jones", 12, "English", "Literature", "Miss")]
		[InlineData("Prof Roberts", 8, "Biology", "Science", "Prof")]
		public void Teacher_AllVariations_ReturnsExpected(string name, int year, string sub, string dep, string honor)
		{
			var teacher = new Teacher(name, year, sub, dep, honor);

			Assert.Equal(name, teacher.Name);
		}
	}
}
