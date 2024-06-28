namespace ProjectApi.Models
{
    public class Time
    {

        public Guid? Id { get; set; }

        public string NomeTime { get; set; } = string.Empty;

        public string Liga { get; set; } = string.Empty;

        public string Pais { get; set; } = string.Empty;
    }
}
