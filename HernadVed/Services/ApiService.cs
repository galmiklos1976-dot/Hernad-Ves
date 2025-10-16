using System.Net.Http;
using System.Threading.Tasks;
using HernadVed.Models;
using Newtonsoft.Json;

namespace HernadVed.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.hernadved.hu";

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/users?email={Uri.EscapeDataString(email)}");
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<User>>(content);
                    return users?.FirstOrDefault();
                }
                
                return null;
            }
            catch (Exception ex)
            {
                // Log error in production
                System.Diagnostics.Debug.WriteLine($"API Error: {ex.Message}");
                return null;
            }
        }

        public async Task<User?> AuthenticateUserAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            
            if (user != null && user.Password == password)
            {
                return user;
            }
            
            return null;
        }
    }
}
