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
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ShowReviews(int id)
        {
            var currentBook = db.Books.Include(b => b.Reviews).SingleOrDefault(b => b.Id == id);
            var reviews = currentBook.Reviews.ToList();

            return View(reviews);
        }

        public ActionResult ShowSingleReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();
            var review = db.Reviews.SingleOrDefault(r => r.BookId == id && r.UserProfile.AspNetUserId == userId);
            return View(review);
        }

        public ActionResult AddReview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview([Bind(Include = "Id, Content, Rate")] Review review, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                review.BookId = (int)id;
                string userId = User.Identity.GetUserId();
                UserProfile userProfile = db.UserProfiles.SingleOrDefault(u => u.AspNetUserId == userId);
                review.UserProfile = userProfile;
                if (!db.Reviews.Where(
                    r => r.UserProfile.AspNetUserId == review.UserProfile.AspNetUserId && r.BookId == review.BookId).Any())
                {

                    db.Reviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("MyBookshelf", "Books");
                }
            }
            return View(review);
        }

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Book).Include(r => r.UserProfile);
            return View(reviews.ToList());
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.SingleOrDefault(r => r.Id == id);

            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Rate,BookId,UserProfileId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(string userId, int? bookId)
        {
            if (userId == null || bookId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.SingleOrDefault(r => r.UserProfile.AspNetUserId == userId && r.BookId == bookId);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string userId, int? bookId)
        {
            Review review = db.Reviews.SingleOrDefault(r => r.UserProfile.AspNetUserId == userId && r.BookId == bookId);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("MyBookshelf", "Books");
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