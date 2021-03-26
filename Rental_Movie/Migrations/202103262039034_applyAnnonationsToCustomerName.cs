namespace Rental_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyAnnonationsToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
        }
    }
}
