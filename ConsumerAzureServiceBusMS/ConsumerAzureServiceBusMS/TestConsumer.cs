using MassTransit;
using Newtonsoft.Json;
using SubmitTest;

namespace ConsumerAzureServiceBusMS
{
	public class TestConsumer : IConsumer<ISubmitTest>
	{
		public async Task Consume(ConsumeContext<ISubmitTest> context)
		{
			//Console.WriteLine($"To tentando enviar");
			//throw new Exception("Simulando uma exceção durante o processamento da mensagem");
			Console.WriteLine($"Chegou -> {JsonConvert.SerializeObject(context.Message)}");
		}
	}
}
