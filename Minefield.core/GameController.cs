namespace Minefield.core
{
    public class GameController : IGameController
    {
        private IGameEngine _gameEngine;

        public GameController(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public void Run()
        {
            _gameEngine.Initialise();

            while (_gameEngine.IsGameStillInPlay)
                _gameEngine.Play();

            _gameEngine.GameOver();
        }
    }
}