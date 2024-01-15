using BoardNS;
using Pieces;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);
                board.SetPiece(new King(board, Color.White), new Position(1, 2));
                board.SetPiece(new Rook(board, Color.White), new Position(3, 2));
                board.SetPiece(new Rook(board, Color.Black), new Position(0, 5));


                Display.PrintBoard(board);

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}