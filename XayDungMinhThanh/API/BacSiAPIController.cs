﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using XayDungMinhThanh.Models;

namespace XayDungMinhThanh.API
{
    public class BacSiAPIController : ApiController
    {
        private MinhThanhEntities db = new MinhThanhEntities();

        // GET: api/BacSiAPI
        public IQueryable<BacSi> GetBacSis()
        {
            return db.BacSis;
        }

        // GET: api/BacSiAPI/5
        [ResponseType(typeof(BacSi))]
        public IHttpActionResult GetBacSi(int id)
        {
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return NotFound();
            }

            return Ok(bacSi);
        }

        //GET: API/BacSiAPI?att=...&&value=...
        public IQueryable<BacSi> GetBacSi(string att, string value)
        {
            var bacSi = db.BacSis;

            //bài viết trang chủ
            if (att == "bacSiHome" && att != null && value != null)
            {
                int number = int.Parse(value);
                var model = db.BacSis.Where(p => p.featured == 1).Take(number);

                return model;
            }

            return bacSi;
        }

        // PUT: api/BacSiAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBacSi(int id, BacSi bacSi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bacSi.id)
            {
                return BadRequest();
            }

            db.Entry(bacSi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BacSiExists(id))
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

        // POST: api/BacSiAPI
        [ResponseType(typeof(BacSi))]
        public IHttpActionResult PostBacSi(BacSi bacSi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BacSis.Add(bacSi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bacSi.id }, bacSi);
        }

        // DELETE: api/BacSiAPI/5
        [ResponseType(typeof(BacSi))]
        public IHttpActionResult DeleteBacSi(int id)
        {
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return NotFound();
            }

            db.BacSis.Remove(bacSi);
            db.SaveChanges();

            return Ok(bacSi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BacSiExists(int id)
        {
            return db.BacSis.Count(e => e.id == id) > 0;
        }
    }
}