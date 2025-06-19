using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoAnThietKeWeb1.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly GorocoDatabaseContext _context;
        public ReviewController(IReviewRepository reviewRepository, GorocoDatabaseContext context)
        {
            _reviewRepository = reviewRepository;
            _context = context;
        }
        public IActionResult ReviewIndex()
        {
            // Ensure reviews is explicitly typed to avoid dynamic-related issues
            var reviews = _reviewRepository.GetAllReviews();

            // Fix CS0428 and CS8619 by ensuring Count is invoked and nullability is handled
            ViewBag.TotalReviews = reviews.Count();
            ViewBag.AverageRating = reviews.Any() ? reviews.Average(r => r.Rating ?? 0) : 0;

            ViewBag.StarCounts = Enumerable.Range(1, 5)
                .Reverse()
                .ToDictionary(star => star, star => reviews.Count(r => r.Rating == star));
            return View(reviews);
        }
    }
}
