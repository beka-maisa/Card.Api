using Card.Api.Models.Requests;
using Card.Api.Models.Responses;
using Card.Api.Services.Abstract;
using Card.Api.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ILogger<CardService> _logger;

        public CardController(ICardService cardService, ILogger<CardService> logger)
        {
            _logger = logger;
            _cardService = cardService;
        }

        [HttpPost]
        public CardResponse CardValidate(CardRequest request)
        {
            _logger.LogInformation($"{nameof(CardValidate)}: CardRequest {request}");
            return _cardService.CardValidate(request);
        }
    }
}
