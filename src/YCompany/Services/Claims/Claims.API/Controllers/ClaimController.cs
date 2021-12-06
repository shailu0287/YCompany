using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Claims.Application.Features.Claims.Queries;
using System.Net;
using Claims.Application.Features.Claims.Commands.CreateClaim;
using Microsoft.AspNetCore.Http;
using Claims.Application.Features.Claims.Queries.GetClaimList;
using MassTransit;
using AutoMapper;
using EventBus.Messages.Events;
using Claims.API.Entities;
using Claims.Application.Features.Claims.Queries.GetClaimList;

namespace Claims.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public ClaimController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{policyNumber}", Name = "GetClaim")]
        [ProducesResponseType(typeof(IEnumerable<ClaimVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ClaimVm>>> GetClaimByPolicyNumber(string policyNumber)
        {
            var query = new GetClaimDetailsQuery(policyNumber);
            var claim = await _mediator.Send(query);
            return Ok(claim);
        }
        [HttpPost(Name = "CreateClaim")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateClaim([FromBody] CreateClaimCommand command)
        {
            var result = await _mediator.Send(command);
            Claim objClaim = new Claim();
            objClaim.PolicyNumber = command.PolicyNumber;
            objClaim.Address = command.Address;
            objClaim.Age = command.Age;
            objClaim.City = command.City;
            objClaim.ClaimNumber = command.ClaimNumber;
            objClaim.EmailId = command.EmailId;
            var eventMessage = _mapper.Map<ClaimCreateEvent>(objClaim);
            await _publishEndpoint.Publish<ClaimCreateEvent>(eventMessage);

            return Ok(result);
        }

        //[HttpPut(Name = "UpdateClaim")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> UpdateClaim()
        //{
            
        //    return  NoContent();
        //}

    }
}
