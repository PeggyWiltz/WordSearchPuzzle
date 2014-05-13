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
            var expectedLocation = new GridLocation(1, 0);
                
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordLr(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedText);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
            

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
            var expectedLocation = new GridLocation(3,3);
            var grid = Get.AnySmallGrid();
            
            // Act
            var result = WordSearch.FindWordRl(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
            var expectedLocation = new GridLocation(3, 1);
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordU(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
            var expectedLocation = new GridLocation(0, 2);
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordD(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
            var expectedLocation = new GridLocation(3, 3);
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDul(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
        public void FindWordDurWithDiagonalUpRightWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "trrr";
            const string expectedWord = "TRRR";
            const string expectedDirection = "DUR";
            var expectedLocation = new GridLocation(3, 0);
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDur(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
        public void FindWordDdlWithDiagonalDownLeftWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "rrrt";
            const string expectedWord = "RRRT";
            const string expectedDirection = "DDL";
            var expectedLocation = new GridLocation(0, 3);
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDdl(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
        public void FindWordDdrWithDiagonalDownRightWordFoundShouldReturnCorrectFoundWord()
        {
            // Arrange
            const string wordToFind = "toab";
            const string expectedWord = "TOAB";
            const string expectedDirection = "DDR";
            var expectedLocation = new GridLocation(0, 0);
            var grid = Get.AnySmallGrid();

            // Act
            var result = WordSearch.FindWordDdr(wordToFind, grid);

            // Assert
            result.WordText.Should().Be(expectedWord);
            result.WordDirection.Should().Be(expectedDirection);
            result.Location.ShouldBeEquivalentTo(expectedLocation);
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
