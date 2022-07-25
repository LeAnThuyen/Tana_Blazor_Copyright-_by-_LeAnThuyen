using API_Blazor.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Blazor.Respositories
{
    public interface IUserRepository
    {

        Task<List<User>> GetUserList();
    }
}
