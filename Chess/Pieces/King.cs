using BoardNS;

namespace Pieces
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
