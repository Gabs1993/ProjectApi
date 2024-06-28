namespace ProjectApi.Models
{
    public class Jogador
    {
        public Jogador(string nome, string posicao, int idade)
        {
            Nome = nome;
            Posicao = posicao;
            Idade = idade;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Posicao { get; set; } = string.Empty;

        public int Idade { get; set; }

        public Time Time { get; set; }

        public Guid? TimeId { get; set; }

    }
}
