using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Application.Features.Claims.Commands.CreateClaim
{
  public  class CreateClaimCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Pincode { get; set; }
        public DateTime LossDate { get; set; }
        public string PlaceOfAccident { get; set; }
        public string TypeOfLoss { get; set; }
        public string ShortDescription { get; set; }
        public string DriverName { get; set; }
        public int Age { get; set; }
        public string DLNo { get; set; }
        public string NameOfRTO { get; set; }
        public bool IsLearnerLicence { get; set; }
        public string CoPassenger { get; set; }
        public string ThirdPartyName { get; set; }
        public string ThirdContactNo { get; set; }
        public string ThirdPartyInjury { get; set; }
    }
}
