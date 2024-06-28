using ProjectApi.Data.DTOs.JogadorDTO;
using ProjectApi.Models;

namespace BasicApi.Interface
{
    public interface IJogador
    {
        Jogador CriarJogador(CreateJogadorDTO createJogadorDTO);

        Jogador BuscarJogadorPorId(Guid id);

        List<ReadJogadorDTO> BuscarTodosOsJogadores();

        void ExcluirJogadorPorId(Guid id);


    }
}
