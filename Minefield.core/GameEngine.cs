namespace Minefield.core
{
    public class GameEngine : IGameEngine
    {
        private readonly BoardLocation _playersCurrentBoardLocation;
        private int _numberOfLives;
        private INavigationService _navigationService;
        private IMineService _mineService;

        private bool PlayerReachedOtherSide
        {
            get { return _playersCurrentBoardLocation.ColumnLocation >= 8; }
        }

        private bool PlayerStillHasLives
        {
            get { return _numberOfLives > 0; }
        }

        public bool IsGameStillInPlay
        {
            get { return !PlayerReachedOtherSide && PlayerStillHasLives; }
        }

        public GameEngine(INavigationService navigationService, IMineService mineService)
        {
            _navigationService = navigationService;
            _mineService = mineService;
            _playersCurrentBoardLocation = new BoardLocation(1, 1);
        }

        public void Initialise()
        {
            _mineService.CreateMines(5);
            _numberOfLives = 3;

            Console.WriteLine("Minefield v1.1");
        }

        public void Play()
        {
            var playersMove = _navigationService.GetPlayersMove();
            var outcome = MovePlayer(playersMove);

            Console.WriteLine(outcome);
        }

        public void GameOver()
        {
            if (PlayerReachedOtherSide)
            {
                Console.WriteLine(Messages.PlayerReachedTheOtherSide);
            }

            if (!PlayerStillHasLives)
            {
                Console.WriteLine(Messages.PlayerLostAllLives);
            }

            Console.WriteLine(Messages.PressEnterCloseGame);
            Console.ReadLine();
        }

        private string MovePlayer(int playersMove)
        {
            if (playersMove == 0)
            {
                return Messages.InvalidChoice;
            }

            // down
            if (playersMove == 1)
            {
                if (_playersCurrentBoardLocation.RowLocation == 8)
                {
                    return Messages.EdgeOfTheBoard;
                }

                _playersCurrentBoardLocation.RowLocation++;

                if (_mineService.IsMineAtLocation(_playersCurrentBoardLocation))
                {
                    _numberOfLives--;
                    return Messages.PlayerHitAMine;
                }

                return PlayersCurrentStatusMessage();
            }

            // up
            if (playersMove == 2)
            {
                if (_playersCurrentBoardLocation.RowLocation == 1)
                {
                    return Messages.EdgeOfTheBoard;
                }

                _playersCurrentBoardLocation.RowLocation--;

                if (_mineService.IsMineAtLocation(_playersCurrentBoardLocation))
                {
                    _numberOfLives--;
                    return Messages.PlayerHitAMine;
                }

                return PlayersCurrentStatusMessage();
            }

            // right
            if (playersMove == 3)
            {
                if (_playersCurrentBoardLocation.ColumnLocation == 8)
                {
                    return Messages.EdgeOfTheBoard;
                }

                _playersCurrentBoardLocation.ColumnLocation++;

                if (_mineService.IsMineAtLocation(_playersCurrentBoardLocation))
                {
                    _numberOfLives--;
                    return Messages.PlayerHitAMine;
                }

                return PlayersCurrentStatusMessage();
            }

            // left
            if (playersMove == 4)
            {
                if (_playersCurrentBoardLocation.ColumnLocation == 1)
                {
                    return Messages.EdgeOfTheBoard;
                }

                _playersCurrentBoardLocation.ColumnLocation--;

                if (_mineService.IsMineAtLocation(_playersCurrentBoardLocation))
                {
                    _numberOfLives--;
                    return Messages.PlayerHitAMine;
                }

                return PlayersCurrentStatusMessage();
            }

            return String.Empty;
        }

        private string PlayersCurrentStatusMessage()
        {
            var col = Char.ConvertFromUtf32(_playersCurrentBoardLocation.ColumnLocation + 64);
            return $"Location is {col}{_playersCurrentBoardLocation.RowLocation}, Lives {_numberOfLives} Number of moves {_navigationService.NumberOfMoves}";
        }
    }
}