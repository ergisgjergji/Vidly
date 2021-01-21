namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified_Movies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Stock");

            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
