using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace BrouwerClient {
    class Program {
        static async Task Main() {
            Console.Write("Id:");
            var id = int.Parse(Console.ReadLine());
            using var client = new HttpClient();
            var uri = $"http://localhost:5000/brouwers/{id}";
            var response = await client.GetAsync(uri);
            switch (response.StatusCode) {
                case HttpStatusCode.OK:
                    var brouwer = await response.Content.ReadAsAsync<Brouwer>();
                    brouwer.Gemeente = brouwer.Gemeente.ToUpper();
                    response = await client.PutAsJsonAsync(uri, brouwer);
                    if (response.StatusCode == HttpStatusCode.OK) {
                        Console.WriteLine("Brouwer gewijzigd");
                    }
                    else {
                        Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
                    }
                break;
                case HttpStatusCode.NotFound:
                    Console.WriteLine("Brouwer niet gevonden");
                    break;
                default:
                    Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
                    break;
            }
        }
    }
}
