namespace XGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JOGADOR",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PrimeiroNome = c.String(nullable: false, maxLength: 50),
                        UltimoNome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        Senha = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UK_JOGADOR_EMAIL");
            
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
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.JOGADOR", "UK_JOGADOR_EMAIL");
            DropTable("dbo.Plataforma");
            DropTable("dbo.Jogo");
            DropTable("dbo.JOGADOR");
        }
    }
}
