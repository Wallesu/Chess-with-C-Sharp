using BoardNS;
using Pieces;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BoardPosition position = new BoardPosition('c', 7);
                Console.WriteLine(position.ToPosition());


            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}