using DoAnThietKeWeb1.Data;
using DoAnThietKeWeb1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DoAnThietKeWeb1.Models.Services
{
    public class ContactRepository: IContactRepository
    {
        private readonly GorocoDatabaseContext _context;
        public ContactRepository(GorocoDatabaseContext context)
        {
            _context = context;
        }
        public void Add(ContactMessage message) => _context.ContactMessages.Add(message);

        public List<ContactMessage> GetLatest(int count = 5)
        {
            return _context.ContactMessages
                .OrderByDescending(m => m.SentAt)
                .Take(count)
                .ToList();
        }

        public int CountUnread() => _context.ContactMessages.Count(m => !m.IsRead);

        public void SaveChanges() => _context.SaveChanges(); 
    }
}
