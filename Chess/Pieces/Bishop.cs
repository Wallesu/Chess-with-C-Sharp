using BoardNS;

namespace Pieces
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] AllowedMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //NW
            position.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if(Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column - 1);
            }

            //NE
            position.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column + 1);
            }

            //SE
            position.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column + 1);
            }

            //SW
            position.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column - 1);
            }

            return matrix;
        }
    }
}
