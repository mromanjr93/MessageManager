using MessageManager;
using MessageManagerSample.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageManagerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMessageManager _messageManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessageManager messageManager)
        {
            _logger = logger;
            _messageManager = messageManager;
        }

        [HttpGet]
        [Route("message-001")]
        public IActionResult GetMessage001()
        {
            var response = new SampleResponse();

            response.AddNotification(_messageManager.GetMessage("AccountDoesntExists").GetNotification());


            return Ok(response);
        }


        [HttpGet]
        [Route("message-002")]
        public IActionResult GetMessage002()
        {
            var response = new SampleResponse();

            response.AddNotification(_messageManager.GetMessage("AccountAmountNotTheSame").FormatValue("BRL", "EUR").GetNotification(true));


            return Ok(response);
        }

        [HttpGet]
        [Route("message-003")]
        public Message GetMessage003()
        {
            return _messageManager.GetMessage("AccountCurrencyDifferentCompensationCurrency").FormatValue("BRL", "USD");
        }


        [HttpGet]
        [Route("all-messages")]
        public IActionResult GetAllMessages()
        {
            var response = new SampleResponse();

            response.AddNotification(_messageManager.GetMessage("AccountDoesntExists").GetNotification());
            response.AddNotification(_messageManager.GetMessage("AccountAmountNotTheSame").FormatValue("BRL", "EUR").GetNotification(true));
            response.AddNotification(_messageManager.GetMessage("AccountCurrencyDifferentCompensationCurrency").FormatValue("BRL", "USD").GetNotification());

            return Ok(response);
        }
    }
}
