using MassTransit;
using ProducerAzureServiceBusMS.DTO;
using SubmitTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration.GetSection("AzureServiceBus");
builder.Services.AddMassTransit(x => 
{
	x.UsingAzureServiceBus((context, cfg) => 
	{
		cfg.Host(configuration["ConnectionString"]);

		cfg.ReceiveEndpoint(configuration["Queue"], e => { });
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/test-message", async (TestDTO testDTO, IBusControl bus) =>
{
	try
	{
		await bus.StartAsync();

		var endpoint = await bus.GetSendEndpoint(new Uri($"queue:{configuration["Queue"]}"));

		await endpoint.Send<ISubmitTest>(new { testDTO.Message });

		Console.WriteLine($"Mensagem enviada --> {testDTO.Message}");

		return Results.Ok();
	}
	catch (Exception ex)
	{
		return Results.BadRequest();
	}
	finally 
	{
		await bus.StopAsync();
	}
})
.WithOpenApi();

app.Run();