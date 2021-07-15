using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.Business.Domain;
using Minefield.Business.Manager;

namespace Minefield.Tests
{
    [TestClass]
    public class BoardManagerUnitTests
    {
        private string[,] matrix;
        private BoardManager boardManager;

        private const int rows = 5;
        private const int cols = 10;
        private const int numberOfMines = 10;
        private const string cellWithBlastValue = " *";
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
        public void FillWithRandomMines_method_must_fill_mines_with_numberOfMines()
        {
            boardManager.Initialize();
            Cell[,] mineField = boardManager.MineField;
            var counter = 0;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (mineField[i, j].Value == cellWithBlastValue)
                        counter++;
                }
            }

            Assert.AreEqual(numberOfMines, counter);
        }

        [TestMethod]
        public void GetDefaultField_method_should_run_as_expected()
        {
            int row = 12;
            int col = 4;
            string[,] mineField = new string[row, col];
            var mineFieldTest = new BoardManager(row, col, numberOfMines);
            mineFieldTest.GetDefaultField();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mineField[i, j] = string.Empty;
                    Assert.AreEqual(cellWithDefaultValue, mineField[i, j]);
                }
            }
        }

        [TestMethod]
        public void IsCellOpen_method_returns_false_if_cell_not_open()
        {
            boardManager.GetDefaultField();
            matrix[1, 1] = cellWithDefaultValue;
            var output = boardManager.IsCellOpen(1, 1);

            Assert.AreEqual(false, output);
        }


        [TestMethod]
        public void IsCellOpen_method_validate_value_if_blast()
        {
            boardManager.GetDefaultField();

            matrix[1, 1] = cellWithBlastValue;
            var output = boardManager.IsCellOpen(1, 1);
            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void IsCellOpen_method_return_false_if_unknown_value()
        {
            boardManager.GetDefaultField();

            matrix[1, 1] = "unknown value";
            var output = boardManager.IsCellOpen(4, 5);
            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_true_if_valid_move()
        {
            var output = boardManager.IsMoveOnBoard(0, 0);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_true_if_edge_case()
        {
            var output = boardManager.IsMoveOnBoard(4, 9);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_true_if_another_edge_case()
        {
            var output = boardManager.IsMoveOnBoard(0, 9);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_true_if_first_row_edge_case()
        {
            var output = boardManager.IsMoveOnBoard(4, 0);
            Assert.AreEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_false_if_one_invalid_number()
        {
            var output = boardManager.IsMoveOnBoard(-1, 0);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_false_if_both_are_invalid_number()
        {
            var output = boardManager.IsMoveOnBoard(-1, -1);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_false_if_one_invalid_other_edge_case()
        {
            var output = boardManager.IsMoveOnBoard(-1, 9);
            Assert.AreNotEqual(true, output);
        }

        [TestMethod]
        public void IsMoveOnBoard_method_return_false_big_number()
        {
            var output = boardManager.IsMoveOnBoard(2000000, 5000000);
            Assert.AreNotEqual(true, output);
        }
    }
}