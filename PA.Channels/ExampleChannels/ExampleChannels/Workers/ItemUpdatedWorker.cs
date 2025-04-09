using System.Threading.Channels;
using ExampleChannels.Entities;

namespace ExampleChannels.Workers;

public class ItemUpdatedWorker(Channel<ItemUpdated> channel) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await channel.Reader.WaitToReadAsync(stoppingToken))
        {
            while (channel.Reader.TryRead(out ItemUpdated? item))
            {
                Console.WriteLine($"Item {item.Id} has been updated. Old price: {item.OldPrice}, " +
                                  $"New price: {item.NewPrice}. Old title: {item.OldTitle}, " +
                                  $"New title: {item.NewTitle}");
            }
        }
    }
}