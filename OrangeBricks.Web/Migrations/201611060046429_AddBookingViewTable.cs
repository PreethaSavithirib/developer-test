namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingViewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        ViewDate = c.DateTime(nullable: false),
                        BookingStatus = c.Int(nullable: false),
                        Buyer_Id = c.String(),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Bookings", new[] { "Property_Id" });
            DropTable("dbo.Bookings");
        }
    }
}
