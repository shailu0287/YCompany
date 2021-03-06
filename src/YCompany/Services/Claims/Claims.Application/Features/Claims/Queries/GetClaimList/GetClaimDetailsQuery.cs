
using Claims.Application.Features.Claims.Queries.GetClaimList;
using MediatR;
using System;
using System.Collections.Generic;

namespace Claims.Application.Features.Claims.Queries.GetClaimList
{
    public class GetClaimDetailsQuery : IRequest<List<ClaimVm>>
    {
        public string PolicyNumber { get; set; }

        public GetClaimDetailsQuery(string policyNumber)
        {
            PolicyNumber = policyNumber ?? throw new ArgumentNullException(nameof(policyNumber));
        }
    }
}
