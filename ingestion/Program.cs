using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;

namespace ingestion
{
    class Program
    {

        private const string connectionString = "Endpoint=sb://adxesencial.servicebus.windows.net/;SharedAccessKeyName=adxesencialdirectiva;SharedAccessKey=qJCvAmZt3Jp0RahvuOpSpVhvxX+rC24C+GMRiPCSAOI=;EntityPath=adxesencial";
        static async Task Main(string[] args)
        {
            var client = EventHubClient.CreateFromConnectionString(connectionString);

            while (true)
            {
                var data = new 
                {
                    id = Guid.NewGuid().ToString(),
                    name = "Curso",
                    host_id = "1000",
                    host_name = "Rodrigo Díaz Concha",
                    neighbourhood_group = "Curso",
                    neighbourhood = "LinkedIn Learning"
                };

                var serializedData  = JsonSerializer.SerializeToUtf8Bytes(data);

                System.Console.WriteLine("Enviando...");
                await client.SendAsync(new EventData(serializedData));
                await Task.Delay(500);
            }
            
        }
    }
}
