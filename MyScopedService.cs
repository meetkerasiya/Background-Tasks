﻿namespace BackgroundTasks;

public class MyScopedService : IScopedService
{
    private readonly ILogger<MyScopedService> _logger;

    public MyScopedService(ILogger<MyScopedService> logger)
    {
        _logger = logger;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public void Write()
    {
        _logger.LogInformation("MyScopedService {Id}",Id);
    }
}

public interface IScopedService
{
    void Write();
}