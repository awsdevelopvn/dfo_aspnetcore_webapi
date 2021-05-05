using System.Threading.Tasks;
using DFO_Application.DTOs.User;
using DFO_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DFO_aspnetcore_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _userService.GetAllAsync());
        }
        
        // GET api/<controller>/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserRequest request)
        {
            return Ok(await _userService.RegisterAsync(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            return Ok(await _userService.Update(request));
        }
    }
}