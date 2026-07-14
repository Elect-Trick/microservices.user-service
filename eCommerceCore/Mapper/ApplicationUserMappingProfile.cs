using AutoMapper;
using eCommerceCore.DTO;
using eCommerceCore.Entities;

namespace eCommerceCore.Mapper
{
    public class ApplicationUserMappingProfile: Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser,AuthenticationResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(source => source.Gender))
                .ForMember(dest => dest.Success, opt => opt.Ignore());

            CreateMap<RegisterUserDTO, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(source => source.Gender));

        }
    }
}
