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
    public class VideoAPIController : ApiController
    {
        private MinhThanhEntities db = new MinhThanhEntities();

        // GET: api/VideoAPI
        public IQueryable<Video> GetVideos()
        {
            return db.Videos;
        }

        // GET: api/VideoAPI/5
        [ResponseType(typeof(Video))]
        public IHttpActionResult GetVideo(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        //GET: API/VideoAPI?att=...&&value=...
        public IQueryable<Video> GetVideo(string att, string value)
        {
            var video = db.Videos;

            //bài viết trang chủ
            if (att == "videoHome" && att != null && value != null)
            {
                int number = int.Parse(value);
                var model = db.Videos.OrderByDescending(p => p.id).Take(number);

                return model;
            }

            return video;
        }

        // PUT: api/VideoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideo(int id, Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.id)
            {
                return BadRequest();
            }

            db.Entry(video).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // POST: api/VideoAPI
        [ResponseType(typeof(Video))]
        public IHttpActionResult PostVideo(Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Videos.Add(video);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = video.id }, video);
        }

        // DELETE: api/VideoAPI/5
        [ResponseType(typeof(Video))]
        public IHttpActionResult DeleteVideo(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            db.Videos.Remove(video);
            db.SaveChanges();

            return Ok(video);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoExists(int id)
        {
            return db.Videos.Count(e => e.id == id) > 0;
        }
    }
}