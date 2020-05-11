using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageManagerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMessageManager _messageManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessageManager messageManager)
        {
            _logger = logger;
            _messageManager = messageManager;
        }

        [HttpGet]
        [Route("message-001")]
        public Message GetMessage001()
        {
            return _messageManager.GetMessage("AccountDoesntExists");
        }


        [HttpGet]
        [Route("message-002")]
        public Message GetMessage002()
        {
            return _messageManager.GetMessage("AccountAmountNotTheSame").FormatValue("BRL", "EUR");
        }

        [HttpGet]
        [Route("message-003")]
        public Message GetMessage003()
        {
            return _messageManager.GetMessage("AccountCurrencyDifferentCompensationCurrency").FormatValue("BRL", "USD");
        }
    }
}
