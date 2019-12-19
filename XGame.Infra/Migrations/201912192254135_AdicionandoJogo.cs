namespace XGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoJogo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 255),
                        Produtora = c.String(maxLength: 50),
                        Distribuidora = c.String(maxLength: 50),
                        Genero = c.String(maxLength: 50),
                        Site = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jogo");
        }
    }
}
