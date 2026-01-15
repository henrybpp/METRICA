using mic_event_api.Application.Ports.In;
using mic_event_api.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mic_event_api.Adapters.Inbound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
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
        private readonly ICreateEventUseCase _iCreateEventUseCase;

        public EventController(ICreateEventUseCase iCreateEventUseCase)
        {
            _iCreateEventUseCase = iCreateEventUseCase;
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] Domain.Entities.Event evt)
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
