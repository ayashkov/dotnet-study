namespace study.host;

public class Worker: BackgroundService {
    private readonly IHostApplicationLifetime lifetime;

    private readonly ILogger<Worker> logger;

    public Worker(IHostApplicationLifetime lifetime, ILogger<Worker> logger)
    {
        this.lifetime = lifetime;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        logger.LogInformation("Started");

        await Task.Delay(10000, token);

        logger.LogInformation("Done");

        lifetime.StopApplication();
   }
}
