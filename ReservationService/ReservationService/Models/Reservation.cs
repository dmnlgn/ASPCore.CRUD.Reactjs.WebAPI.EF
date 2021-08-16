using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Models
{
    public class Reservation
    {
        //- Kod Rezerwacji(max 10 znaków), 
        //- Daty utworzenia,
        //- Cena, 
        //- Data zameldowania,
        //- Data wymeldowania,
        //- Waluta,
        //- Id.
        //Oraz pola opcjonalne:
        //- Prowizja,
        //- Źródło.
        [Column("Kod Rezerwacji")]
        [MaxLength(10, ErrorMessage = "ReservationCode must be 10 characters or less")]
        public string ReservationCode { get; set; }
        [Column("Data utworzenia", TypeName = "date")]
        public DateTime CreationDate { get; set; }
        [Column("Cena")]
        public int Price { get; set; }
        [Column("Data zameldowania", TypeName = "date")]
        public DateTime CheckInDate { get; set; }
        [Column("Data wymeldowania", TypeName = "date")]
        public DateTime CheckOutDate { get; set; }
        [Column("Waluta")]
        public string Currency { get; set; }
        [Column("Prowizja")]
        public double Commission { get; set; }
        [Key]
        public int ReservationId { get; set; }

        public ICollection<Guest> Guests { get; set; }
    }
}
