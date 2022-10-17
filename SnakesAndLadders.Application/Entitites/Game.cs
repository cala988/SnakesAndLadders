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
            var player = GetPlayer(playerNumber);

            player.MoveTokenPosition(position);

            var finalSnakePosition = Board.GetFinalPositionIfSnake(position);
            if (finalSnakePosition != 0)
            {
                player.SetTokenPosition(finalSnakePosition);
            }

            var finalLadderPosition = Board.GetFinalPositionIfLadder(position);
            if (finalLadderPosition != 0)
            {
                player.SetTokenPosition(finalLadderPosition);
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
