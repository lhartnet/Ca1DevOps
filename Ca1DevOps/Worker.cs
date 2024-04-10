namespace Ca1DevOps
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _folderPath;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _folderPath = @"C:\Users\lhartnet\OneDrive - Analog Devices, Inc\Documents\Contemporary Software Development";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await CheckFolderContents();
            using var timer = new Timer(async _ => await CheckFolderContents(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        private async Task CheckFolderContents()
        {
            try
            {
                // Get all files in the folder
                string[] files = Directory.GetFiles(_folderPath);

                // Log the names of the files
                _logger.LogInformation($"Files in folder {_folderPath}:");
                foreach (string file in files)
                {
                    _logger.LogInformation($"- {Path.GetFileName(file)}");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions
                _logger.LogError($"Error checking folder contents: {ex.Message}");
            }
        }
    }
}
