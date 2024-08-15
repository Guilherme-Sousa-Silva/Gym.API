namespace Gym.Domain.Entities
{
    public class Gym
    {
        public Gym(string cnpj, string razaoSocial, string nomeFantasia)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public Guid Id { get; private set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }

        public bool Validate(Gym gym)
        {
            if (gym == null) return false;
            if (gym.Id == Guid.Empty) return false;
            if (string.IsNullOrEmpty(gym.Cnpj)) return false;
            if (string.IsNullOrEmpty(gym.RazaoSocial)) return false;
            if (string.IsNullOrEmpty(gym.NomeFantasia)) return false;

            return true;
        }
    }
}
