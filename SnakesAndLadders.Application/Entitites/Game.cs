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

            var finalPosition = Board.Snakes.Where(x => x.InitialPosition == position).Select(x => x.EndPosition).FirstOrDefault();

            if(finalPosition != 0)
            {
                player.SetTokenPosition(finalPosition);
            }

            return player;
        }

        public bool CheckIfIsValidMovement(Player player, int position)
        {
            var futurePosition = player.GetTokenPosition() + position;

            return futurePosition > Board.GoalSquare;
        }

    }
}
