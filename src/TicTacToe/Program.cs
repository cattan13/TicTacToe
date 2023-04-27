using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        // Variables
        private static string[,] gameBoard = new string[3, 3];
        private static string userSymbol = "x";
        private static string systemSymbol = "o";
        private static string userGoesFirst = "";
        private static DateTime gameTime;
        private static DateTime appTime;
        private static List<TimeSpan> gameDurations = new List<TimeSpan>();


        static void Main(string[] args)
        {
            int gameCount = 0; // Initialize game count variable

            // Record start time
            appTime = DateTime.Now;

            // Main menu
            Print("Welcome to Tic-Tac-Toe!\n\n1. Start New Game\n2. Exit\n\nEnter your choice: ");
            string menuChoice = Console.ReadLine();

            while (menuChoice != "2") // Exit program
            {
                switch (menuChoice)
                {
                    case "1":
                        StartNewGame();
                        gameCount++; // Increment game count
                        break;
                    case "2":
                        // Exit program
                        ExitProgram();
                        break;
                    default:
                        Print("Invalid choice. Please enter 1 or 2.");
                        break;
                }

                Print("\n1. Start New Game\n2. Exit\n\nEnter your choice: ");
                menuChoice = Console.ReadLine();
            }

            // Calculate average game duration
            TimeSpan avgDuration = TimeSpan.Zero;
            if (gameDurations.Count > 0)
            {
                avgDuration = new TimeSpan(gameDurations.Sum(t => t.Ticks) / gameDurations.Count);
            }
            TimeSpan appduration = DateTime.Now - appTime;

            // Print results
            Print("\nTotal application run time: " + appduration.ToString(@"mm\:ss"));
            Print("\nAverage game run time: " + avgDuration.ToString(@"mm\:ss"));
            Print("\nTotal number of games played: " + gameCount);// Print game count
            Print("\nPress any key to exit Tic-Tac-Toe");
            Console.ReadKey();
        }

        private static void ExitProgram()
        {
            Print("Exiting Tic-Tac-Toe...");
            Environment.Exit(0);
        }

        private static void StartNewGame()
        {
            userGoesFirst = GetUserGoesFirstChoice();
            userSymbol = GetUserSymbolChoice();
            systemSymbol = (userSymbol == "x") ? "o" : "x";
            InitializeBoard();
            PlayGame();
        }

        private static string GetUserGoesFirstChoice() // Ask user if they want to go first
        {
            Print("Do you want to go first?\nYes or No\n\nEnter your choice: ");
            string choice = Console.ReadLine().ToLower();
            while (choice != "yes" && choice != "y" && choice != "no" && choice != "n")
            {
                Print("Invalid choice. Please enter Yes or No.\n\nEnter your choice: ");
                choice = Console.ReadLine().ToLower();
            }
            return (choice);
        }

        private static string GetUserSymbolChoice() // Ask user which symbol they want to use
        {
            Print("Which symbol do you want to use?\nEnter X or O\n\nEnter your choice: ");
            string choice = Console.ReadLine().ToLower();
            while (choice != "x" && choice != "o")
            {
                Print("Invalid choice. Please enter X or O.\n\nEnter your choice: ");
                choice = Console.ReadLine().ToLower();
            }
            return (choice == "x") ? "x" : "o";
        }

        private static void InitializeBoard() // Initalize game board
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = " ";
                }
            }
        }

        private static void PlayGame()
        {
            Print("Starting game...\n\nBoard coordinates");
            Print("\nYour symbol: " + userSymbol.ToUpper());
            Print("\n   1   2   3 ");
            Print("\n 1 " + gameBoard[0, 0] + " | " + gameBoard[0, 1] + " | " + gameBoard[0, 2]);
            Print("\n  ---|---|---");
            Print("\n 2 " + gameBoard[1, 0] + " | " + gameBoard[1, 1] + " | " + gameBoard[1, 2]);
            Print("\n  ---|---|---");
            Print("\n 3 " + gameBoard[2, 0] + " | " + gameBoard[2, 1] + " | " + gameBoard[2, 2] + "\n");
            Print("\nSystem symbol: " + systemSymbol.ToUpper());

            // Record start time
            gameTime = DateTime.Now;

            bool gameOver = false;
            string currentPlayer = userGoesFirst;

            while (!gameOver) // Gameplay
            {
                if (currentPlayer == "yes" || currentPlayer == "y") // This is the program user
                {
                    Print("\nYour turn.\nEnter row and column numbers separated by a space (e.g. 1 2): ");

                    string[] input = Console.ReadLine().Split();
                    int row, column;

                    // Check if the input is valid
                    if (!int.TryParse(input[0], out row) || !int.TryParse(input[1], out column))
                    {
                        Print("Invalid input. Please enter two integers separated by a space.\n");
                        continue;
                    }

                    // Convert row and column to zero-based indexing
                    row--;
                    column--;

                    // Check if the move is valid
                    if (row < 0 || row > 2 || column < 0 || column > 2)
                    {
                        Print("Invalid move. Please enter values between 1 and 3.\n");
                        continue;
                    }
                    if (gameBoard[row, column] != " ")
                    {
                        Print("That space is already occupied. Please select a different space.\n");
                        continue;
                    }

                    gameBoard[row, column] = userSymbol;
                    currentPlayer = "system";
                }
                else // This is the system player
                {
                    Print("\nSystem's turn.\n");

                    // Check if the system can win
                    if (CheckForWin(systemSymbol))
                    {
                        Print("System wins!");
                        gameOver = true;
                        continue;
                    }

                    // Check if the user can win and block
                    if (CheckForWin(userSymbol))
                    {
                        Print("System blocks!");
                    }
                    else
                    {
                        // Choose a random empty spot on the board
                        Random random = new Random();
                        int row = random.Next(0, 3);
                        int column = random.Next(0, 3);
                        while (gameBoard[row, column] != " ")
                        {
                            row = random.Next(0, 3);
                            column = random.Next(0, 3);
                        }
                        gameBoard[row, column] = systemSymbol;
                    }

                    // Check if the game is a tie
                    if (CheckForTie())
                    {
                        Print("It's a tie!");
                        gameOver = true;
                        continue;
                    }

                    currentPlayer = "yes";
                }

                // Print the updated board
                PrintBoard();

                // Check if the game has been won
                if (CheckForWin(userSymbol))
                {
                    Print("You win!");
                    gameOver = true;
                }
                else if (CheckForWin(systemSymbol))
                {
                    Print("System wins!");
                    gameOver = true;
                }
                else if (CheckForTie())
                {
                    Print("It's a tie!");
                    gameOver = true;
                }

            }

            // Record end time
            TimeSpan duration = DateTime.Now - gameTime;

            // Add duration to list
            gameDurations.Add(duration);


            // Print the game duration
            TimeSpan gduration = DateTime.Now - gameTime;
            Print("\nGame duration: " + gduration.ToString(@"mm\:ss"));
        }

        private static bool CheckForWin(string symbol) // Check if someone has won
        {
            bool hasWon = false;

            // Check rows and columns
            bool row1 = gameBoard[0, 0] == symbol && gameBoard[0, 1] == symbol && gameBoard[0, 2] == symbol;
            bool row2 = gameBoard[1, 0] == symbol && gameBoard[1, 1] == symbol && gameBoard[1, 2] == symbol;
            bool row3 = gameBoard[2, 0] == symbol && gameBoard[2, 1] == symbol && gameBoard[2, 2] == symbol;
            bool col1 = gameBoard[0, 0] == symbol && gameBoard[1, 0] == symbol && gameBoard[2, 0] == symbol;
            bool col2 = gameBoard[0, 1] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 1] == symbol;
            bool col3 = gameBoard[0, 2] == symbol && gameBoard[1, 2] == symbol && gameBoard[2, 2] == symbol;

            if (row1 || row2 || row3 || col1 || col2 || col3)
            {
                hasWon = true;
            }

            // Check diagonals
            bool diagonal1 = gameBoard[0, 0] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 2] == symbol;
            bool diagonal2 = gameBoard[0, 2] == symbol && gameBoard[1, 1] == symbol && gameBoard[2, 0] == symbol;

            if (diagonal1 || diagonal2)
            {
                hasWon = true;
            }

            return hasWon;
        }

        private static bool CheckForTie() // Check if the game is a tie
        {
            // Check if rows are empty
            for (int i = 0; i < 3; i++)
            {
                // Check if columns are empty
                for (int j = 0; j < 3; j++)
                {
                    // Empty spot found if equal to " "
                    if (gameBoard[i, j] == " ")
                    {
                        // Empty spot found, game is not a tie
                        return false;
                    }
                }
            }

            // No empty spots found, game is a tie
            return true;
        }

        private static void PrintBoard()
        {
            Print("\n   1   2   3 ");
            Print("\n 1 " + gameBoard[0, 0] + " | " + gameBoard[0, 1] + " | " + gameBoard[0, 2]);
            Print("\n  ---|---|---");
            Print("\n 2 " + gameBoard[1, 0] + " | " + gameBoard[1, 1] + " | " + gameBoard[1, 2]);
            Print("\n  ---|---|---");
            Print("\n 3 " + gameBoard[2, 0] + " | " + gameBoard[2, 1] + " | " + gameBoard[2, 2] + "\n");
        }

        private static void Print(string message) // Print a message to the console
        {
            Console.Write(message);
        }
    }
}