using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebReservationService.Models;

namespace WebReservationService.Controllers
{
    public class GuestsController : ApiController
    {
        private DbReservationsEntities db = new DbReservationsEntities();

        // GET: api/Guests
        public IQueryable<Guest> GetGuest()
        {
            return db.Guest;
        }

        // GET: api/Guests/5
        [ResponseType(typeof(Guest))]
        public IHttpActionResult GetGuest(int id)
        {
            Guest guest = db.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        // PUT: api/Guests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuest(int id, Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guest.GuestId)
            {
                return BadRequest();
            }

            db.Entry(guest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Guests
        [ResponseType(typeof(Guest))]
        public IHttpActionResult PostGuest(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guest.Add(guest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = guest.GuestId }, guest);
        }

        // DELETE: api/Guests/5
        [ResponseType(typeof(Guest))]
        public IHttpActionResult DeleteGuest(int id)
        {
            Guest guest = db.Guest.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            db.Guest.Remove(guest);
            db.SaveChanges();

            return Ok(guest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestExists(int id)
        {
            return db.Guest.Count(e => e.GuestId == id) > 0;
        }

        // ---------------------------------
        // ------- CUSTOM METHOD -----------
        // ---------------------------------

        // drop guest named Piotr 
        // DELETE: api/Guests/DropGuest/?name=Piotr
        [ActionName("DropGuest")]
        [HttpDelete]
        [Route("api/Guests/DropGuest/")]
        public IHttpActionResult DropGuest(string name)
        {
            var guest = db.Guest
                .Where(s => s.Imie == name);

            db.Guest.RemoveRange(guest);
            db.SaveChanges();

            return Ok(guest);
        }
        // drop guest named Piotr from city Wrocław
        // DELETE: api/Guests/DropGuest/?name=Piotr&city=Wrocław
        [ActionName("DropGuest")]
        [HttpDelete]
        [Route("api/Guests/DropGuest/")]
        public IHttpActionResult DropGuest(string name, string city)
        {
            var guest = db.Guest
                .Where(s => (s.Imie == name && s.Miasto == city));

            db.Guest.RemoveRange(guest);
            db.SaveChanges();

            return Ok(guest);
        }
        //[Route("api/Guests/CreateGuest")]
        //[ActionName("CreateGuest")]
        //[HttpPost]
        //public IHttpActionResult CreateGuest(Guest guest)
        //{
        //    try
        //    {
        //        Guest sm = new Guest();

        //        db.Guest.Add(sm);
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }
        //    return Ok(guest);

        //}
    }
}