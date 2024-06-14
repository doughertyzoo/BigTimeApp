using AutoMapper;

namespace BigTimeApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCustomerRequestModel, Customer>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    State = src.State,
                    Zip = src.Zip
                }));
            CreateMap<UpdateCustomerRequestModel, Customer>()
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
