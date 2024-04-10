namespace Ca1DevOps
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation("Adding a new line for testing");
                _logger.LogInformation("Adding a new line for testing build workflow on a branch");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
