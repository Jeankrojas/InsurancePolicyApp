using AutoMapper;
using InsurancePolicyApp.API.Dtos;
using InsurancePolicyApp.API.Models;

namespace InsurancePolicyApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Policy, PolicyForListDto>();
            CreateMap<PolicyDto, Policy>();
            CreateMap<PolicyEventType, PolicyEventTypeForDetailedDto>()
                .ForMember(dest => dest.Policy, opt => {
                    opt.MapFrom(src => src.Policy.Name);
                })
                .ForMember(dest => dest.RiskType, opt => {
                    opt.MapFrom(src => src.RiskType.Name);
                })
                .ForMember(dest => dest.EventType, opt => {
                    opt.MapFrom(src => src.EventType.Name);
                });
            CreateMap<PolicyEventTypeForUpdateDto, PolicyEventType>();

        }
    }
} 