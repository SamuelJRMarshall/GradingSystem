using System;
using Xunit;
using GradingSystem;

namespace GradingSystem.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestBookStatistics()
        {
			// Arrange
			Book book = new Book("Sam's Gradebook");
			book.AddGrade(91.0);
			book.AddGrade(54.4);
			book.AddGrade(77.3);

			// Act 
			var result = book.GetStatistics();

			// Assert
			Assert.Equal(74.23, result.Average, 2);
			// Whilst I was testing this line I found a typo, so thats helpful!!
			Assert.Equal(91.0, result.High, 2);
			Assert.Equal(54.4, result.Low, 2);

		}


		/// Here we are using unit testing to verfy how initialising objects in 
		/// different ways can either create a new object or reference another one
		[Fact]
		public void GetBookCreatesUniqueObjects()
		{
			var book1 = GetBook("Book 1");
			var book2 = GetBook("Book 2");

			Assert.Equal("Book 1", book1.Name);
			Assert.Equal("Book 2", book2.Name);
		}

		[Fact]
		public void TwoVarsCanReferenceSameObject()
		{
			var book1 = GetBook("Book 1");
			var book2 = book1;

			Assert.Same(book1, book2);
		}

		Book GetBook(string name)
		{
			return new Book(name);
		}
	}
}
