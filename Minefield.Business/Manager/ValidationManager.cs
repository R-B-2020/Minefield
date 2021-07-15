using Minefield.Business.Interface;
using System;

namespace Minefield.Business.Manager
{
    /// <summary>
    /// ValidationManager to validate user input.
    /// </summary>
    public class ValidationManager : IValidationManager
    {
        public int Col{ get; set; }
        public int Row { get; set; }

        /// <summary>
        /// IsUserMoveValid : Checks if userMove input is valid.
        /// </summary>
        /// <param name="userMove">userMove input as a string.</param>
        /// <returns>Returns true if the userMove is valid otherwise false.</returns>
        public bool IsUserMoveValid(string userMove)
        {
            bool validMove;
            try
            {
                string[] userInput = userMove.Split();
                Row = int.Parse(userInput[0]);
                Col = int.Parse(userInput[1]);

                validMove = Row >= 0 && Col >= 0;
            }
            catch (FormatException)
            {
                //TODO : Validate userMove with the appropriate exception messages
                //TODO : Log exception and/or display to user.

                throw;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            return validMove;
        }
    }
}
