namespace Gym.Application.DTOs.Gym
{
    public class GymDTO
    {
        public GymDTO(Guid id, string cnpj, string razaoSocial, string nomeFantasia)
        {
            Id = id;
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
    }
}
