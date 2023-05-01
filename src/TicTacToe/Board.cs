using System;

namespace TicTacToe
{

    /* The Board class contains methods for 
     * displaying the game menu and game board
     */
    public static class Board
    {
        
        public static string[,] gameBoard = new string[3, 3];

        /* The Menu method displays the initial program's option
         */
        public static void Menu()
        {

            Helpers.Print("Welcome to Tic-Tac-Toe!\n\n1. Start New Game\n2. Exit\n\nEnter your choice: ");
            string menuChoice = Console.ReadLine();

            // Show menu
            while (menuChoice != "2")
            {
                switch (menuChoice)
                {
                    case "1": // Starts a new game if user enters 1
                        Game.StartNewGame();
                        Stats.gameCount++; // Increment game count with each game played
                        break;
                    case "2": // Exits program if user enters 2
                        Game.ExitProgram();
                        break;
                    default: // Asks user to enter a valid input
                        Console.Clear(); // Clear console each time to keep things tidy
                        Helpers.Print("Invalid choice. Please enter 1 or 2.");
                        break;
                }
                Helpers.Print("\n1. Start New Game\n2. Exit\n\nEnter your choice: ");
                menuChoice = Console.ReadLine();
            }
        }

        /* The InitBoard method initializes the game board as an empty board
         */
        public static void InitBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = " ";
                }
            }
        }

        /* The PrintBoard method display the game board with the current array values
         */
        public static void PrintBoard()
        {
            Console.Clear(); // Clear console each time to keep things tidy
            Helpers.Print("\n   1   2   3 ");
            Helpers.Print("\n 1 " + gameBoard[0, 0] + " | " + gameBoard[0, 1] + " | " + gameBoard[0, 2]);
            Helpers.Print("\n  ---|---|---");
            Helpers.Print("\n 2 " + gameBoard[1, 0] + " | " + gameBoard[1, 1] + " | " + gameBoard[1, 2]);
            Helpers.Print("\n  ---|---|---");
            Helpers.Print("\n 3 " + gameBoard[2, 0] + " | " + gameBoard[2, 1] + " | " + gameBoard[2, 2] + "\n");
            Helpers.Print("\nSystem symbol: " + Player.systemSymbol.ToUpper());
            Helpers.Print("\nYour symbol: " + Player.userSymbol.ToUpper());
            Helpers.Print("\n");
        }

        /* The BoardGuide method displays the game board with a starting message
         */
        public static void BoardGuide()
        {
            Console.Clear(); // Clear console each time to keep things tidy
            Helpers.Print("Starting game...\n\nBoard coordinates");
            Helpers.Print("\n   1   2   3 ");
            Helpers.Print("\n 1 " + gameBoard[0, 0] + " | " + gameBoard[0, 1] + " | " + gameBoard[0, 2]);
            Helpers.Print("\n  ---|---|---");
            Helpers.Print("\n 2 " + gameBoard[1, 0] + " | " + gameBoard[1, 1] + " | " + gameBoard[1, 2]);
            Helpers.Print("\n  ---|---|---");
            Helpers.Print("\n 3 " + gameBoard[2, 0] + " | " + gameBoard[2, 1] + " | " + gameBoard[2, 2] + "\n");
            Helpers.Print("\nSystem symbol: " + Player.systemSymbol.ToUpper());
            Helpers.Print("\nYour symbol: " + Player.userSymbol.ToUpper());
            Helpers.Print("\n");
        }
    }
}