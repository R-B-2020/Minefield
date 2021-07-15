namespace Minefield.Business.Interface
{
    using Minefield.Business.Domain;
    public interface IPrintManager
    {
        void PrintMessage(string message); 
        void PrintField(Cell[,] matrix, bool blast);
    }
}