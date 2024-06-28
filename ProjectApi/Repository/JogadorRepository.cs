using AutoMapper;
using BasicApi.Data;
using BasicApi.Interface;
using ProjectApi.Data;
using ProjectApi.Data.DTOs.JogadorDTO;
using ProjectApi.Models;



namespace BasicApi.Repositorios
{
    public class JogadorRepository : IJogador
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public JogadorRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Jogador CriarJogador(CreateJogadorDTO createJogadorDTO)
        {
            if (createJogadorDTO.Idade < 16)
            {
                throw new Exception("Jogador não pode ser cadastrato, tem que ser maior de 16 anos!");
            }

            var jogador = _mapper.Map<Jogador>(createJogadorDTO);
            _context.Add(jogador);
            _context.SaveChanges();

            return jogador;
        }

        public Jogador? BuscarJogadorPorId(Guid id)
        {
            var jogador = _context.Jogadores.FirstOrDefault(j => j.Id == id);
            if (jogador == null) return null;

            return _mapper.Map<Jogador>(jogador);
        }

        public List<ReadJogadorDTO> BuscarTodosOsJogadores()
        {
            var jogador = _context.Jogadores.ToList();
            return _mapper.Map<List<ReadJogadorDTO>>(jogador);

        }

        public void ExcluirJogadorPorId(Guid id)
        {
            var jogador = _context.Jogadores.FirstOrDefault(j => j.Id == id);
            if (jogador != null)
            {
                _context.Jogadores.Remove(jogador);
                _context.SaveChanges();
            }
            else
            {
                StatusCodes.Status404NotFound.ToString("Jogador não encontrado");
            }
        }
    }
}
