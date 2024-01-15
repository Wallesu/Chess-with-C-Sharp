using BoardNS;

namespace Chess
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for(int j = 0; j < board.Columns; j++)
                {
                    Console.Write((board.GetPiece(i, j) != null ? board.GetPiece(i, j) + " ":  "- ") + " ");
                }
                Console.WriteLine();
            }
        }


    }
}
