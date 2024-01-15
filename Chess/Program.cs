using BoardNS;
using Pieces;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position = new Position(3, 4);
            Position position2 = new Position(3, 6);


            Board board = new Board(8, 8);
            Rook rook = new Rook(board, Color.White);
            King king = new King(board, Color.White);


            board.SetPiece(rook, position);
            board.SetPiece(king, position2);


            Display.PrintBoard(board);
        }
    }
}