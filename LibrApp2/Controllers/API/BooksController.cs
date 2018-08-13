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
using LibrApp2.Models;
using LibrApp2.DTOs;
using System.Web.Mvc;

namespace LibrApp2.Controllers.API
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Books
        public IQueryable<BookDTO> GetBooks()
        {
            //var reviews = from r in db.Reviews
            //              select new ReviewDTO()
            //              {
            //                  Id = r.Id,
            //                  Rate = r.Rate,
            //                  Content = r.Content,
            //                  BookId = r.BookId,
            //                  BookName = r.Book.Name,
            //                  UserProfileId = r.UserProfile.Id,
            //                  UserProfileUsername = r.UserProfile.Username
            //              };

            var books = from b in db.Books
                        select new BookDTO()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            DatePublished = b.DatePublished,
                            GenreId = b.GenreId,
                            Genre = b.Genre.Name,
                            AverageRating = b.AverageRating,
                            AuthorFullNames = b.Authors.Select(a => a.FullName).ToList(),
                            //ReviewsDTOs = reviews.Where(r => r.BookId == b.Id).ToList(),
                            //UserProfileUsernames = b.UserProfiles.Select(u => u.Username).ToList(),
                            //UserProfileIds = b.UserProfiles.Select(u => u.Id).ToList()
                        };

            return books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookDTO))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Include(b => b.Genre).Include(b => b.Authors).Include(b => b.UserProfiles).Include(b => b.Reviews).SingleOrDefault(b => b.Id == id);

            var reviewDTOs = from r in book.Reviews
                          select new ReviewDTO()
                          {
                              Id = r.Id,
                              Rate = r.Rate,
                              Content = r.Content,
                              UserProfileId = r.UserProfile.Id,
                              UserProfileUsername = r.UserProfile.Username
                          };

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                DatePublished = book.DatePublished,
                GenreId = book.GenreId,
                Genre = book.Genre.Name,
                AverageRating = book.AverageRating,
                AuthorFullNames = book.Authors.Select(a => a.FullName).ToList(),
                ReviewsDTOs = reviewDTOs.ToList(),
                UserProfileUsernames = book.UserProfiles.Select(u => u.Username).ToList(),
                UserProfileIds = book.UserProfiles.Select(u => u.Id).ToList()
            };


            return Ok(bookDto);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, BookDTO bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookDto.Id)
            {
                return BadRequest();
            }

            var bookInDb = db.Books.SingleOrDefault(b => b.Id == id);

            bookInDb.Id = bookDto.Id;
            bookInDb.Name = bookDto.Name;
            bookInDb.DatePublished = bookDto.DatePublished;
            bookInDb.GenreId = bookDto.GenreId;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(BookDTO bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookToDb = new Book()
            {
                Id = bookDto.Id,
                Name = bookDto.Name,
                DatePublished = bookDto.DatePublished,
                GenreId = bookDto.GenreId
            };

            db.Books.Add(bookToDb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookToDb.Id }, bookToDb);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}