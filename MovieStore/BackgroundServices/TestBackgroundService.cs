using System.Text;
using MongoDB.Bson.IO;
using MovieStore.Models.DTO;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace MovieStore.BackgroundServices;

public class TestBackgroundService : BackgroundService
{
    private readonly ILogger<TestBackgroundService> _logger;

    public TestBackgroundService(ILogger<TestBackgroundService> logger)
    {
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var actor = new Actor
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test"
            };

            var jsonObject = JsonConvert.SerializeObject(actor);
            
            _logger.LogInformation(jsonObject);
            
            var inputData = Encoding.UTF8.GetBytes(jsonObject);
            var resultData = Encoding.UTF8.GetBytes(jsonObject);
            Actor result = JsonConvert.DeserializeObject<Actor>(jsonObject)!;

            Console.WriteLine(result.Name);
            
            _logger.LogInformation("TestBackgroundService is running.");
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}