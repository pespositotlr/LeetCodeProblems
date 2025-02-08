using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Here's a simple rate limiter in C# that limits the number of requests per a given time interval using SemaphoreSlim and ConcurrentQueue. 
/// This implementation allows a configurable number of requests within a given time window.
/// 
/// This rate limiter allows a maximum number of requests within a specific time window. 
/// It ensures that once the limit is reached, additional requests are denied until the window resets.
/// </summary>
public class RateLimiter
{
    private readonly int _maxRequests;
    private readonly TimeSpan _timeWindow;
    private readonly ConcurrentQueue<DateTime> _requestTimestamps = new ConcurrentQueue<DateTime>();
    private readonly SemaphoreSlim _semaphore;

    public RateLimiter(int maxRequests, TimeSpan timeWindow)
    {
        _maxRequests = maxRequests;
        _timeWindow = timeWindow;
        _semaphore = new SemaphoreSlim(maxRequests, maxRequests);
    }

    public async Task<bool> AllowRequestAsync()
    {
        lock (_requestTimestamps)
        {
            var now = DateTime.UtcNow;
            while (_requestTimestamps.TryPeek(out var oldest) && (now - oldest > _timeWindow))
            {
                _requestTimestamps.TryDequeue(out _);
                _semaphore.Release();
            }
        }

        if (await _semaphore.WaitAsync(0))
        {
            _requestTimestamps.Enqueue(DateTime.UtcNow);
            return true;
        }

        return false;
    }
}

// Example usage
public class RateLimiterProgram
{
    public static async Task RateLimiterProgramMain()
    {
        var rateLimiter = new RateLimiter(5, TimeSpan.FromSeconds(10));

        for (int i = 0; i < 10; i++)
        {
            if (await rateLimiter.AllowRequestAsync())
            {
                Console.WriteLine($"Request {i + 1}: Allowed");
            }
            else
            {
                Console.WriteLine($"Request {i + 1}: Denied");
            }

            await Task.Delay(1000); // Simulate time between requests
        }
    }
}
