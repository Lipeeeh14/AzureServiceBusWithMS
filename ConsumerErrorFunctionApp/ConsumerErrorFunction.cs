using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ConsumerErrorFunctionApp
{
    public class ConsumerErrorFunction
    {
        private readonly ILogger<ConsumerErrorFunction> _logger;

        public ConsumerErrorFunction(ILogger<ConsumerErrorFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ConsumerErrorFunction))]
        public void Run([ServiceBusTrigger("testqueue/$deadletterqueue", Connection = "AzureServiceBus")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message Body: {body}", message.Body);
        }
    }
}
