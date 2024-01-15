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

        public void SetPiece(Piece piece, Position position)
        {
            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
