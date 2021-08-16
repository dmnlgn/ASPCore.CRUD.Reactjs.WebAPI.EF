namespace ReservationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeType2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservation", "Cena", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservation", "Cena", c => c.Double(nullable: false));
        }
    }
}
