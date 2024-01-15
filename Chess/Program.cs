using BoardNS;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position;

            position = new Position(3, 4);

            Board board = new Board(8, 8);

            Display.PrintBoard(board);
        }
    }
}