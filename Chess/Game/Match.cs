using BoardNS;
using Chess;
using Pieces;

namespace Game
{
    class Match
    {
        public Board Board {  get; private set; }
        public bool IsFinished { get; private set; }
        private int _round;
        private Color _currentPlayer;

        public Match()
        {
            Board = new Board(8, 8);
            _round = 1;
            _currentPlayer = Color.White;
            IsFinished = false;

            SetPieces();

            Display.PrintBoard(Board);
        }

        public void ExecuteMoviment(Position initial, Position destiny)
        {
            Piece piece = Board.RemovePiece(initial);
            piece.IncrementNumberOfTimesMoved();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.SetPiece(piece, destiny);
        }

        private void SetPieces()
        {
            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('a', 1).ToPosition());
        }
    }
}
