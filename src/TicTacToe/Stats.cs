using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{

    /* The Stats class contains methods related to capturing game statistics
     */
    public static class Stats
    {
        public static int gameCount = 0; // Initialize game count variable
        public static DateTime gameTime;
        public static DateTime appTime;
        public static List<TimeSpan> gameDurations = new List<TimeSpan>();

        /* The AppStart method starts the timer for total program run time
         */
        public static void AppStart()
        {
            // Record start time
            appTime = DateTime.Now;
        }

        /* The GameStart method starts the timer for game duration
         */
        public static void GameStart()
        {
            // Record start time
            gameTime = DateTime.Now;
        }

        /* The GameDuration method calculates and displays the 
         * game duration and adds it to the averaging list
         */
        public static void GameDuration()
        {
            // Record game end time
            TimeSpan duration = DateTime.Now - gameTime;

            // Add game duration to list
            gameDurations.Add(duration);

            // Display game duration
            TimeSpan gduration = DateTime.Now - gameTime;
            Helpers.Print("\nGame duration: " + gduration.ToString(@"mm\:ss"));
        }

        /* The Summary method calculates and displays game statistics
         */
        public static void Summary()
        {
            TimeSpan avgDuration = TimeSpan.Zero;

            // Averages game times if any game has been played
            if (gameDurations.Count > 0)
            {
                avgDuration = new TimeSpan(gameDurations.Sum(t => t.Ticks) / gameDurations.Count);
            }
            TimeSpan appduration = DateTime.Now - appTime;

            Console.Clear(); // Clear console each time to keep things tidy
            Helpers.Print("\nTotal application run time: " + appduration.ToString(@"mm\:ss"));
            Helpers.Print("\nAverage game duration: " + avgDuration.ToString(@"mm\:ss"));
            Helpers.Print("\nTotal number of games played: " + gameCount);
            Helpers.Print("\nPress any key to exit Tic-Tac-Toe");
            Console.ReadKey();
        }
    }
}