using AutoMapper;

namespace BigTimeApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCustomerForm, Customer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    State = src.State,
                    Zip = src.Zip
                }));
            CreateMap<UpdateCustomerForm, Customer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    State = src.State,
                    Zip = src.Zip
                }));
        }
    }
}
