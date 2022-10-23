namespace Minefield.core
{
    public interface IMineService
    {
        void CreateMines(int numberOfMines);

        bool IsMineAtLocation(BoardLocation boardLocation);
    }
}