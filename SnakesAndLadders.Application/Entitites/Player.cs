namespace SnakesAndLadders.Application.Entitites
{
    public class Player
    {
        public Player(int number, Token token)
        {
            Number = number;
            Token = token;
        }

        public int Number { get; set; }

        public Token Token { get; set; }

        public int GetTokenPosition()
        {
            return Token.Position;
        }
    }
}
