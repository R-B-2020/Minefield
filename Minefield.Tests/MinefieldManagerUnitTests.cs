using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.Business.Manager;

namespace Minefield.Tests
{
    [TestClass]
    public class MinefieldManagerUnitTests
    {
        private string[,] matrix;
        private BoardManager boardManager;

        private const int rows = 5;
        private const int cols = 10;
        private const int numberOfMines = 15;
        private string cellWithDefaultValue = string.Empty;

        [TestCleanup]
        public void CleanTest()
        {
            boardManager = null;
            matrix = null;
        }

        [TestInitialize]
        public void Init()
        {
            boardManager = new BoardManager(rows, cols, numberOfMines);
            matrix = new string[rows, cols];
        }

        [TestMethod]
        public void StartGame_method_has_valid_matrix()
        {
            boardManager.GetDefaultField();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = string.Empty;
                    Assert.AreEqual(cellWithDefaultValue, matrix[i, j]);
                }
            }
        }

        [TestMethod]
        public void StartGame_method_has_valid_matrix_with_mines()
        {
            string[,] mineField = new string[rows, cols];
            var mineFieldTest = new BoardManager(rows, cols, numberOfMines);
            mineFieldTest.GetDefaultField();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    mineField[i, j] = string.Empty;
                    Assert.AreEqual(cellWithDefaultValue, mineField[i, j]);
                }
            }
        }
    }
}