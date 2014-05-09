using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordSearchPuzzle.Test
{
    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void FindWordLrWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordLr(wordToFind, grid);

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void FindWordLrWithLowercaseWordWillReturnObjectWithCapitalizedWord()
        {
            // Arrange
            const string wordToFind = "word";
            const string expectedText = "WORD";
            const string expectedDirection = "LR";

            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordLr(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedText);
            result.WordDirection.Should().Be(expectedDirection);

        }

        [TestMethod]
        public void FindWordRlWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordRl(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindWordRlWithRightToLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "brat";
            const string expectedWord = "BRAT";
            const string expectedDirection = "RL";
            var grid = Get.AnySmallGrid();
            
            // Act
            var result = WordSearch.FindWordRl(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindWordUWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordU(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindWordUWithRightToLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "arop";
            const string expectedWord = "AROP";
            const string expectedDirection = "U";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordU(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindWordDWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordD(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindFirstLetterWillReturnListOfFirstLettersAndLocationsInGrid()
        {
            // Arrange
            const string wordToFind = "brat";
            var grid = Get.AnySmallGrid();
            var expectedFirstLetterList = new FirstLetterList(wordToFind)
            {
                Locations = new List<FirstLetter>
                {
                    new FirstLetter
                    {
                        Row = 2,
                        Column = 3
                    },
                    new FirstLetter
                    {
                        Row = 3,
                        Column = 3
                    }
                }
            };

            // Act
            var result = WordSearch.FindFirstLetter(wordToFind, grid);

            // Assert
            result.ShouldBeEquivalentTo(expectedFirstLetterList);
        }
    }
}
