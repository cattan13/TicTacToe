using System;
using System.Reflection;

namespace TicTacToe
{

    /* The Game class contains the main game cycle
     * methods for starting, playing, and ending a game
     */
    public class Game
    {

        /* The StartNewGame method assigns the user and system symbol,
         * then initializes the board and starts a game
         */
        public static void StartNewGame()
        {
            Player.userGoesFirst = Player.GetUserGoesFirstChoice(); // Ask user if they want to go first
            Player.userSymbol = Player.GetUserSymbolChoice(); // Ask user which symbol they want
            Player.systemSymbol = (Player.userSymbol == "x") ? "o" : "x"; // Assigns the system symbol as the symbol the user did not choose
            Board.InitBoard(); // Initialize game board
            PlayGame(); // Gameplay begins
        }

        /* The PlayGame method displays the board guide 
         * and runs through the main gameplay cycle
         */
        public static void PlayGame()
        {
            Console.Clear(); // Clear console each time to keep things tidy
            Board.BoardGuide(); // Display initial game board guide
            Stats.GameStart(); // Starts recording game time

            bool gameOver = false;
            string currentPlayer = Player.userGoesFirst;

            // Loop will continuously run until one cycle of TicTacToe is won or tied
            while (!gameOver)
            {
                // Display the user's turn options
                if (currentPlayer == "yes" || currentPlayer == "y")
                {
                    Helpers.Print("\nYour turn.\n\nEnter Q to exit\nEnter row and column numbers separated by a space (e.g. 1 2): ");

                    string[] input = Console.ReadLine().Split();
                    int row, column;

                    Helpers.CheckForQuit(input); // Check if the user entered Q to exit, the game may be exited at any time

                    // Check if the input is valid
                    if (input.Length < 2 || !int.TryParse(input[0], out row) || !int.TryParse(input[1], out column))
                    {
                        Board.PrintBoard(); // Displays current game board
                        Helpers.Print("\nInvalid input. Please enter two integers separated by a space.\n");
                        continue;
                    }


                    // Convert row and column to zero-based indexing
                    row--;
                    column--;

                    // Check if the move is valid
                    if (row < 0 || row > 2 || column < 0 || column > 2)
                    {
                        Board.PrintBoard(); // Displays current game board
                        Helpers.Print("\nInvalid move. Please enter values between 1 and 3.\n");
                        continue;
                    }

                    // Check if space is occupied
                    if (Board.gameBoard[row, column] != " ")
                    {
                        Board.PrintBoard(); // Displays current game board
                        Helpers.Print("\nThat space is already occupied. Please select a different space.\n");
                        continue;
                    }

                    Board.gameBoard[row, column] = Player.userSymbol;
                    currentPlayer = "system";
                }

                // System's turn functions
                else
                {

                    // Check if the system can win
                    if (Logic.CheckForWin(Player.systemSymbol))
                    {
                        Board.PrintBoard(); // Displays current game board
                        Helpers.Print("\nSystem wins!");
                        gameOver = true;
                        continue;
                    }

                    // System chooses a random empty spot on the board
                    else
                    {
                        Random random = new Random();
                        int row = random.Next(0, 3);
                        int column = random.Next(0, 3);

                        // Finds empty spot
                        while (Board.gameBoard[row, column] != " ")
                        {
                            row = random.Next(0, 3);
                            column = random.Next(0, 3);
                        }

                        Board.gameBoard[row, column] = Player.systemSymbol;
                    }

                    // Check if the game is a tie
                    if (Logic.CheckForTie())
                    {
                        Board.PrintBoard(); // Displays current game board
                        Helpers.Print("\nIt's a tie!");
                        gameOver = true;
                        continue;
                    }

                    currentPlayer = "yes";
                }

                // Print the updated board
                Board.PrintBoard();

                // Check if the game has been won by user
                if (Logic.CheckForWin(Player.userSymbol))
                {
                    Board.PrintBoard(); // Displays current game board
                    Helpers.Print("\nYou win!");
                    gameOver = true;
                }

                // Check if the game has been won by system
                else if (Logic.CheckForWin(Player.systemSymbol))
                {
                    Board.PrintBoard(); // Displays current game board
                    Helpers.Print("\nSystem wins!");
                    gameOver = true;
                }

                // Check if the game has been tied
                else if (Logic.CheckForTie())
                {
                    Board.PrintBoard(); // Displays current game board
                    Helpers.Print("\nIt's a tie!");
                    gameOver = true;
                }

            }

            Stats.GameDuration(); // Print the game duration
        }

        /* The ExitProgram method displays a farewell message
         */
        public static void ExitProgram()
        {
            Helpers.Print("\nThanks for playing!\n\nExiting Tic-Tac-Toe...");
            Environment.Exit(0);
        }
    }
}
