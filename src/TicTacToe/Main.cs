using System;

namespace TicTacToe
{
    class Program
    {
        // Variables
        private static string[,] gameBoard = new string[3, 3];
        private static string userSymbol = "X";
        private static string systemSymbol = "O";
        private static int userGoesFirst = 0;
        private static DateTime startTime;
        static void Main(string[] args)
        {
            // Main menu
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            Console.WriteLine();
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            string menuChoice = Console.ReadLine();

            while (menuChoice != "2") // Exit program
            {
                switch (menuChoice)
                {
                    case "1":
                        StartNewGame();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2."); // If user enters anything besides 1 or 2
                        break;
                }

                
                Console.WriteLine();
                Console.WriteLine("1. Start New Game");
                Console.WriteLine("2. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                menuChoice = Console.ReadLine();
            }
            Console.WriteLine("Exiting Tic-Tac-Toe...");
        }

        private static void StartNewGame()
        {
            userGoesFirst = GetUserGoesFirstChoice();
            userSymbol = GetUserSymbolChoice();
            systemSymbol = (userSymbol == "X") ? "O" : "X";
            InitializeBoard();
            PlayGame();
        }

        private static int GetUserGoesFirstChoice() // Ask user if they want to go first
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to go first?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
            }
            return int.Parse(choice);
        }

        private static string GetUserSymbolChoice() // Ask user which symbol they want to use
        {
            Console.WriteLine();
            Console.WriteLine("Which symbol do you want to use?");
            Console.WriteLine("1. X");
            Console.WriteLine("2. O");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
            }
            return (choice == "1") ? "X" : "O";
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

        private static void PlayGame() // Start game
        {
            Console.WriteLine();
            Console.WriteLine("Starting game...");
            Console.WriteLine();

            startTime = DateTime.Now;
            bool gameOver = false;
            int currentPlayer = userGoesFirst;

            while (!gameOver) // Gameplay
            {
                if (currentPlayer == 1) // This is the program user
                {
                    Console.WriteLine("Your turn. Enter row and column (ex. 2 2 for center cell): ");
                    string userMove = Console.ReadLine();
                    int row = int.Parse(userMove[0].ToString()) - 1;
                    int col = int.Parse(userMove[2].ToString()) - 1;
                    while (gameBoard[row, col] != " ")
                    {
                        Console.WriteLine("Cell already filled. Enter another move: ");
                        userMove = Console.ReadLine();
                        row = int.Parse(userMove[0].ToString()) - 1;
                        col = int.Parse(userMove[2].ToString()) - 1;
                    }
                    gameBoard[row, col] = userSymbol;
                    currentPlayer = 2;
                }

                else
                {
                    Console.WriteLine("System's turn.");
                    int row = new Random().Next(0, 3);
                    int col = new Random().Next(0, 3);
                    while (gameBoard[row, col] != " ")
                    {
                        row = new Random().Next(0, 3);
                        col = new Random().Next(0, 3);
                    }
                    gameBoard[row, col] = systemSymbol;
                    currentPlayer = 1;
                }
                DisplayBoard();
            }
        }
        private static void DisplayBoard() // Display game board
        {
            Console.WriteLine();
            Console.WriteLine(" {0} | {1} | {2} ", gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
            Console.WriteLine();
        }
    }
}