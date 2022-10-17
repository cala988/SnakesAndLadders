namespace SnakesAndLadders.Application.Entitites
{
    public class Board
    {
        public Square[] Squares { get; set; }

        public List<Snake> Snakes { get; set; }

        public int GoalSquare { get; set; }

        public Board(int numberOfSquares)
        {
            Squares = new Square[numberOfSquares];
            SetGoalSquare();
            SetSnakes();
        }

        private void SetSnakes()
        {
            Snakes = new List<Snake>();
            Snakes.Add(new Snake() { InitialPosition = 16, EndPosition = 6});
            Snakes.Add(new Snake() { InitialPosition = 49, EndPosition = 11 });
            Snakes.Add(new Snake() { InitialPosition = 46, EndPosition = 25 });
            Snakes.Add(new Snake() { InitialPosition = 64, EndPosition = 60 });
            Snakes.Add(new Snake() { InitialPosition = 62, EndPosition = 19 });
            Snakes.Add(new Snake() { InitialPosition = 74, EndPosition = 53 });
            Snakes.Add(new Snake() { InitialPosition = 89, EndPosition = 68 });
            Snakes.Add(new Snake() { InitialPosition = 92, EndPosition = 88 });
            Snakes.Add(new Snake() { InitialPosition = 95, EndPosition = 75 });
            Snakes.Add(new Snake() { InitialPosition = 99, EndPosition = 80 });
        }

        private void SetGoalSquare()
        {
            GoalSquare = Squares.Length;
        }
    }
}
