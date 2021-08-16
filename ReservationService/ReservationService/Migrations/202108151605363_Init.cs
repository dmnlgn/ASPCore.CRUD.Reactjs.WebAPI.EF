namespace ReservationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Email = c.String(),
                        Dataurodzenia = c.DateTime(name: "Data urodzenia", nullable: false, storeType: "date"),
                        Adrespocztowy = c.String(name: "Adres pocztowy"),
                        Reservation_ReservationId = c.Int(),
                    })
                .PrimaryKey(t => t.GuestId)
                .ForeignKey("dbo.Reservation", t => t.Reservation_ReservationId)
                .Index(t => t.Reservation_ReservationId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        KodRezerwacji = c.String(name: "Kod Rezerwacji", maxLength: 10),
                        Datautworzenia = c.DateTime(name: "Data utworzenia", nullable: false, storeType: "date"),
                        Cena = c.Single(nullable: false),
                        Datazameldowania = c.DateTime(name: "Data zameldowania", nullable: false, storeType: "date"),
                        Datawymeldowania = c.DateTime(name: "Data wymeldowania", nullable: false, storeType: "date"),
                        Waluta = c.String(),
                        Prowizja = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guest", "Reservation_ReservationId", "dbo.Reservation");
            DropIndex("dbo.Guest", new[] { "Reservation_ReservationId" });
            DropTable("dbo.Reservation");
            DropTable("dbo.Guest");
        }
    }
}
