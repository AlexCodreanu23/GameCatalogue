using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameCatalogue
{
    public class EmailService
    {
        private readonly string _apiKey;

        public EmailService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", _apiKey);

            var email = new
            {
                sender = new { email = "alexcosmin2377@gmail.com" },
                to = new[] { new { email = toEmail } },
                subject = subject,
                htmlContent = htmlContent,
                textContent = plainTextContent
            };

            var json = JsonConvert.SerializeObject(email);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.sendinblue.com/v3/smtp/email", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error Message: {responseBody}");
            }
        }
    }

}
