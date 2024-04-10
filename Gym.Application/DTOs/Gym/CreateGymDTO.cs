using System.Text.Json.Serialization;

namespace Gym.Application.DTOs.Gym
{
    public class CreateGymDTO
    {
        public CreateGymDTO(string cnpj, string razaoSocial, string nomeFantasia)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        [JsonIgnore]
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
    }
}
