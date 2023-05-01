using System;

namespace TicTacToe
{

    /* The Logic class contains methods for
     * determining a win or tie
     */
    public static class Logic
    {

        /* The CheckForTie method returns a boolean value which
         * determines whether the game is a tie
         */
        public static bool CheckForTie()
        {

            // Check if rows are empty
            for (int i = 0; i < 3; i++)
            {

                // Check if columns are empty
                for (int j = 0; j < 3; j++)
                {

                    // Empty spot found if equal to " "
                    if (Board.gameBoard[i, j] == " ")
                    {

                        // Empty spot found, game is not a tie
                        return false;
                    }
                }
            }

            // No empty spots found, game is a tie
            return true;
        }

        /* The CheckForWin method passes the current player's
         * symbol string value and returns a boolean value which
         * determines whether game has been won
         */
        public static bool CheckForWin(string symbol)
        {
            bool hasWon = false;

            /* Check rows, columns, and diagonals, if the current player's symbol is located
             * in all locations of any boolean, winner winner chicken dinner
             */
            bool row1 = Board.gameBoard[0, 0] == symbol && Board.gameBoard[0, 1] == symbol && Board.gameBoard[0, 2] == symbol;
            bool row2 = Board.gameBoard[1, 0] == symbol && Board.gameBoard[1, 1] == symbol && Board.gameBoard[1, 2] == symbol;
            bool row3 = Board.gameBoard[2, 0] == symbol && Board.gameBoard[2, 1] == symbol && Board.gameBoard[2, 2] == symbol;
            bool col1 = Board.gameBoard[0, 0] == symbol && Board.gameBoard[1, 0] == symbol && Board.gameBoard[2, 0] == symbol;
            bool col2 = Board.gameBoard[0, 1] == symbol && Board.gameBoard[1, 1] == symbol && Board.gameBoard[2, 1] == symbol;
            bool col3 = Board.gameBoard[0, 2] == symbol && Board.gameBoard[1, 2] == symbol && Board.gameBoard[2, 2] == symbol;
            bool diag1 = Board.gameBoard[0, 0] == symbol && Board.gameBoard[1, 1] == symbol && Board.gameBoard[2, 2] == symbol;
            bool diag2 = Board.gameBoard[0, 2] == symbol && Board.gameBoard[1, 1] == symbol && Board.gameBoard[2, 0] == symbol;

            /* If any bool is true, hasWon is assigned a value of true, winner winner chicken dinner
             */ 
            if (row1 || row2 || row3 || col1 || col2 || col3 || diag1 || diag2)
            {
                hasWon = true;
            }

            return hasWon;
        }

    }
}