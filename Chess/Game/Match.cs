using BoardNS;
using Chess;
using Pieces;
using BoardNS.Exceptions;

namespace Game
{
    class Match
    {
        public Board Board {  get; private set; }
        public bool IsFinished { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public HashSet<Piece> Pieces { get; set; }
        public HashSet<Piece> CapturedPieces { get; set; }

        public Match()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            IsFinished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();

            SetPieces();

            Display.PrintBoard(Board);
        }

        public void ExecuteMoviment(Position initial, Position destiny)
        {
            Piece piece = Board.RemovePiece(initial);
            piece.IncrementNumberOfTimesMoved();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.SetPiece(piece, destiny);
            if(capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
        }

        public void ExecutePlay(Position initial, Position destiny)
        {
            ExecuteMoviment(initial, destiny);
            Round++;
            ChangePlayer();
        }

        public void ValidateInitialPosition(Position initial)
        {
            if(Board.GetPiece(initial) == null)
            {
                throw new BoardException("There is no piece in this position!");
            }
            if(CurrentPlayer != Board.GetPiece(initial).Color)
            {
                throw new BoardException("The chosen piece isn't yours!");
            }
            if (!Board.GetPiece(initial).HasAllowedMovements())
            {
                throw new BoardException("There is no allowed movements to the chosen piece!");
            }
        }

        public void ValidateDestinyPosition(Position inicial, Position destiny)
        {
            if (!Board.GetPiece(inicial).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void SetPieces()
        {
            SetPiece('a', 1, new King(Board, Color.White));
            SetPiece('e', 1, new King(Board, Color.White));
            SetPiece('d', 1, new Rook(Board, Color.White));
            SetPiece('d', 2, new Rook(Board, Color.White));
            SetPiece('e', 2, new Rook(Board, Color.White));
            SetPiece('f', 2, new Rook(Board, Color.White));
            SetPiece('f', 1, new Rook(Board, Color.White));
            SetPiece('a', 8, new Rook(Board, Color.Black));
            SetPiece('e', 8, new King(Board, Color.Black));

        }

        private void SetPiece(char column, int row, Piece piece)
        {
            Board.SetPiece(piece, new BoardPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        public HashSet<Piece> CapturedPiecesOfColor(Color color)
        {
            HashSet<Piece> piecesOfGivenColor = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
            {
                if(piece.Color == color)
                {
                    piecesOfGivenColor.Add(piece);
                }
            }
            return piecesOfGivenColor;
        }

        public HashSet<Piece> AvailablePiecesOfColor(Color color)
        {
            HashSet<Piece> piecesOfGivenColor = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    piecesOfGivenColor.Add(piece);
                }
            }
            piecesOfGivenColor.ExceptWith(CapturedPiecesOfColor(color));
            return piecesOfGivenColor;
        }
    }
}
