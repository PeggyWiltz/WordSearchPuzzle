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
        public void FindWordUWithBottomToTopWordFoundShouldReturnCorrectFoundWord()
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
        public void FindWordDWithTopToBottomWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "irar";
            const string expectedWord = "IRAR";
            const string expectedDirection = "D";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordD(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindWordDulWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDul(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindWordDulWithDiagonalUpLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "baot";
            const string expectedWord = "BAOT";
            const string expectedDirection = "DUL";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDul(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindWordDurWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDur(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindWordDurWithDiagonalUpLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "trrr";
            const string expectedWord = "TRRR";
            const string expectedDirection = "DUR";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDur(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindWordDdlWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDdl(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindWordDdlWithDiagonalUpLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "rrrt";
            const string expectedWord = "RRRT";
            const string expectedDirection = "DDL";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDdl(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindWordDdrWithNoWordFoundShouldReturnNull()
        {
            // Arrange
            const string wordToFind = "test";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDdr(wordToFind, grid);

            // Assert
            result.Should().Be(null);
        }

        [TestMethod]
        public void FindWordDdrWithDiagonalUpLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "toab";
            const string expectedWord = "TOAB";
            const string expectedDirection = "DDR";
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDdr(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
        }

        [TestMethod]
        public void FindFirstLetterWillReturnListOfFirstLettersAndLocationsInGrid()
        {
            // Arrange
            const string wordToFind = "brat";
            var grid = Get.AnySmallGrid();
            var expectedFirstLetterList = new FirstLetterList(wordToFind)
            {
                Locations = new List<GridLocation>
                {
                    new GridLocation
                    {
                        Row = 2,
                        Column = 3
                    },
                    new GridLocation
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
