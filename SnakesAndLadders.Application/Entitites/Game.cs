namespace SnakesAndLadders.Application.Entitites
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public Board Board { get; set; } = new Board(100);

        public Player GetPlayer(int playerNumber)
        {
            return Players.First(x => x.Number == playerNumber);
        }

        public Player MovePlayerTokenPosition(int playerNumber, int position)
        {
            var player  = GetPlayer(playerNumber);

            player.MoveTokenPosition(position);

            return player;
        }

    }
}
