using Microsoft.Extensions.Hosting;
namespace SnakesAndLadders
{
    public class ConsoleApp : IHostedService
    {
        public ConsoleApp()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //TODO.. call to logic

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //TODO.. call to logic in case of error

            //_logger.LogInformation("Aplicación parada.");
            return Task.CompletedTask;
        }
    }
}
