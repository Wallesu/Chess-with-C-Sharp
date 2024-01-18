using Game;
using BoardNS;

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
                    Console.Write("Origem: ");
                    Position initialPosition = Display.ReadPosition().ToPosition();

                    bool[,] allowedPositionsToPieceMove = match.Board.GetPiece(initialPosition).AllowedMovements();

                    Console.Clear();
                    Display.PrintBoard(match.Board, allowedPositionsToPieceMove);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destinyPosition = Display.ReadPosition().ToPosition();

                    match.ExecuteMoviment(initialPosition, destinyPosition);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                    

            }


            
        }
    }
}