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
    public class PostAPIController : ApiController
    {
        private MinhThanhEntities db = new MinhThanhEntities();

        // GET: api/PostAPI
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/PostAPI/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        //GET: API/PostAPI?att=...&&value=...
        public IQueryable<Post> GetPost(string att, string value)
        {
            var post = db.Posts;

            //bài viết trang chủ
            if (att == "postHome" && att != null && value != null)
            {
                int number = int.Parse(value);
                var model = db.Posts.Where(p => p.featured == true).OrderByDescending(p => p.timePublished).Take(number);

                return model;
            }

            //Lấy tất cả bài giới thiệu
            if (att == "gioiThieu" && att != null && value != null)
            {
                int id = int.Parse(value);
                var model = db.Posts.Where(p => p.idCategory == 3 && p.id != id).OrderBy(p => p.timePublished);

                return model;
            }

            return post;
        }

        // PUT: api/PostAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/PostAPI
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.id }, post);
        }

        // DELETE: api/PostAPI/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.id == id) > 0;
        }
    }
}