using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace TestFunctionApp
{
	public class ConsumerFuncion
    {
        private readonly ILogger<ConsumerFuncion> _logger;

        public ConsumerFuncion(ILogger<ConsumerFuncion> log)
        {
            _logger = log;
        }

        [FunctionName("testfunctionqueue")]
        public void Run([ServiceBusTrigger("testqueue", Connection = "AzureWebJobsStorage")] string message) 
        {
            Console.WriteLine($"A mensagem chegou -> {message}");
        }
    }
}

