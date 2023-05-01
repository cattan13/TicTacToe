internal static class ProgramHelpers
{

    private static void PrintBoard()
    {
        Print("\n   1   2   3 ");
        Print("\n 1 " + gameBoard[0, 0] + " | " + gameBoard[0, 1] + " | " + gameBoard[0, 2]);
        Print("\n  ---|---|---");
        Print("\n 2 " + gameBoard[1, 0] + " | " + gameBoard[1, 1] + " | " + gameBoard[1, 2]);
        Print("\n  ---|---|---");
        Print("\n 3 " + gameBoard[2, 0] + " | " + gameBoard[2, 1] + " | " + gameBoard[2, 2] + "\n");
    }
}