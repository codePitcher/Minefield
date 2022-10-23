namespace Minefield.core
{
    public class MineService : IMineService
    {
        public MineService()
        {
        }

        private List<BoardLocation> _mineLocations = new List<BoardLocation>();

        public void CreateMines(int numberOfMines)
        {
            for (int i = 0; i < numberOfMines; i++)
            {
                var rnd = new Random();
                var columnValue = rnd.Next(1, 8);
                var rowValue = rnd.Next(1, 8);

                _mineLocations.Add(new BoardLocation(columnValue, rowValue));
            }
        }

        public bool IsMineAtLocation(BoardLocation boardLocation)
        {
            return _mineLocations.Any(x => x.ColumnLocation == boardLocation.ColumnLocation && x.RowLocation == boardLocation.RowLocation);
        }
    }
}