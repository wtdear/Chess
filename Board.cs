using System;

namespace ConsoleChess
{
    public class Board
    {
        private Piece[,] grid;

        public Board()
        {
            grid = new Piece[8, 8];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    grid[i, j] = new Piece(PieceType.None, PieceColor.None);

            for (int i = 0; i < 8; i++)
            {
                grid[1, i] = new Piece(PieceType.Pawn, PieceColor.Black);
                grid[6, i] = new Piece(PieceType.Pawn, PieceColor.White);
            }

            // Black
            grid[0, 0] = new Piece(PieceType.Rook, PieceColor.Black);
            grid[0, 1] = new Piece(PieceType.Knight, PieceColor.Black);
            grid[0, 2] = new Piece(PieceType.Bishop, PieceColor.Black);
            grid[0, 3] = new Piece(PieceType.Queen, PieceColor.Black);
            grid[0, 4] = new Piece(PieceType.King, PieceColor.Black);
            grid[0, 5] = new Piece(PieceType.Bishop, PieceColor.Black);
            grid[0, 6] = new Piece(PieceType.Knight, PieceColor.Black);
            grid[0, 7] = new Piece(PieceType.Rook, PieceColor.Black);

            // White
            grid[7, 0] = new Piece(PieceType.Rook, PieceColor.White);
            grid[7, 1] = new Piece(PieceType.Knight, PieceColor.White);
            grid[7, 2] = new Piece(PieceType.Bishop, PieceColor.White);
            grid[7, 3] = new Piece(PieceType.Queen, PieceColor.White);
            grid[7, 4] = new Piece(PieceType.King, PieceColor.White);
            grid[7, 5] = new Piece(PieceType.Bishop, PieceColor.White);
            grid[7, 6] = new Piece(PieceType.Knight, PieceColor.White);
            grid[7, 7] = new Piece(PieceType.Rook, PieceColor.White);
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine("   a b c d e f g h");
            Console.WriteLine("  -----------------");

            for (int row = 0; row < 8; row++)
            {
                Console.Write($"{8 - row} |");
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(grid[row, col].GetSymbol() + " ");
                }
                Console.WriteLine($"| {8 - row}");
            }
            Console.WriteLine("  -----------------");
            Console.WriteLine("   a b c d e f g h\n");
        }

        public bool MovePiece(int startRow, int startCol, int endRow, int endCol)
        {
            if (startRow < 0 || startRow > 7 || startCol < 0 || startCol > 7 ||
                endRow < 0 || endRow > 7 || endCol < 0 || endCol > 7)
            {
                return false;
            }

            Piece piece = grid[startRow, startCol];
            if (piece.Type == PieceType.None) return false;

            grid[endRow, endCol] = piece;
            grid[startRow, startCol] = new Piece(PieceType.None, PieceColor.None);

            return true;
        }

        public Piece GetPiece(int row, int col)
        {
            return grid[row, col];
        }
    }
}