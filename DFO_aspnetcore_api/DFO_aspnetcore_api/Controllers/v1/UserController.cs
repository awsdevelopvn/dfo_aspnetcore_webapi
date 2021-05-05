using System.Threading.Tasks;
using DFO_Application.Features.Users.Commands;
using DFO_Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DFO_aspnetcore_api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        // GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery
            {
                PageNumber = 1, 
                PageSize = 10
            }));
        }
        
        // GET api/<controller>/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery{ Id =  id}));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}