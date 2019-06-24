using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionApp
{
    public static class HelloWorld
    {
        [FunctionName("HelloWorld")]
        public static void Run([QueueTrigger("myqueue", Connection = "AzureWebJobsStorage")]string myQueueItem,
            [Queue("myqueue-items-destination", Connection = "AzureWebJobsStorage")] out string myQueueItemCopy,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            myQueueItemCopy = myQueueItem;
        }
    }
}
