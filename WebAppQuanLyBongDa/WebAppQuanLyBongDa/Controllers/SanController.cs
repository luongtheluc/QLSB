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
using WebAppQuanLyBongDa.Models;

namespace WebAppQuanLyBongDa.Controllers
{
    public class SanController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/San
        [Route("SanBongDa")]
        public IQueryable<SAN> GetSANs()
        {
            return db.SANs;
        }

        // GET: api/San/5
        [ResponseType(typeof(SAN))]
        public IHttpActionResult GetSAN(int id)
        {
            SAN sAN = db.SANs.Find(id);
            if (sAN == null)
            {
                return NotFound();
            }

            return Ok(sAN);
        }

        // PUT: api/San/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSAN(int id, SAN sAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sAN.MASAN)
            {
                return BadRequest();
            }

            db.Entry(sAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SANExists(id))
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

        // POST: api/San
        [ResponseType(typeof(SAN))]
        public IHttpActionResult PostSAN(SAN sAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SANs.Add(sAN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sAN.MASAN }, sAN);
        }

        // DELETE: api/San/5
        [ResponseType(typeof(SAN))]
        public IHttpActionResult DeleteSAN(int id)
        {
            SAN sAN = db.SANs.Find(id);
            if (sAN == null)
            {
                return NotFound();
            }

            db.SANs.Remove(sAN);
            db.SaveChanges();

            return Ok(sAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SANExists(int id)
        {
            return db.SANs.Count(e => e.MASAN == id) > 0;
        }
    }
}