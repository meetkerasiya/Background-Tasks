namespace BackgroundTasks;

public class MyBackgroundService : BackgroundService
{
    private readonly ILogger<MyBackgroundService> _logger;
    private readonly IScopedService _scopedService;

    public MyBackgroundService(ILogger<MyBackgroundService> logger,IScopedService scopedService)
    {
        _logger = logger;
        _scopedService = scopedService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("From MyBackgroundService: ExecuteAsync {dateTime}",DateTime.Now);
            _scopedService.Write();
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("From MyBackgroundService: StopAsync {dateTime}",DateTime.Now);
        return base.StopAsync(cancellationToken);
    }
}