namespace SnakesAndLadders.Application.Entitites
{
    public class Die
    {
        private readonly int _initialNumber;
        private readonly int _finalNumber;

        public Die(int initialNumber, int endNumber)
        {
            _initialNumber = initialNumber;
            _finalNumber = endNumber;
        }

        public int Roll()
        {
            Random random = new();
            return random.Next(_initialNumber, _finalNumber);
        }
    }
}
