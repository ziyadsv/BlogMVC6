namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Token",
                c => new
                    {
                        TokenId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AuthToken = c.String(),
                        IssuedOn = c.DateTime(nullable: false),
                        ExpiresOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Token");
            DropTable("dbo.Product");
        }
    }
}
