using mic_bff_orchestator_api.Application.DTO;
using mic_bff_orchestator_api.Application.Ports.In;
using Microsoft.AspNetCore.Mvc;

namespace mic_bff_orchestator_api.Adapters.Inbound.Controllers
{
    [ApiController]
    [Route("api/events")]
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
        public IActionResult CreateEvent([FromBody] EventDTO dto,CancellationToken cancellationToken)
        {
            try
            {
                _iCreateEventUseCase.HandleAsync(dto,cancellationToken);
                return Ok(new { message = "Evento creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
