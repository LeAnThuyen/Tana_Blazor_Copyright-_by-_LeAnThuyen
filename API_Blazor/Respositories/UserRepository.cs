using API_Blazor.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Blazor.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
