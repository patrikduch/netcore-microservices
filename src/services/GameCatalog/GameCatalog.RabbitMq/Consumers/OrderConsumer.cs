using GameCatalog.RabbitMq.Models;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace GameCatalog.RabbitMq.Consumers
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Name);
        }
    }
}
