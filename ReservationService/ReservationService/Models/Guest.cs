using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationService.Models
{
    public class Guest
    {
        //- Imię,
        //- Nazwisko,
        //- E-mail,
        //- Id.
        //+ opcjonalne pola
        //- Data urodzenia,
        //- Kod pocztowy.
        [Key]
        public int GuestId { get; set; }
        [Column("Imie")]
        public string Name { get; set; }
        [Column("Nazwisko")]
        public string Surname { get; set; }
        public string Email { get; set; }
        [Column("Data urodzenia", TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column("Adres pocztowy")]
        public string ZipCode { get; set; }
        [Column("Telefon")]
        public string Phone { get; set; }
        [Column("Adres")]
        public string Adress { get; set; }
        [Column("Miasto")]
        public string City { get; set; }

        //one-to-many relationships
        public Reservation Reservation { get; set; }
    }
}
