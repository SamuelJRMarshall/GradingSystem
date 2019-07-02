using System;
using Xunit;
using GradingSystem;

namespace GradingSystem.Tests
{
	public delegate string WriteLogDelegate(string logMessage);

	public class BookTests
	{
		[Fact]
		public void WriteLogDelegate_ProvideMethod_ReturnsString()
		{
			WriteLogDelegate log = ReturnMessage;

			var result = log("Heya!");

			Assert.Equal("Heya!", result);
		}

		string ReturnMessage(string message)
		{
			return message;
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(101)]
		public void AddGrade_InvalidGrade_ReturnsNaN(double input)
		{
			Book book = new Book("0");

			book.AddGrade(input);
			var result = book.GetStatistics();

			Assert.True(double.IsNaN(result.Average));
		}

		[Theory]
		[InlineData(90, 'A')]
		[InlineData(80, 'B')]
		[InlineData(70, 'C')]
		[InlineData(60, 'D')]
		[InlineData(50, 'F')]
		public void GetStatistics_MultipleNumbers_ReturnsLetterGrade(int input, char expected)
		{
			// Arrange
			Book book = new Book("0");

			// Act 
			book.AddGrade(input);
			var result = book.GetStatistics();

			// Assert
			Assert.Equal(expected, result.Letter);
		}

		[Theory]
		[InlineData(1, 2, 3)]
		public void GetStatistics_MultipleNumbers_ReturnsAverageOfNumbers(double input1, double input2, double input3)
		{
			// Arrange
			Book book = new Book("0");

			// Act 
			book.AddGrade(input1, input2, input3);
			var result = book.GetStatistics();

			// Assert
			Assert.Equal(2, result.Average, 2);
		}

		[Fact]
		public void OutAddGrade_Number_ReturnsThatNumber()
		{
			var book = new Book("0");

			OutAddGrade(out book, 1, "1");
			var result = book.GetStatistics();

			Assert.Equal(1, result.Average);
		}

		[Fact]
		public void RefAddGrade_Number_ReturnsThatNumber()
		{
			var book = GetBook("0");

			RefAddGrade(ref book, 1, "1");
			var result = book.GetStatistics();

			Assert.Equal(1, result.Average);
		}

		[Fact]
		public void AddGrade_Number_ReturnsNaN()
		{
			var book = GetBook("0");

			AddGrade(book, 1, "1");
			var result = book.GetStatistics();

			Assert.True(double.IsNaN(result.Average));
		}

		[Fact]
		public void GetBook_CreateTwoBooks_MakesUniqueObjects()
		{
			var book1 = GetBook("0");
			var book2 = GetBook("1");

			Assert.Equal("0", book1.Name);
			Assert.Equal("1", book2.Name);
		}

		[Fact]
		public void GetBook_BooksEqual_BooksReferenceEachOther()
		{
			var book1 = GetBook("0");
			var book2 = book1;

			Assert.Same(book1, book2);
		}

		void AddGrade(Book book, double grade, string name)
		{
			book = new Book(name);
			book.AddGrade(grade);
		}

		void OutAddGrade(out Book book, double grade, string name)
		{
			book = new Book(name);
			book.AddGrade(grade);
		}

		void RefAddGrade(ref Book book, double grade, string name)
		{
			book = new Book(name);
			book.AddGrade(grade);
		}

		Book GetBook(string name)
		{
			return new Book(name);
		}
	}
}
