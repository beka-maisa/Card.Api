using System.Collections.Generic;

namespace Card.Api.Models.Responses
{
    public class CardResponse
    {
        public bool Result { get; set; }
        public List<string> Message { get; set; }

        public CardResponse(bool result, List<string> message)
        {
            Result = result;
            Message = message;
        }
    }
}
