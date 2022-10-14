namespace SnakesAndLadders.Application.Entitites
{
    public class Token
    {
        public Token(int position)
        {
            Position = position;
        }

        public int Position { get; set; }
    }
}
