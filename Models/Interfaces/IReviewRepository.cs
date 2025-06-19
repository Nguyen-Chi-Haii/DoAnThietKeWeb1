namespace DoAnThietKeWeb1.Models.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }
}
