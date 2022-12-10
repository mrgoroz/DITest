using DITest.Models;

namespace DITest.Services
{
    public interface IHolidayApiService
    {
        Task<HolidayapiRes> GetToken(string clientSecret);
    }
}
