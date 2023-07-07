using WareHousingApi.Entities;

namespace WareHousingApi.WebApi.Tools.Interface
{
    public interface IJwtTokenGenerator
    {
        Task<string> CreateTokenAsync(ApplicationUsers user);
    }
}
