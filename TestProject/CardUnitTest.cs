using Card.Api.Models.Requests;
using Card.Api.Services.Concrete;
using Xunit;

namespace TestProject
{
    public class CardUnitTest
    {
        [Fact]
        public void Test()
        {
            var cardService = new CardService();
            //assert
            var request = new CardRequest
            {
                CardType = CardType.Visa,
                CardNumber = "1234567891234567",
                CVC = "123",
                Date = "02/2027"
            };

            //act
            var response = cardService.CardValidate(request);

            //assert
            Assert.True(response.Result);
        }
    }
}
