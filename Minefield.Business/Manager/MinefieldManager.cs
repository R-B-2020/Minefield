using Minefield.Business.Interface;
using Minefield.Business.Util;
using Minefield.Business.Domain;
using System;

namespace Minefield.Business.Manager
{
    /// <summary>
    /// MinefieldManager class is the main business engine to control the game. 
    /// </summary>
    public class MinefieldManager : IMinefieldManager
    {
        // TODO Remove dependency
        // example - use Ninject to break applications into loosely-coupled modules

        private readonly IPrintManager printManager = PrintManager.GetInstance();
        private readonly IValidationManager validation = new ValidationManager();

        //TODO : Configure values or ask for user input
        private readonly IBoardManager board = new BoardManager(5, 10, 15);

        private bool isBlast = false;
        private bool isWinner = false;

        public void StartGame()
        {
            board.Initialize();
            printManager.PrintMessage(Messages.Welcome);

            while (true)
            {
                if (isBlast || isWinner) break;

                printManager.PrintField(board.MineField, isBlast);
                printManager.PrintMessage(Messages.UserMove);
                string userInput = Console.ReadLine();

                if (!validation.IsUserMoveValid(userInput.Trim()))
                    continue;

                if (board.IsMoveOnBoard(validation.Row, validation.Col) && !board.IsCellOpen(validation.Row, validation.Col))
                {
                    isBlast = IsBlast(board.MineField, validation.Row, validation.Col);
                    isWinner = IsPlayerWin(board.MineField, board.NumberOfMines);
                    GameResult(isBlast, isWinner);

                    //TODO: display updated board if user still playing
                    //board.RepaintBoard(validation.row, validation.col);
                }
                else
                    printManager.PrintMessage(Messages.InUseOrOutOfRange);
            }
        }

        public void GameResult(bool isBlast, bool isWinner)
        {
            string message;
            if (isWinner)
                message = Messages.Success;
            else if (isBlast)
                message = Messages.Blast;
            else
                return;

            printManager.PrintField(board.MineField, isBlast);
            printManager.PrintMessage(message);
            Console.ReadLine();
        }

        private bool IsPlayerWin(Cell[,] matrix, int minesCount)
        {
            isWinner = board.RevealedCells == matrix.Length - minesCount;
            return isWinner;
        }

        private bool IsBlast(Cell[,] matrix, int row, int col)
        {
            isBlast = matrix[row, col].IsBomb;
            return isBlast;
        }
    }
}