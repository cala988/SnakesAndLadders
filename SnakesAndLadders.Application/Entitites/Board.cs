namespace SnakesAndLadders.Application.Entitites
{
    public class Board
    {
        public Square[] Squares { get; set; }

        public List<Snake> Snakes { get; set; }
        public List<Ladder> Ladders { get; set; }

        public int GoalSquare { get; set; }

        public Board(int numberOfSquares)
        {
            Squares = new Square[numberOfSquares];
            SetGoalSquare();
            SetSnakes();
            SetLadders();
        }

        public int GetFinalPositionIfSnake(int position)
        {
            return Snakes.Where(x => x.InitialPosition == position).Select(x => x.EndPosition).FirstOrDefault();
        }

        public int GetFinalPositionIfLadder(int position)
        {
            return Ladders.Where(x => x.InitialPosition == position).Select(x => x.EndPosition).FirstOrDefault();
        }

        private void SetSnakes()
        {
            Snakes = new List<Snake>
            {
                new Snake() { InitialPosition = 16, EndPosition = 6 },
                new Snake() { InitialPosition = 49, EndPosition = 11 },
                new Snake() { InitialPosition = 46, EndPosition = 25 },
                new Snake() { InitialPosition = 64, EndPosition = 60 },
                new Snake() { InitialPosition = 62, EndPosition = 19 },
                new Snake() { InitialPosition = 74, EndPosition = 53 },
                new Snake() { InitialPosition = 89, EndPosition = 68 },
                new Snake() { InitialPosition = 92, EndPosition = 88 },
                new Snake() { InitialPosition = 95, EndPosition = 75 },
                new Snake() { InitialPosition = 99, EndPosition = 80 }
            };
        }

        private void SetLadders()
        {
            Ladders = new List<Ladder>
            {
                new Ladder() { InitialPosition = 2, EndPosition = 38 },
                new Ladder() { InitialPosition = 7, EndPosition = 14 },
                new Ladder() { InitialPosition = 8, EndPosition = 31 },
                new Ladder() { InitialPosition = 15, EndPosition = 26 },
                new Ladder() { InitialPosition = 21, EndPosition = 42 },
                new Ladder() { InitialPosition = 28, EndPosition = 84 },
                new Ladder() { InitialPosition = 36, EndPosition = 44 },
                new Ladder() { InitialPosition = 51, EndPosition = 67 },
                new Ladder() { InitialPosition = 71, EndPosition = 91 },
                new Ladder() { InitialPosition = 78, EndPosition = 98 },
                new Ladder() { InitialPosition = 87, EndPosition = 94 }
            };
        }

        private void SetGoalSquare()
        {
            GoalSquare = Squares.Length;
        }
    }
}
