using BoardNS;

namespace Pieces
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool PositionHasEnemy(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }
        private bool PositionIsFree(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        public override bool[,] AllowedMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Row - 1, Position.Column);
                if(Board.PositionIsValid(position) && PositionIsFree(position))
                {
                    matrix[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 2, Position.Column);
                if (Board.PositionIsValid(position) && PositionIsFree(position) && NumberOfTimesMoved == 0)
                {
                    matrix[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.PositionIsValid(position) && PositionHasEnemy(position))
                {
                    matrix[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.PositionIsValid(position) && PositionHasEnemy(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Row + 1, Position.Column);
                if (Board.PositionIsValid(position) && PositionIsFree(position))
                {
                    matrix[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 2, Position.Column);
                if (Board.PositionIsValid(position) && PositionIsFree(position) && NumberOfTimesMoved == 0)
                {
                    matrix[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.PositionIsValid(position) && PositionHasEnemy(position))
                {
                    matrix[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.PositionIsValid(position) && PositionHasEnemy(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }

            return matrix;
        }
    }
}
