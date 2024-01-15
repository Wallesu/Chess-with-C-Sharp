using BoardNS;

namespace Pieces
{
    class BoardPosition
    {
        public int Row { get; set; }
        public char Column { get; set; }

        public BoardPosition(char column, int row)
        {
            Row = row;
            Column = column;
        }
        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }
        public override string ToString()
        {
            return Row.ToString() + Column.ToString();
        }

    }
}
