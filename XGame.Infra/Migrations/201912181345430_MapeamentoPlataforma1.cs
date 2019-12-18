namespace XGame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapeamentoPlataforma1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plataforma", "Nome", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plataforma", "Nome", c => c.Int(nullable: false));
        }
    }
}
