namespace Rental_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate) VALUES (Pay, 10, 10, 10)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate) VALUES (Monthly, 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
