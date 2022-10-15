using SnakesAndLadders.Application.Entitites;

namespace SnakesAndLadders.Application.Interfaces
{
    public interface IBoardGameService
    {
        public void Start(int numberOfPlayers);

        public List<Player> GetPlayers();

        int GetTokenPositionOfPlayer(Player player);

        Player MoveTokenPosition(Player player, int position);

        Player GetPlayer(int playerNumber);

        public bool CheckIfThePlayerWonTheGame(Player player);
    }
}
