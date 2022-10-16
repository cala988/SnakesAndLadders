namespace SnakesAndLadders.Application.Entitites
{
    public class Die
    {
        public int InitialNumber { get; set; }
        public int FinalNumber { get; set; }
        
        public Die(int initialNumber, int finalNumber)
        {
            InitialNumber = initialNumber;
            FinalNumber = finalNumber;
        }
    }
}
