using MassTransit;
using System;
using System.Threading.Tasks;

namespace GameCatalog.RabbitMq.Consumers
{
    public class GameCatalogConsumer : IConsumer<GameCatalogItemUCreated>
    {
        public async Task Consume(ConsumeContext<GameCatalogItemUCreated> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Name);
        }
    }
}
