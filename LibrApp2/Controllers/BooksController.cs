using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrApp2.Models;
using LibrApp2.ViewModels;
using Microsoft.AspNet.Identity;

namespace LibrApp2.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        [HttpGet]
        public ActionResult MyBookshelf()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.UserProfiles.Include(u => u.AspNetUser).SingleOrDefault(s => s.AspNetUserId == currentUserId);

            if (currentUser == null)
                return HttpNotFound();

            return View(currentUser);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddToBookshelf(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.UserProfiles.Include(u => u.AspNetUser).SingleOrDefault(s => s.AspNetUserId == currentUserId);
            var currentBook = db.Books.SingleOrDefault(b => b.Id == id);

            if (currentUser.Books.SingleOrDefault(b => b.Id == currentBook.Id) == null)
            {
                currentUser.Books.Add(currentBook);
                db.SaveChanges();
                return RedirectToAction("MyBookshelf");
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult RemoveFromBookshelf(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.UserProfiles.Include(u => u.AspNetUser).SingleOrDefault(s => s.AspNetUserId == currentUserId);
            var currentBook = db.Books.SingleOrDefault(b => b.Id == id);

            if (currentUser.Books.SingleOrDefault(b => b.Id == currentBook.Id) != null)
            {
                currentUser.Books.Remove(currentBook);
                db.SaveChanges();
            }
            return RedirectToAction("MyBookshelf");
        }

        [HttpGet]
        public ActionResult ShowAvailableAuthors(int bookId)
        {
            Book book = db.Books.Include(b => b.Authors).SingleOrDefault(b => b.Id == bookId);
            var alreadyAuthors = book.Authors.ToList();
            var authorsList = db.Authors.ToList().Except(alreadyAuthors).ToList();
            AuthorToBookViewModel authorToBook = new AuthorToBookViewModel()
            {
                AuthorsList = authorsList,
                AlreadyAuthors = alreadyAuthors,
                BookId = bookId,
                BookName = book.Name
            };

            //add instances to context
            //db.Books.Attach(book);

            //db.Authors.Attach(author);

            // add instance to navigation property
            //book.Authors.Add(author);

            //call SaveChanges from context to confirm inserts
            //db.SaveChanges();
            return View(authorToBook);
        }

        [HttpGet]
        public ActionResult AddAuthorToBook(int bookId, int authorId)
        {
            Book book = db.Books.SingleOrDefault(b => b.Id == bookId);
            Author author = db.Authors.SingleOrDefault(a => a.Id == authorId);

            //add instances to context
            db.Books.Attach(book);

            //db.Authors.Attach(author);

            // add instance to navigation property
            book.Authors.Add(author);

            //call SaveChanges from context to confirm inserts
            db.SaveChanges();

            return RedirectToAction("ShowAvailableAuthors", new { bookId = bookId });
        }

        [HttpGet]
        public ActionResult RemoveAuthorFromBook(int bookId, int authorId)
        {
            Book book = db.Books.Include(b => b.Authors).SingleOrDefault(b => b.Id == bookId);
            Author author = db.Authors.SingleOrDefault(a => a.Id == authorId);

            //add instances to context
            //db.Books.Attach(book);

            //db.Authors.Attach(author);

            // add instance to navigation property
            book.Authors.Remove(author);

            //call SaveChanges from context to confirm inserts
            db.SaveChanges();

            return RedirectToAction("ShowAvailableAuthors", new { bookId = bookId });

            //return RedirectToAction("RemoveAuthorFromBook", new { bookId = bookId, authorId = authorId });

        }
        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.Include(b => b.Genre).Include(b => b.Authors).ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Include(b => b.Genre).Include(b => b.Reviews).Include(b => b.Authors).Include(b => b.UserProfiles).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var GenresList = db.Genres.ToList();
            var bookViewModel = new BookViewModel()
            {
                Genres = GenresList
            };
            return View(bookViewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DatePublished,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            var GenresList = db.Genres.ToList();
            var bookViewModel = new BookViewModel()
            {
                Book = db.Books.Find(id),
                Genres = GenresList
            };

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(bookViewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DatePublished,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
