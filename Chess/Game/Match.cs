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

        public Match()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
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
            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('a', 1).ToPosition());
            Board.SetPiece(new King(Board, Color.White), new BoardPosition('e', 1).ToPosition());

            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('d', 1).ToPosition());
            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('d', 2).ToPosition());
            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('e', 2).ToPosition());
            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('f', 2).ToPosition());
            Board.SetPiece(new Rook(Board, Color.White), new BoardPosition('f', 1).ToPosition());


            Board.SetPiece(new Rook(Board, Color.Black), new BoardPosition('a', 8).ToPosition());
            Board.SetPiece(new King(Board, Color.Black), new BoardPosition('e', 8).ToPosition());

        }
    }
}
