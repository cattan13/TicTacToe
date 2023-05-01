using System;

namespace TicTacToe
{
    /* The Helpers class contains helper methods
     * used throuhgout the program
     */
    public static class Helpers
    {

        /* The Print method is unecessary and performs the same function as Console.Write
         */
        public static void Print(string message)
        {
            Console.Write(message);
        }

        /* The CheckForQuit method passes the user's input
         * ARRAY of string values and returns a boolean value that
         * allows the user to exit the game at any point by entering q or Q
         */
        public static bool CheckForQuit(string[] input)
        {
            foreach (string str in input)
            {
                if (str.ToLower() == "q")
                {
                    Environment.Exit(0);
                }
            }
            return false;
        }

        /* The CheckForQuit method passes the user's input
         * SINGLE string value and returns a boolean value that
         * allows the user to exit the game at any point by entering q or Q
         */
        public static bool CheckForQuit(string input)
        {
            if (input.ToLower() == "q")
            {
                Environment.Exit(0);
            }
            return false;
        }

    }
}