using AutoMapper;
using Claims.Application.Contracts.Persistance;
using Claims.Application.Features.Claims.Queries.GetClaimList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Claims.Application.Features.Claims.Queries.GetClaimList
{
   public class GetClaimDetailsQueryHandler : IRequestHandler<GetClaimDetailsQuery, List<ClaimVm>>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;

        public GetClaimDetailsQueryHandler(IClaimRepository claimRepository, IMapper mapper)
        {
            _claimRepository = claimRepository ?? throw new ArgumentNullException(nameof(claimRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
       

        public async Task<List<ClaimVm>> Handle(GetClaimDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _claimRepository.GetClaimByPolicyNumber(request.PolicyNumber);
            return _mapper.Map<List<ClaimVm>>(orderList);
        }
    }
}
