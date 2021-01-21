namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_Rental_ReturnDate_ToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "ReturnDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "ReturnDate", c => c.DateTime(nullable: false));
        }
    }
}
