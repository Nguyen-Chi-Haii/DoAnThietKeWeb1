using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;

namespace DoAnThietKeWeb1.Models.Services
{
    public class AboutRepository: IAboutRepository
    {
        private readonly GorocoDatabaseContext _context;
        public AboutRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
        IEnumerable<Gallery> IAboutRepository.GetGallery()
        {
            return _context.Galleries.ToList();
        }
    }

}
