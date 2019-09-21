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
                        PRIMEIRO_NOME = c.String(nullable: false, maxLength: 50),
                        Nome_UltimoNome = c.String(maxLength: 100),
                        ULTIMO_NOME = c.String(nullable: false, maxLength: 50),
                        SENHA = c.String(nullable: false, maxLength: 100),
                        STATUS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ULTIMO_NOME, unique: true, name: "UK_JOGADOR_EMAIL");
            
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
