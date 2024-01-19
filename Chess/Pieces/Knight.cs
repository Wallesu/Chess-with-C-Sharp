using BoardNS;

namespace Pieces
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] AllowedMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            position.SetValues(Position.Row - 1, Position.Column - 2);
            if(Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row - 2, Position.Column - 1);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.PositionIsValid(position) && PositionIsFreeOrHasEnemy(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            return matrix;
        }
    }
}
