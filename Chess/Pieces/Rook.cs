using BoardNS;

namespace Pieces
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "♜";
        }

        public override bool[,] AllowedMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //above
            position.SetValues(Position.Row - 1, Position.Column);
            while(Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if(Board.GetPiece(position.Row, position.Column) != null)
                {
                    break;
                }
                position.Row--;
            }

            //under
            position.SetValues(Position.Row + 1, Position.Column);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.GetPiece(position.Row, position.Column) != null)
                {
                    break;
                }
                position.Row++;
            }

            //right
            position.SetValues(Position.Row, Position.Column + 1);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.GetPiece(position.Row, position.Column) != null)
                {
                    break;
                }
                position.Column++;
            }

            //left
            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.GetPiece(position.Row, position.Column) != null)
                {
                    break;
                }
                position.Column--;
            }

            return matrix;
        }
    }
}
