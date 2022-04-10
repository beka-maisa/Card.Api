using Card.Api.Models.Requests;
using Card.Api.Models.Responses;
using Card.Api.Services.Abstract;

namespace Card.Api.Services.Concrete
{
    public class CardService : ICardService
    {
        public CardResponse CardValidate(CardRequest request)
        {
            return new CardResponse(true, null);
        }
    }
}
