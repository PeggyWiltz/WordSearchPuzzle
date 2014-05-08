using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordSearchPuzzle.Test
{
    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void FindWordWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWord(wordToFind, grid);

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void SearchGridWithLowercaseWordWillReturnObjectWithCapitalizedWord()
        {
            // Arrange
            const string wordToFind = "word";
            const string expectedText = "WORD";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWord(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedText);
        }
    }
}
