using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claims.Domain.Entities;
namespace Claims.Application.Contracts.Persistance
{
    public interface IClaimRepository : IAsyncRepository<Claims.Domain.Entities.Claims>
    {
        Task<IEnumerable<Claims.Domain.Entities.Claims>> GetClaimByPolicyNumber(string policyNumber);
    }
}
