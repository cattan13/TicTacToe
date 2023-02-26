using System;

namespace TicTacToe
{
    class Program
    {
        // Variables
        private static string[,] gameBoard = new string[3, 3];
        private static string userSymbol = "x";
        private static string systemSymbol = "o";
        private static string userGoesFirst = "";
        private static DateTime startTime;
        static void Main(string[] args)
        {
            // Main menu
            Console.WriteLine("\n" +
                "Welcome to Tic-Tac-Toe!\n" +
                "\n" +
                "1. Start New Game\n" +
                "2. Exit\n" +
                "\n" +
                "Enter your choice: ");
            string menuChoice = Console.ReadLine();

            while (menuChoice != "2") // Exit program
            {
                switch (menuChoice)
                {
                    case "1":
                        StartNewGame();
                        break;
                    default:
                        Console.WriteLine("\n" +
                            "Invalid choice. Please enter 1 or 2."); // If user enters anything besides 1 or 2
                        break;
                }

                
                Console.WriteLine("\n" +
                    "1. Start New Game\n" +
                    "2. Exit\n" +
                    "\n" +
                    "Enter your choice: ");
                menuChoice = Console.ReadLine();
            }
            Console.WriteLine("\n" +
                "Exiting Tic-Tac-Toe...");
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
            Console.WriteLine("\n" +
                "Do you want to go first?\n" +
                "Yes or No\n" +
                "\n" +
                "Enter your choice: ");
            string choice = Console.ReadLine().ToLower();
            while (choice != "yes" && choice != "y" && choice != "no" && choice != "n")
            {
                Console.WriteLine("\n" +
                    "Invalid choice. Please enter Yes or No.\n" +
                    "\n" +
                    "Enter your choice: ");
                choice = Console.ReadLine().ToLower();
            }
            return (choice);
        }

        private static string GetUserSymbolChoice() // Ask user which symbol they want to use
        {
            Console.WriteLine("\n" +
                "Which symbol do you want to use?\n" +
                "Enter X or O\n" +
                "\n" +
                "Enter your choice: ");
            string choice = Console.ReadLine().ToLower();
            while (choice != "x" && choice != "o")
            {
                Console.WriteLine("\n" +
                    "Invalid choice. Please enter X or O.\n" +
                    "\n" +
                    "Enter your choice: ");
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

        private static void PlayGame() // Start game
        {
            Console.WriteLine("\n" +
                "Starting game...\n" +
                "\n" +
                "Board coordinates\n" +
                "\n" +
                "1 1|1 2|1 3\n" +
                "---|---|---\n" +
                "2 1|2 2|2 3\n" +
                "---|---|---\n" +
                "3 1|3 2|3 3\n" +
                "\n" +
                "Your symbol: " + userSymbol.ToUpper());
            Console.WriteLine("\n" +
                "System symbol: " + systemSymbol.ToUpper());

            startTime = DateTime.Now;
            bool gameOver = false;
            string currentPlayer = userGoesFirst;

            while (!gameOver) // Gameplay
            {
                if (currentPlayer == "yes" || currentPlayer == "y") // This is the program user
                {
                    Console.WriteLine("\n" + 
                    "Your turn.\n" +
                    "Enter row and column (ex. 2 2 for center cell): ");
                    string userMove = Console.ReadLine();
                    int row = int.Parse(userMove[0].ToString()) - 1;
                    int col = int.Parse(userMove[2].ToString()) - 1;
                    while (gameBoard[row, col] != " ")
                    {
                        Console.WriteLine("\n" +
                            "Cell already filled. Enter another move: ");
                        userMove = Console.ReadLine();
                        row = int.Parse(userMove[0].ToString()) - 1;
                        col = int.Parse(userMove[2].ToString()) - 1;
                    }
                    gameBoard[row, col] = userSymbol.ToUpper();
                    currentPlayer = "no";
                }

                else
                {
                    Console.WriteLine("\n" +
                        "System's turn.");
                    int row = new Random().Next(0, 3);
                    int col = new Random().Next(0, 3);
                    while (gameBoard[row, col] != " ")
                    {
                        row = new Random().Next(0, 3);
                        col = new Random().Next(0, 3);
                    }
                    gameBoard[row, col] = systemSymbol.ToUpper();
                    DisplayBoard();
                    currentPlayer = "yes";
                }
            }
        }
        private static void DisplayBoard() // Display game board
        {
            Console.WriteLine("\n" +
            " {0} | {1} | {2} ", gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2]);
            Console.WriteLine("---|---|---\n" +
            " {0} | {1} | {2} ", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
            Console.WriteLine("---|---|---\n" +
            " {0} | {1} | {2} \n", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
            Console.WriteLine();
        }
    }
}