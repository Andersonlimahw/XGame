using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Map
{
    public class MapJogador : EntityTypeConfiguration<Jogador>
    {
        public MapJogador()
        {
            ToTable("JOGADOR");

            Property(p => p.Email.Endereco).HasMaxLength(200).IsRequired().HasColumnAnnotation("Index",
                new IndexAnnotation(
                    new IndexAttribute("UK_JOGADOR_EMAIL")
                    {
                        IsUnique = true
                    })
                ).HasColumnName("Email");

            // Caso não seja feito o mapeamento o entity faz um mapeamento automático porém com seu próprio padrão            
            Property(p => p.Nome.PrimeiroNome).HasMaxLength(50).IsRequired().HasColumnName("PrimeiroNome");
            Property(p => p.Nome.UltimoNome).HasMaxLength(100).IsRequired().HasColumnName("UltimoNome");
            Property(p => p.Senha).HasMaxLength(100).IsRequired().HasColumnName("Senha");
            Property(p => p.Status).IsRequired().HasColumnName("Status");
        }
    }
}
