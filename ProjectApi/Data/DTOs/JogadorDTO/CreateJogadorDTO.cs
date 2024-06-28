

namespace ProjectApi.Data.DTOs.JogadorDTO
{
    public class CreateJogadorDTO
    {
        public string Nome { get; set; } = string.Empty;

        public string Posicao { get; set; } = string.Empty;

        public int Idade { get; set; }

        public Guid? TimeId { get; set; }
    }
}
