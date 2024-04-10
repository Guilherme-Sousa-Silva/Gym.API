using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infra.Data.EntitiesConfiguration
{
    public class GymConfiguration : IEntityTypeConfiguration<Domain.Entities.Gym>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Gym> builder)
        {
            builder.ToTable("Gym");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cnpj)
                .IsRequired()
                .HasColumnName("Cnpj")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(16);

            builder.Property(x => x.RazaoSocial)
                .IsRequired()
                .HasColumnName("RazaoSocial")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.NomeFantasia)
               .IsRequired()
               .HasColumnName("NomeFantasia")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(50);
        }
    }
}
