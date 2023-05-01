namespace TicTacToe
{

    /* The Program class is the class which starts
     * the application timer, runs the game cycle
     * and then gracefully exits the program after
     * showing a summary of game statistics.
     */
    class Program
    {

        /* The Main method calls three methods which
         * run through the game's cycles
         */
        static void Main()
        {
                      
            Stats.AppStart(); // Start program time 
                       
            Board.Menu(); // Game cycle
                     
            Stats.Summary(); // Summary of game stats 
            
        }
    }
}