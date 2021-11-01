using AutoMapper;
using Claims.Application.Features.Claims.Commands.CreateClaim;


namespace Claims.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Claims.Domain.Entities.Claims, Features.Claims.Queries.ClaimVm>().ReverseMap();
            CreateMap<Claims.Domain.Entities.Claims, CreateClaimCommand>().ReverseMap();
        }
    }
}
