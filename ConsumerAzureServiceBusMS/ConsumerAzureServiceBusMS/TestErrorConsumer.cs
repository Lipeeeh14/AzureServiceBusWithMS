using MassTransit;
using Newtonsoft.Json;
using SubmitTest;

namespace ConsumerAzureServiceBusMS
{
    public class TestErrorConsumer : IConsumer<ISubmitTest>
    {
        public async Task Consume(ConsumeContext<ISubmitTest> context)
        {
            Console.WriteLine($"Chegou erro -> {JsonConvert.SerializeObject(context.Message)}");
        }
    }
}
