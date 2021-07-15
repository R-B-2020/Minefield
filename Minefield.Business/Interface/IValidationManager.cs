namespace Minefield.Business.Interface
{
    public interface IValidationManager
    {
        int Col { get; set; }
        int Row { get; set; }
        bool IsUserMoveValid(string userMove);
    }
}