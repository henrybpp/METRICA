using mic_notification_api.Application.Ports.In;
using mic_notification_api.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mic_notification_api.Adapters.Inbound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World from .NET 10 API");
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok($"Hello {name}");
        }

        /***********************************************/
        private readonly INotificationUseCase _iCreateEventUseCase;

        public NotificationController(INotificationUseCase iCreateEventUseCase)
        {
            _iCreateEventUseCase = iCreateEventUseCase;
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Domain.Entities.Notification evt)
        {
            try
            {
                _iCreateEventUseCase.Execute(evt);
                return Ok("Pedido creado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
