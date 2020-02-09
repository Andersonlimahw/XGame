using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {
        // base -> connectionstring
        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        // representações das entidades
        public IDbSet<Jogador> Jogadores { get; set; }

        public IDbSet<Plataforma> Plataformas { get; set; }

        public IDbSet<Jogo> Jogos { get; set; }

        // 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Seta o chema default.

            // modelBuilder.HasDefaultSchema("Apoio");

            // remove pluralização dos nomes das tabelas 
            // interessante devido a pluralização em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Remove exclusões em cascata, opcional
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Setar para usar varchar ao invés de nvarchar.

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            // Mapeia as entidades manualmente
            // modelBuilder.Configurations.Add(new VeiculoMap());

            // Mapeia as entidades automaticamente
            #region Adiciona entidades mapeadas automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
