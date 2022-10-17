using Microsoft.Extensions.Hosting;
using SnakesAndLadders.Application.Entitites;
using SnakesAndLadders.Application.Interfaces;

namespace SnakesAndLadders
{
    public class ConsoleApp : IHostedService
    {
        private const string RollCommand = "roll";
        private const string StopCommand = "stop";
        private readonly IBoardGameService _boardGameService;

        public ConsoleApp(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                StartGame();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void StartGame()
        {
            Console.WriteLine("Hello this is the game SnakesAndLadders.");
            Console.WriteLine("Set number of players:");
            var command = Console.ReadLine();
            bool isNumber = int.TryParse(command, out int numberOfPlayers);
            while (!isNumber)
            {
                Console.WriteLine("Number of players must be a number, please reenter the number of players");
                command = Console.ReadLine();
                isNumber = int.TryParse(command, out numberOfPlayers);
            }

            _boardGameService.Start(numberOfPlayers);

            bool playerWonGame = false;
            while (command != StopCommand && !playerWonGame)
            {
                for (int actualPlayer = 1; actualPlayer <= numberOfPlayers; actualPlayer++)
                {
                    Console.WriteLine($"Player {actualPlayer}, please write roll to throw the die or stop to exit the game.");
                    command = Console.ReadLine();
                    
                    if (command is not null && command.Equals(StopCommand))
                    {
                        Console.WriteLine("The game is over.");
                        Console.ReadKey();
                        break;
                    }

                    if (command is not null && command.Equals(RollCommand))
                    {
                        playerWonGame = PlayTurn(actualPlayer);

                        if (playerWonGame)
                        {
                            Console.WriteLine($"Congratulations! player {actualPlayer} won the game! The game is over.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
            }
        }

        private bool PlayTurn(int actualPlayer)
        {
            var player = _boardGameService.GetPlayer(actualPlayer);
            int initialSquareOfTurn = _boardGameService.GetTokenPositionOfPlayer(player);
            int number = _boardGameService.RollDie();
            player = _boardGameService.MovePlayerTokenPosition(player, number);
            int finalSquareOfTurn = _boardGameService.GetTokenPositionOfPlayer(player);
            Console.WriteLine($"You have rolled an {number}, you have moved from square {initialSquareOfTurn} to {finalSquareOfTurn}.");
            return _boardGameService.CheckIfThePlayerWonTheGame(player);
            
        }
    }
}
