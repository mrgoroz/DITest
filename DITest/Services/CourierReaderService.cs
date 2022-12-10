using DITest.Models;
using System.Text.Json;

namespace DITest.Services
{
    public class CourierReaderService : ICourierReaderService
    {
        public CourierReaderService()
        {

        }

        public HolidayapiRes ReadFile()
        {
            string json = File.ReadAllText("courierTimes.json");
            return JsonSerializer.Deserialize<HolidayapiRes>(json);
        }
    }
}
