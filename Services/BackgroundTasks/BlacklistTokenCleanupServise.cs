using CorporateOffers.Data;
using Microsoft.EntityFrameworkCore;

namespace CorporateOffers.Services.BackgroundTasks;

public class BlacklistTokenCleanupService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private Timer _timer;

    public BlacklistTokenCleanupService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ClearTokenBlacklist, null, TimeSpan.Zero, TimeSpan.FromDays(1)); // checks every day
        return Task.CompletedTask;
    }

    private async void ClearTokenBlacklist(object? state)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var expiredTokens = await dbContext.TokenBlacklist
            .Where(token => token.Expiration < DateTime.UtcNow)
            .ToListAsync();

        if (expiredTokens.Count == 0) return;
        dbContext.TokenBlacklist.RemoveRange(expiredTokens);
        await dbContext.SaveChangesAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}