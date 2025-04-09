using System.Threading.Channels;
using ExampleChannels.Data;
using ExampleChannels.Dtos;
using ExampleChannels.Entities;

namespace ExampleChannels.UseCases;

public class UpdateItem (IDatabaseRepository databaseRepository, 
    Channel<ItemUpdated> channel)
{
    public async Task<bool> Execute(ItemDto itemToUpdate)
    {

        if (itemToUpdate.Title.Length > 200)
            throw new Exception("Title must be less than 200 characters");
        if (itemToUpdate.Price <= 0)
            throw new Exception("It can't be free");

        ItemDto originalItem = await databaseRepository.GetItemById(itemToUpdate.Id);
        await databaseRepository.UpdateItem(itemToUpdate.Id, itemToUpdate.Price, itemToUpdate.Title);

        decimal percentageDifference = ((itemToUpdate.Price - originalItem.Price) / originalItem.Price) * 100;
        if (percentageDifference <= -30)
        {
            await channel.Writer.WriteAsync(new ItemUpdated()
            {
                Id = itemToUpdate.Id,
                NewPrice = itemToUpdate.Price,
                NewTitle = itemToUpdate.Title,
                OldPrice = originalItem.Price,
                OldTitle = originalItem.Title
            });
        }
        return true;
    }
}