using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MessageManager.Tests
{
    public class MessageManagerTest
    {
        private readonly IServiceProvider _provider;

        public MessageManagerTest()
        {
            var services = new ServiceCollection();

            _provider = services.AddMessageManager(c =>
            {
                c.AddFileMessage("Messages/messages.json");
                c.AddFileMessage("Messages/messages-es-AR.json");
                c.AddFileMessage("Messages/messages2.json");
            }).BuildServiceProvider();
        }

        [Fact]
        public void ShouldGetAMessageFromJson()
        {
            //Arrange
            var manager = _provider.GetRequiredService<IMessageManager>();
            var value = "Account doesn't exists";
            var code = "001";

            // Act
            var message = manager.GetMessage("AccountDoesntExists");


            // Assert
            Assert.Equal(value, message.Value);
            Assert.Equal(code, message.Code);
        }

      

        [Fact]
        public void ShouldGetAFormatedMessageFromJson()
        {
            //Arrange
            var manager = _provider.GetRequiredService<IMessageManager>();
            manager.SetRequestCultureInfo(new System.Globalization.CultureInfo("en-US"));

            var value = "CurrencyID must be the same in AccountCurrency(BRL) and CompensationCurrency(USD)";
            var code = "003";

            // Act
            var message = manager.GetMessage("AccountCurrencyDifferentCompensationCurrency").FormatValue("BRL", "USD");


            // Assert
            Assert.Equal(value, message.Value);
            Assert.Equal(code, message.Code);
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenGetAFormatedMessageFromJsonWithOneValue()
        {
            //Arrange
            var manager = _provider.GetRequiredService<IMessageManager>();
            manager.SetRequestCultureInfo(new System.Globalization.CultureInfo("en-US"));


            // Assert
            Assert.Throws<FormatException>(() =>
            {
                manager.GetMessage("AccountCurrencyDifferentCompensationCurrency").FormatValue("BRL").FormatValue("USD");
            });
        }

        [Fact]
        public void ShouldGetASpanishMessageFromJson()
        {
            //Arrange
            var manager = _provider.GetRequiredService<IMessageManager>();
            manager.SetRequestCultureInfo(new System.Globalization.CultureInfo("es-AR"));
            var value = "La cuenta no existe";
            var code = "001";

            // Act
            var message = manager.GetMessage("AccountDoesntExists");


            // Assert
            Assert.Equal(value, message.Value);
            Assert.Equal(code, message.Code);
        }
    }
}
