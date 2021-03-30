namespace Rental_Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAvaliableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvaliable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NumberAvaliable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvaliable");
        }
    }
}
