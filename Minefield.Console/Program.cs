using Minefield.Business.Interface;
using Minefield.Business.Manager;

namespace Minefield.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO Remove dependency
            // Use Ninject to break applications into loosely-coupled modules
            IMinefieldManager game = new MinefieldManager();
            game.StartGame();
        }
    }
}