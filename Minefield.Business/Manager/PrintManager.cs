namespace Minefield.Business.Manager
{
    using Minefield.Business.Interface;
    using Minefield.Business.Domain;
    using System;

    /// <summary>
    /// PrintManager class cares about console printing. 
    /// </summary>
    public class PrintManager : IPrintManager
    {
        // Singleton
        private static PrintManager instance;

        public static PrintManager GetInstance()
        {
            if (instance == null)
                instance = new PrintManager();
            return instance;
        }

        public void PrintField(Cell[,] matrix, bool blast)
        {
            //TODO: record the exception or/and show to user
            if (matrix == null)
                throw new ArgumentException("matrix can not be null");

            string printMessage;
            Console.WriteLine("\n     0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("------------------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!blast)
                        printMessage = matrix[i, j].Value == string.Empty || matrix[i, j].IsBomb ? " ?" : matrix[i, j].Value;
                    else
                        printMessage = matrix[i, j].Value == string.Empty ? " -" : matrix[i, j].Value;
                    Console.Write(printMessage);
                }
                Console.WriteLine(" |");
            }
            Console.WriteLine("------------------------");
        }

        public void PrintMessage(string message)
        {
            Console.Write(message);
        }
    }
}