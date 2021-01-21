namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Name_To_MembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));

            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = '1-Month' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = '3-Months' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = '12-Months' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
