using Game;
using BoardNS;
using BoardNS.Exceptions;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Match match = new Match();

            while (!match.IsFinished)
            {
                try
                {
                    Console.Clear();
                    Display.PrintBoard(match.Board);
                    Console.WriteLine();
                    Console.WriteLine("Round: " + match.Round);
                    Console.WriteLine("Waiting for move: " + match.CurrentPlayer);

                    Console.WriteLine();
                    Console.Write("Origem: ", match.Round);
                    Position initialPosition = Display.ReadPosition().ToPosition();

                    match.ValidateInitialPosition(initialPosition);

                    bool[,] allowedPositionsToPieceMove = match.Board.GetPiece(initialPosition).AllowedMovements();

                    Console.Clear();
                    Display.PrintBoard(match.Board, allowedPositionsToPieceMove);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destinyPosition = Display.ReadPosition().ToPosition();
                    match.ValidateDestinyPosition(initialPosition, destinyPosition);

                    match.ExecuteMoviment(initialPosition, destinyPosition);
                } catch (BoardException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                    

            }


            
        }
    }
}