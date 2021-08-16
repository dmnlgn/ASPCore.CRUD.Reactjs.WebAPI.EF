﻿using Microsoft.AspNetCore.Mvc;
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
    public class ReservationsController : ApiController
    {
        private DbReservationsEntities db = new DbReservationsEntities();

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservation()
        {
            return db.Reservation;
        }

        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            Reservation reservation = db.Reservation.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            db.Entry(reservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
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

        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservation.Add(reservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reservation.ReservationId }, reservation);
        }

        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult DeleteReservation(int id)
        {
            Reservation reservation = db.Reservation.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservation.Remove(reservation);
            db.SaveChanges();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(int id)
        {
            return db.Reservation.Count(e => e.ReservationId == id) > 0;
        }

        // ---------------------------------
        // ------- CUSTOM METHOD -----------
        // ---------------------------------

        //drop all reservations
        //DELETE: api/Reservations/DropReservations
        [ActionName("DropReservations")]
        [HttpDelete]
        [Route("api/Reservations/DropReservations/")]
        public IHttpActionResult DropReservations()
        {
            var reservation = db.Reservation
                .ToList();

            if (reservation == null)
            {
                return NotFound();
            }

            db.Reservation.RemoveRange(reservation);
            db.SaveChanges();

            return Ok(reservation);
        }

        ////create reservation and guest
        //[ActionName("CreateReservation")]
        //[HttpPost]
        //[Route("api/Reservations/CreateReservation/")]
        //public IHttpActionResult CreateReservation([FromBody] Reservation reservation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Reservation.Add(reservation);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = reservation.ReservationId }, reservation);
        //}

        [Route("CreateReservation")]
        [HttpPost]
        public object CreateReservation(Reservation reservation)
        {
            try
            {
                Reservation sm = new Reservation();
                sm.ReservationId = reservation.ReservationId;
                sm.Kod_Rezerwacji = reservation.Kod_Rezerwacji;

                db.Reservation.Add(sm);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return Ok(reservation);

        }
    }
}