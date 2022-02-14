namespace LoginGoogle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioModulos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.String(),
                        IdModulo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modulos", t => t.IdModulo, cascadeDelete: true)
                .Index(t => t.IdModulo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioModulos", "IdModulo", "dbo.Modulos");
            DropIndex("dbo.UsuarioModulos", new[] { "IdModulo" });
            DropTable("dbo.UsuarioModulos");
        }
    }
}
