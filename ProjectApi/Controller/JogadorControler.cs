using BasicApi.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data.DTOs.JogadorDTO;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JogadorControler : ControllerBase
    {
        private readonly IJogador _repository;

        public JogadorControler(IJogador repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult CriarJogador(CreateJogadorDTO createJogadorDTO)
        {
            var jogador = _repository.CriarJogador(createJogadorDTO);
            return CreatedAtAction(nameof(_repository.BuscarJogadorPorId), new { id = jogador.Id }, jogador);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadJogadorDTO> BuscarJogadorPorId(Guid id)
        {
            var jogador = _repository.BuscarJogadorPorId(id);
            if (jogador == null)
            {
                return NotFound("Jogador não encontrado");
            }
            return Ok(jogador);
        }

        [HttpGet("buscarTodosJogadores")]
        public ActionResult<List<ReadJogadorDTO>> BuscarTodosOsJogadores()
        {
            var jogadores = _repository.BuscarTodosOsJogadores();
            return Ok(jogadores);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirJogadorPorId(Guid id)
        {
            var jogador = _repository.BuscarJogadorPorId(id);
            if (jogador == null)
            {
                return NotFound("Jogador não encontrado");
            }

            _repository.ExcluirJogadorPorId(id);
            return NoContent();
        }
    }
}
