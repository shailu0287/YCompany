using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Claims.Application.Contracts.Infrastructure;
using Claims.Application.Contracts.Persistance;
using Claims.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Doamin = Claims.Domain.Entities;
namespace Claims.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, int>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateClaimCommandHandler> _logger;

        public CreateClaimCommandHandler(IClaimRepository claimRepository, IMapper mapper, IEmailService emailService, ILogger<CreateClaimCommandHandler> logger)
        {
            _claimRepository = claimRepository ?? throw new ArgumentNullException(nameof(claimRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var claimEntity = _mapper.Map<Doamin.Claims>(request);
            var newClaim = await _claimRepository.AddAsync(claimEntity);

            _logger.LogInformation($"Order {newClaim.Id} is successfully created.");

            await SendMail(newClaim);

            return newClaim.Id;
        }
        private async Task SendMail(Domain.Entities.Claims order)
        {
            var email = new Email() { To = "ezozkme@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
