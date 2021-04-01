namespace Rental_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyannonationstoCustomerBirthdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }
    }
}
