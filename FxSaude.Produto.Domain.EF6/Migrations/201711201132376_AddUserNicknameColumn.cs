namespace FxSaude.Produto.Domain.EF6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNicknameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Nickname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Nickname");
        }
    }
}
