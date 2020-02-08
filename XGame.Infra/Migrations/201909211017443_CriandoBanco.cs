namespace XGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JOGADOR",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Email = c.String(nullable: false, maxLength: 200),
                    PrimeiroNome = c.String(nullable: false, maxLength: 50),
                    UltimoNome = c.String(maxLength: 100),
                    Senha = c.String(nullable: false, maxLength: 100),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UK_JOGADOR_EMAIL");
            
            CreateTable(
                "dbo.Plataforma",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.JOGADOR", "UK_JOGADOR_EMAIL");
            DropTable("dbo.Plataforma");
            DropTable("dbo.JOGADOR");
        }
    }
}
