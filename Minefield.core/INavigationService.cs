namespace Minefield.core
{
    public interface INavigationService
    {
        int GetPlayersMove();

        int NumberOfMoves { get; }
    }
}