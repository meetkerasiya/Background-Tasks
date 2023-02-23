namespace BackgroundTasks;

public class MyBackgroundService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine(("From MyBackgroundService: ExecuteAsync"));
        return Task.CompletedTask;
    }
}