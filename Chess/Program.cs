using Game;
using BoardNS;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Match match = new Match();

                while (!match.IsFinished)
                {
                    Console.Clear();
                    Display.PrintBoard(match.Board);

                    Console.WriteLine("Origem: ");
                    Position initialPosition = Display.ReadPosition().ToPosition();

                    Console.WriteLine("Destino: ");
                    Position destinyPosition = Display.ReadPosition().ToPosition();

                    match.ExecuteMoviment(initialPosition, destinyPosition);

                }


            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}