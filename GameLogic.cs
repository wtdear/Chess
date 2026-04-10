using System;

namespace ConsoleChess
{
    public class GameLogic
    {
        private Board board;
        private PieceColor currentTurn;
        private bool isGameOver;

        public void StartGame(bool vsBot)
        {
            board = new Board();
            currentTurn = PieceColor.White;
            isGameOver = false;

            while (!isGameOver)
            {
                board.Draw();
                Console.WriteLine($"Step: {(currentTurn == PieceColor.White ? "White" : "Black")}");

                if (vsBot && currentTurn == PieceColor.Black)
                {
                    MakeBotMove();
                }
                else
                {
                    Console.WriteLine("Enter step (example, e2 e4) or 'exit' for exit:");
                    string input = Console.ReadLine()?.ToLower();

                    if (input == "exit") break;

                    if (!ProcessMove(input))
                    {
                        Console.WriteLine("Некорректный ввод или невозможный ход. Нажмите клавишу...");
                        Console.ReadKey();
                        continue; 
                    }
                }

                currentTurn = currentTurn == PieceColor.White ? PieceColor.Black : PieceColor.White;
            }
        }

        private bool ProcessMove(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 5) return false;

            try
            {
                int startCol = input[0] - 'a';
                int startRow = 8 - int.Parse(input[1].ToString());

                int endCol = input[3] - 'a';
                int endRow = 8 - int.Parse(input[4].ToString());

                Piece selectedPiece = board.GetPiece(startRow, startCol);
                if (selectedPiece.Color != currentTurn) return false;

                return board.MovePiece(startRow, startCol, endRow, endCol);
            }
            catch
            {
                return false;
            }
        }

        private void MakeBotMove()
        {
            Console.WriteLine("Bot thinking...");
            System.Threading.Thread.Sleep(1000);

            Random rnd = new Random();
            bool moved = false;

            while (!moved)
            {
                int startRow = rnd.Next(0, 8);
                int startCol = rnd.Next(0, 8);

                Piece p = board.GetPiece(startRow, startCol);
                if (p.Color == PieceColor.Black)
                {
                    int endRow = startRow + rnd.Next(-1, 2);
                    int endCol = startCol + rnd.Next(-1, 2);

                    moved = board.MovePiece(startRow, startCol, endRow, endCol);
                }
            }
        }
    }
}