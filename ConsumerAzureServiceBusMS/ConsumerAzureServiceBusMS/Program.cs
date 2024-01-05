using ConsumerAzureServiceBusMS;
using MassTransit;

var busControl = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
{
	cfg.Host(
        "");

	cfg.ReceiveEndpoint("testqueueMS", e =>
	{
		e.Consumer<TestConsumer>();
		e.UseMessageRetry(r =>
		{
			r.Interval(2, TimeSpan.FromSeconds(10));
		});
	});

	cfg.ReceiveEndpoint("testqueueMS_error", e =>
	{
		e.Consumer<TestErrorConsumer>();
	});
});

try
{
	await busControl.StartAsync(new CancellationToken());

	Console.WriteLine("Pressione enter para sair");

	await Task.Run(() => Console.ReadLine());
}
catch (Exception ex)
{
	
}
finally
{
	await busControl.StopAsync();
}