using System;


namespace TicTacToe
{

    /* The Players class contains methods for determining
     * whether the user will go first and which symbol they choose
     */
    public class Player
    {
        public static string userSymbol = "x";
        public static string systemSymbol = "o";
        public static string userGoesFirst = "";

        /* The GetUserGoesFirstChoice method asks the user if they want to go first
         * and returns that string value
         */
        public static string GetUserGoesFirstChoice()
        {
            Console.Clear(); // Clear console each time to keep things tidy
            Helpers.Print("Do you want to go first?\nYes or No\n\nEnter Q to exit\n\nEnter your choice: ");
            string choice = Console.ReadLine().ToLower();

            // Asks user to enter valid input
            while (choice != "yes" && choice != "y" && choice != "no" && choice != "n")
            {
                Console.Clear(); // Clear console each time to keep things tidy
                Helpers.Print("Invalid choice. Please enter Yes or No.\n\nEnter your choice: ");
                Helpers.Print("\nDo you want to go first?\nYes or No\n\nEnter Q to exit\n\nEnter your choice: ");
                
                Helpers.CheckForQuit(choice); // Check if the user entered Q to exit

                choice = Console.ReadLine().ToLower();
            }
            return (choice);
        }

        /* The GetUserSymbolChoice method asks the user what symbol they want
         * and returns that string value
         */
        public static string GetUserSymbolChoice()
        {
            Console.Clear(); // Clear console each time to keep things tidy
            Helpers.Print("Which symbol do you want to use?\nEnter X or O\n\nEnter Q to exit\n\nEnter your choice: ");
            string choice = Console.ReadLine().ToLower();

            // Asks user to enter valid input
            while (choice != "x" && choice != "o")
            {
                Console.Clear(); // Clear console each time to keep things tidy
                Helpers.Print("Invalid choice. Please enter X or O.\n\nEnter your choice: ");
                Helpers.Print("\nWhich symbol do you want to use?\nEnter X or O\n\nEnter Q to exit\n\nEnter your choice: ");
           
                Helpers.CheckForQuit(choice); // Check if the user entered Q to exit

                choice = Console.ReadLine().ToLower();
            }
            return (choice == "x") ? "x" : "o";
        }
    }
}
