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

        public override bool[,] AllowedMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //above
            position.SetValues(Position.Row - 1, Position.Column);
            if(Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //above
            position.SetValues(Position.Row - 1, Position.Column);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //above
            position.SetValues(Position.Row - 1, Position.Column);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //ne
            position.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //right
            position.SetValues(Position.Row, Position.Column + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //se
            position.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //under
            position.SetValues(Position.Row + 1, Position.Column);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //sw
            position.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //left
            position.SetValues(Position.Row, Position.Column - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            //nw
            position.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.PositionIsValid(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            return matrix;
        }
    }
}
