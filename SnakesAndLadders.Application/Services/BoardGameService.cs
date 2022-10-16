using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Interfaces;

namespace SnakesAndLadders.Application.Services
{
    public class BoardGameService : IBoardGameService
    {
        private const int StartingPosition = 1;
        private readonly IDieService _dieService;
        private readonly Game _game;

        public BoardGameService(IDieService dieService)
        {
            _dieService = dieService;
            _game = new Game();
        }

        public List<Player> GetPlayers()
        {
            return _game.Players;
        }

        public void Start(int numberOfPlayers)
        {
            ThrowExceptionIfGameIsStarted();
            AddStartingPlayers(numberOfPlayers);
        }

        private void AddStartingPlayers(int numberOfPlayers)
        {
            _game.Players = new List<Player>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                AddStartingPlayer(i);
            }
        }

        public int GetTokenPositionOfPlayer(Player player)
        {
            return _game.GetPlayer(player.Number).GetTokenPosition();
        }

        public Player MovePlayerTokenPosition(Player player, int position)
        {
            if(_game.CheckIfIsValidMovement(player, position))
            {
                return _game.GetPlayer(player.Number);
            }
            
            return _game.MovePlayerTokenPosition(player.Number, position);
        }

        public Player GetPlayer(int playerNumber)
        {
            ThrowExceptionIfGameIsStopped();

            return _game.GetPlayer(playerNumber);
        }

        public bool CheckIfThePlayerWonTheGame(Player player)
        {
            return player.Token.Position == _game.Board.GoalSquare;
        }

        public int RollDie()
        {
            return _dieService.Roll();
        }

        public void PlayGameTurn(Player player)
        {
            var number = _dieService.Roll();
            player.MoveTokenPosition(number);
        }

        private void ThrowExceptionIfGameIsStopped()
        {
            if (_game.Players == null || _game.Players.Count == 0)
            {
                throw new ArgumentException("The game is stopped, please start the game before calling other operations");
            }
        }

        private void ThrowExceptionIfGameIsStarted()
        {
            if (_game.Players != null && _game.Players?.Count > 0)
            {
                throw new ArgumentException("The game has already been started, please stop the game before restarting it");
            }
        }

        private void AddStartingPlayer(int i)
        {
            _game.Players.Add(new Player(i, new Token(StartingPosition)));
        }
    }
}
