using Minefield.Business.Interface;
using Minefield.Business.Domain;
using System;

namespace Minefield.Business.Manager
{
    /// <summary>
    /// BoardManager class is to manage the game board (matrix) with random mines. 
    /// </summary>
    public class BoardManager : IBoardManager
    {
        private readonly Cell _cel = new Cell();
        private Random _random;
        private int Rows { get; set; }
        private int Cols { get; set; }
        public int NumberOfMines { get; set; }
        public Cell[,] MineField { get; set; }
        public int RevealedCells { get; set; }

        public BoardManager(int rows, int cols, int numbOfMines)
        {
            this.NumberOfMines = numbOfMines;
            this.Rows = rows;
            this.Cols = cols;
            this.MineField = new Cell[this.Rows, this.Cols];
            this.RevealedCells = 0;
        }

        public void Initialize()
        {
            this.RevealedCells = 0;
            this.GetDefaultField();
            this.FillWithRandomMines();
        }

        public bool IsMoveOnBoard(int row, int col)
        {
            return (row >= 0) && (row < this.Rows) && (col >= 0) && (col < this.Cols);
        }

        public bool IsCellOpen(int row, int col)
        {
            return this.MineField[row, col].Value != string.Empty && !this.MineField[row, col].IsBomb;
        }

        public void GetDefaultField()
        {
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Cols; j++)
                    this.MineField[i, j] = this._cel.Clone();
        }

        private void FillWithRandomMines()
        {
            _random = new Random();
            var minesCounter = 0;
            while (minesCounter < NumberOfMines)
            {
                int randomRow = _random.Next(0, Rows);
                int randomCol = _random.Next(0, Cols);
                if (this.MineField[randomRow, randomCol].IsBomb)
                    continue;
                this.MineField[randomRow, randomCol].IsBomb = true;
                this.MineField[randomRow, randomCol].Value = " *";
                minesCounter++;
            }
        }

        public void RepaintBoard(int row, int col)
        {
            throw new NotImplementedException();
        }
    }
}
