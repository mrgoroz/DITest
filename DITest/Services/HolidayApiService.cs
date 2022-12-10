using DITest.Models;
using System.Text.Json;

namespace DITest.Services
{
    public class HolidayApiService : IHolidayApiService
    {
        private readonly HttpClient _httpClient;

        public HolidayApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HolidayapiRes> GetToken(string clientSecret)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://holidayapi.com/v1/holidays?pretty&key={clientSecret}&country=IL&year=2021");
            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<HolidayapiRes>(responseStream);
            return authResult;
        }

        
    }
}
