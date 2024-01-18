

namespace BoardNS
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int NumberOfTimesMoved { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfTimesMoved = 0;
        }

        public void IncrementNumberOfTimesMoved()
        {
            NumberOfTimesMoved++;
        }

        protected bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }

        public abstract bool[,] AllowedMovements();

    }
}
