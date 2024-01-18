

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
        public void DecrementNumberOfTimesMoved()
        {
            NumberOfTimesMoved--;
        }

        protected bool PositionIsFree(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }

        public bool CanMoveTo(Position position)
        {
            return AllowedMovements()[position.Row, position.Column];
        }

        public bool HasAllowedMovements()
        {
            bool[,] matrix = AllowedMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public abstract bool[,] AllowedMovements();

    }
}
