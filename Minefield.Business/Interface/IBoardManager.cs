using Minefield.Business.Domain;

namespace Minefield.Business.Interface
{
    public interface IBoardManager
    {
        int NumberOfMines { get; set; }

        int RevealedCells { get; set; }

        Cell[,] MineField { get; set; }

        void Initialize();

        bool IsMoveOnBoard(int row, int col);

        bool IsCellOpen(int row, int col);

        void RepaintBoard(int row, int col);

        void GetDefaultField();
    }
}
