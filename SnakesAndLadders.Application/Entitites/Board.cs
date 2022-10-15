namespace SnakesAndLadders.Application.Entitites
{
    public class Board
    {
        public Square[] Squares { get; set; }

        public int GoalSquare { get; set; }

        public Board(int numberOfSquares)
        {
            Squares = new Square[numberOfSquares];
            SetGoalSquare();
        }

        private void SetGoalSquare()
        {
            GoalSquare = Squares.Length;
        }
    }
}
