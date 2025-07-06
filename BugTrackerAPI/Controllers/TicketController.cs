using BugTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Core.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ITicketService _svc;
        public TicketsController(ITicketService svc)
           => _svc = svc;

        //CREATE
        [HttpPost, Authorize]
        public async Task<ActionResult<TicketDto>> Create([FromBody] CreateTicketDto dto)
        {
            // grab the Entra ID object identifier
            var userId = User.FindFirst("oid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return Unauthorized();

            var created = await _svc.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        //READ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadTicketDto>>> Get()
    => Ok(await _svc.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadTicketDto>> Get(int id)
        {
            var dto = await _svc.GetByIdAsync(id);
            return dto is null ? NotFound() : Ok(dto);
        }
    }
}
