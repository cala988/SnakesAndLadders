using SnakesAndLadders.Application.Entitites;

namespace SnakesAndLadders.Application.Interfaces
{
    public interface IBoardGameService
    {
        public void Start(int numberOfPlayers);

        public List<Player> GetPlayers();

        int GetTokenPositionOfPlayer(Player playerNumber);
    }
}
