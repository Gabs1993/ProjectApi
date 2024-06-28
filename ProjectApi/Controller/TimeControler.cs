using BasicApi.Data.DTOs.TimeDTO;
using BasicApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimeControler : ControllerBase
    {
        private readonly ITime _repository;

        public TimeControler(ITime repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult CriarTime(CreateTimeDTO createTimeDTO)
        {
            var time = _repository.CriarTime(createTimeDTO);
            return CreatedAtAction(nameof(_repository.CriarTime), new { id = time.NomeTime }, time);
        }

        [HttpGet("buscarTimesPorId")]
        public ActionResult<ReadTimeDTO> BuscarTimesPorId(Guid id)
        {
            var time = _repository.BuscarTimePorId(id);
            if (time == null)
            {
                return NotFound("Time não encontrado");
            }
            return Ok(time);
        }

        [HttpGet("buscarTodosOsTimes")]
        public ActionResult<ReadTimeDTO[]> BuscarTimes()
        {
            var time = _repository.BuscarTodosOsTimes();
            return Ok(time);
        }


        [HttpDelete("{id}")]
        public IActionResult ExcluirTimePorId(Guid id)
        {
            var time = _repository.BuscarTimePorId(id);
            if (time == null)
            {
                return NotFound("Time não encontrado");
            }

            _repository.ExluirTimes(id);
            return NoContent();
        }


    }
}
