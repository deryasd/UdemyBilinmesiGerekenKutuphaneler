using System.Net.Http.Headers;
using System.Text;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task Sender(string userId, string message)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://rapidprod-sendgrid-v1.p.rapidapi.com/mail/send"),
            };

            // API key ve host header'larını ekle
            request.Headers.Add("x-rapidapi-key", "36c4a561d3msh98a5808fce60b22p1014d9jsn6a4f5ff0c4c0");
            request.Headers.Add("x-rapidapi-host", "rapidprod-sendgrid-v1.p.rapidapi.com");

            // JSON body
            var json = $@"{{
                ""personalizations"":[{{""to"":[{{""email"":""derya.sdev@gmail.com""}}],""subject"":""Message from system""}}],
                ""from"":{{""email"":""derya.sdev@gmail.com""}},
                ""content"":[{{""type"":""text/plain"",""value"":""{message}""}}]
            }}";

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine("✅ Success: " + body);
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"❌ Error {response.StatusCode}: {error}");
            }
        }
    }
}
