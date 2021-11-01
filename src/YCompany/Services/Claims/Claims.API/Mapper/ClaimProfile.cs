using AutoMapper;
using Claims.API.Entities;
using Claims.Application.Features.Claims.Commands.CreateClaim;
using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claims.API.Mapper
{
    public class ClaimProfile : Profile
    {
        public ClaimProfile()
        {
            CreateMap<Claim, ClaimCreateEvent>().ReverseMap();
        }
        
    }
}
