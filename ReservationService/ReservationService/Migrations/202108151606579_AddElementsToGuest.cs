namespace ReservationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddElementsToGuest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guest", "Telefon", c => c.String());
            AddColumn("dbo.Guest", "Adres", c => c.String());
            AddColumn("dbo.Guest", "Miasto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guest", "Miasto");
            DropColumn("dbo.Guest", "Adres");
            DropColumn("dbo.Guest", "Telefon");
        }
    }
}
