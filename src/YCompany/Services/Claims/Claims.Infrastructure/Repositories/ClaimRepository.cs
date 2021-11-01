using Claims.Application.Contracts.Persistance;
using Claims.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Infrastructure.Repositories
{
   public class ClaimRepository : RepositoryBase<Claims.Domain.Entities.Claims>, IClaimRepository
    {
        public ClaimRepository(ClaimContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Domain.Entities.Claims>> GetClaimByPolicyNumber(string policyNumber)
        {
            var orderList = await _dbContext.Claims
                                .Where(o => o.PolicyNumber == policyNumber)
                                .ToListAsync();
            return orderList;
        }
    }
}
