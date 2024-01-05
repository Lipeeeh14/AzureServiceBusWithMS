using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ConsumerFunctionApp
{
    public class ConsumerFunction(ILogger<ConsumerFunction> logger)
    {
        private readonly ILogger<ConsumerFunction> _logger = logger;

        [Function(nameof(ConsumerFunction))]
        public void Run([ServiceBusTrigger("testqueue", Connection = "AzureServiceBus")] string message)
        {
            dynamic data = JsonConvert.DeserializeObject(message);

            string messageBody = data?.message;

            _logger.LogInformation("Message: {messageBody}", messageBody);
            //throw new InvalidOperationException("Simulação de erro para nova tentativa");
        }
    }
}
