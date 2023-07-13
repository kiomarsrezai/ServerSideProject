using AutoMapper;
using WareHousingApi.Entities;

namespace WareHousingApi.WebApi.AutoMapperProfile
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ApplicationUsers, UserEditModel>().ReverseMap();
        }
    }
}
