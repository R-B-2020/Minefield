using Minefield.Business.Domain;

namespace Minefield.Business.Interface
{
    public interface IMinefieldManager
    {
        void StartGame();
        void GameResult(bool isBlast, bool isPlayerWon);
    }
}