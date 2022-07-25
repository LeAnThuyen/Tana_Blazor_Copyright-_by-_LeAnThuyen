using API_Blazor.Respositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace API_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepositoty;
        public UsersController(IUserRepository userRepositoty)
        {
            _userRepositoty = userRepositoty;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepositoty.GetUserList();
            var Assignees = users.Select(c => new AssigneeDTO()
            {
                Id = c.Id,
                FullName = c.FirstName + " " + c.LastName
            });
            return Ok(Assignees);
        }
    }
}
