using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DoAnThietKeWeb1.Models.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GorocoDatabaseContext _context;
        public ReviewRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews
            .OrderByDescending(r => r.ReviewDate)
            .ToList();

        }
        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public void UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
        }
        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
    }
}
