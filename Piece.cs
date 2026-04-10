namespace ConsoleChess
{
    public class Piece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }

        public Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }

        public char GetSymbol()
        {
            if (Color == PieceColor.White)
            {
                return Type switch
                {
                    PieceType.King => '♔',
                    PieceType.Queen => '♕',
                    PieceType.Rook => '♖',
                    PieceType.Bishop => '♗',
                    PieceType.Knight => '♘',
                    PieceType.Pawn => '♙',
                    _ => '.'
                };
            }
            else if (Color == PieceColor.Black)
            {
                return Type switch
                {
                    PieceType.King => '♚',
                    PieceType.Queen => '♛',
                    PieceType.Rook => '♜',
                    PieceType.Bishop => '♝',
                    PieceType.Knight => '♞',
                    PieceType.Pawn => '♟',
                    _ => '.'
                };
            }
            return '.';
        }
    }
}