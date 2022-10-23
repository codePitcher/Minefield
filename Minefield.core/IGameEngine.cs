namespace Minefield.core
{
    public interface IGameEngine
    {
        void Initialise();

        void Play();

        void GameOver();

        bool IsGameStillInPlay { get; }
    }
}