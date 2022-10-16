using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Interfaces;

namespace SnakesAndLadders.Application.Services
{
    public class DieService : IDieService
    {
        public Die Die { get; set; } = new Die(1, 6);

        public int Roll()
        {
            Random random = new();
            return random.Next(Die.InitialNumber, Die.FinalNumber);
        }
    }
}
