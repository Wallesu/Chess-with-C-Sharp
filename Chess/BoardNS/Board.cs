using BoardNS.Exceptions;

namespace BoardNS
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] _pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[Rows, Columns];
        }

        public Piece GetPiece(int row, int col)
        {
            return _pieces[row, col];
        }

        public Piece GetPiece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void SetPiece(Piece piece, Position position)
        {
            if(HasPiece(position))
            {
                throw new BoardException("Already exist a piece in this position!");
            }
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
        public bool PositionIsValid(Position position)
        {
            if(position == null) return false;
            if(position.Row < 0 || position.Column < 0) return false;
            if(position.Column >= Columns ||  position.Row >= Rows) return false;
            return true;
        }
        public void ValidatePosition(Position position)
        {
            if (!PositionIsValid(position)) throw new BoardException("Invalid position!");
        }

        public bool HasPiece(Position position)
        {
            ValidatePosition(position);
            if (_pieces[position.Row, position.Column] != null) return true;
            return false;
        }
    }
}
