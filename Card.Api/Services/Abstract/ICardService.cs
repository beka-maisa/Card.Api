using Card.Api.Models.Requests;
using Card.Api.Models.Responses;

namespace Card.Api.Services.Abstract
{
    public interface ICardService
    {
        CardResponse CardValidate(CardRequest request);
    }
}
