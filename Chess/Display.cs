using BoardNS;
using Game;
using Pieces;

namespace Chess
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintMatch(Match match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Round: " + match.Round);
            Console.WriteLine("Waiting for move: " + match.CurrentPlayer);
        }

        public static void PrintBoard(Board board, bool[,] allowedPositionsToPieceMove)
        {
            ConsoleColor currentBackgroundColor = Console.BackgroundColor;
            ConsoleColor modifiedBackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (allowedPositionsToPieceMove[i, j])
                    {
                        Console.BackgroundColor = modifiedBackgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = currentBackgroundColor;
                    }
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = currentBackgroundColor;
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintCapturedPieces(Match match)
        {
            Console.WriteLine(" -=-=- Captured pieces -=-=- ");
            Console.Write("Whites: ");
            PrintListOfPieces(match.CapturedPiecesOfColor(Color.White));
            Console.WriteLine();

            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Blacks: ");
            PrintListOfPieces(match.CapturedPiecesOfColor(Color.Black));

            Console.ForegroundColor = currentColor;
        }

        public static void PrintListOfPieces(HashSet<Piece> list)
        {
            Console.Write("[");
            foreach (Piece piece in list)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
        public static void PrintPiece(Piece piece)
        {
            if(piece == null) Console.Write("- ");
            else
            {
                if (piece.Color == Color.Black)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                else Console.Write(piece);

                Console.Write(" ");
            }
        }

        public static BoardPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1].ToString());
            return new BoardPosition(column, row);
        }

    }
}
