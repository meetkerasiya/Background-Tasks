namespace BackgroundTasks;

public class MyBackgroundService : BackgroundService
{
    private readonly ILogger<MyBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public MyBackgroundService(ILogger<MyBackgroundService> logger,IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                _logger.LogInformation("From MyBackgroundService: ExecuteAsync {dateTime}",DateTime.Now);
                var scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();
                scopedService.Write();
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
           
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("From MyBackgroundService: StopAsync {dateTime}",DateTime.Now);
        return base.StopAsync(cancellationToken);
    }
}