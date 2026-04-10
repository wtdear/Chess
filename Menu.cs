using System;

namespace ConsoleChess
{
    public class Menu
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Chess
1. Play with friend
2. Play with computer

0. Exit

Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    GameLogic game = new GameLogic();

                    switch (choice)
                    {
                        case 1:
                            game.StartGame(vsBot: false);
                            break;
                        case 2:
                            game.StartGame(vsBot: true);
                            break;
                        case 0:
                            Console.WriteLine("Exit...");
                            return;
                        default:
                            Console.WriteLine("Error. Type anything...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: enter number! Type anything...");
                    Console.ReadKey();
                }
            }
        }
    }
}