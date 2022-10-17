namespace SnakesAndLadders.Application.Entitites
{
    public class Game
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public Board Board { get; set; } = new Board(100);

        public Player GetPlayer(int playerNumber)
        {
            return Players.First(x => x.Number == playerNumber);
        }

        public Player MovePlayerTokenPosition(int playerNumber, int position)
        {
            var player = GetPlayer(playerNumber);

            player.MoveTokenPosition(position);
            
            SetFinalPositionIfIsSnake(position, player);

            SetPositionIfIsLadder(position, player);

            return player;
        }

        public bool CheckIfIsValidMovement(Player player, int position)
        {
            var futurePosition = player.GetTokenPosition() + position;

            return futurePosition > Board.GoalSquare;
        }

        private void SetFinalPositionIfIsSnake(int position, Player player)
        {
            var finalSnakePosition = Board.GetFinalPositionIfSnake(position);
            if (finalSnakePosition != 0)
            {
                player.SetTokenPosition(finalSnakePosition);
            }
        }

        private void SetPositionIfIsLadder(int position, Player player)
        {
            var finalLadderPosition = Board.GetFinalPositionIfLadder(position);
            if (finalLadderPosition != 0)
            {
                player.SetTokenPosition(finalLadderPosition);
            }
        }
    }
}
