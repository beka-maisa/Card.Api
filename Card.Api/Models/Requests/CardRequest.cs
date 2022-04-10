namespace Card.Api.Models.Requests
{
    public class CardRequest
    {
        public CardType CardType { get; set; }
        public string CardNumber { get; set; }
        public string Date { get; set; }
        public string CVC { get; set; }
    }

    public enum CardType
    {
        MasterCard = 0,
        Visa = 1,
        AmericanExpress = 2
    }
}
