using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Interfaces;

namespace SnakesAndLadders.Application.Services
{
    public class BoardGameService : IBoardGameService
    {
        private const int StartingProsition = 1;
        private Game _game;

        public BoardGameService()
        {
            _game = new Game();
        }

        public List<Player> GetPlayers()
        {
            return _game.Players;
        }

        public void Start(int numberOfPlayers)
        {
            ThrowExceptionIfGameIsStarted();

            _game.Players = new List<Player>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                _game.Players.Add(
                    new Player() { 
                        Number = i,
                        Token = new Token()
                        {
                            Position = StartingProsition,
                        }
                    }
                );
            }
        }

        private void ThrowExceptionIfGameIsStarted()
        {
            if (_game.Players != null && _game.Players?.Count > 0)
            {
                throw new ArgumentException("The game has already been started, please stop the game before restarting it");
            }
        }
    }
}
