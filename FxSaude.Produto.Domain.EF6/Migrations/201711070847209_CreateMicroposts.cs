namespace FxSaude.Produto.Domain.EF6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMicroposts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Microposts",
                    c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Microposts", "User_Id", "dbo.Users");
            DropIndex("dbo.Microposts", new[] { "User_Id" });
            DropTable("dbo.Microposts");
        }
    }
}
