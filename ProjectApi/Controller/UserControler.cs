using BasicApi.Data.DTOs.UserDTO;
using BasicApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data.DTOs.UserDTO;

namespace BasicApi.Controllers
{
    [ApiController]
    [Route("/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUser _repository;

        public UserController(IUser repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult CriarUsers(CreateUserDTO createUserDTO)
        {
            var user = _repository.CreateUser(createUserDTO);
            return Created();
        }

        [HttpGet("{id}")]
        public ActionResult<ReadUserDTO> BuscarusersPorId(Guid id)
        {
            var user = _repository.BuscarUserPorId(id);
            if (user == null)
            {
                return NotFound("Usuario não foi encontrado");

            }

            return Ok(user);
        }

        [HttpGet("buscarTodosUsers")]
        public ActionResult<List<ReadUserDTO>> BuscarTodosUsers()
        {
            var users = _repository.BuscarTodosUsuarios();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public IActionResult ExluirUsersPorId(Guid id)
        {
            var user = _repository.BuscarUserPorId(id);
            if (user == null)
            {
                return NotFound("User não encontrado");
            }

            _repository.ExcluirUserPorID(id);
            return NoContent();
        }

    }
}
