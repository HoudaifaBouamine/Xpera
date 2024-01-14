using App.API.Data;
using App.API.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TestController(AppDbContext db)
        {
            _db = db;
        }

        // NOTE : Must be deleted
        [HttpGet("Hash-All-Passwords")] public ActionResult HashAllExistedPasswords()
        {
            var users = _db.Users.ToList();

            for(int i = 0; i <  users.Count; i++)
            {
                users[i].HashedPassword = SecurityService.HashPassword(users[i].HashedPassword);
            }

            _db.SaveChanges();

            return Ok();
        }
    }
}
