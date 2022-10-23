namespace Minefield.core
{
    public class NavigationService : INavigationService
    {
        public int NumberOfMoves { get; private set; } = 0;

        public int GetPlayersMove()
        {
            Console.WriteLine(Messages.NavigateArrowKeys);

            var consoleKeyInfo = Console.ReadKey();

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.DownArrow: { NumberOfMoves++; return 1; }
                case ConsoleKey.UpArrow: { NumberOfMoves++; return 2; }
                case ConsoleKey.RightArrow: { NumberOfMoves++; return 3; }
                case ConsoleKey.LeftArrow: { NumberOfMoves++; return 4; }
                default: return 0;
            }
        }
    }
}