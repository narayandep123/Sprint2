using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly Sprint2DBContext _context;
        public UserController (Sprint2DBContext context)
        {
            _context = context;
        }
        
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UserModel> users = _context.Users.ToList();
            return Ok(users);
        }

        //Login API
        [HttpPost("{login}")]
        public bool Login(string email, string password)
        {
            return _context.Users.Where(x => x.Email == email && x.Password == password).Any();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            UserModel user = _context.Users.FirstOrDefault(a => a.Id == id);

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel userModel)
        {
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return Ok("Success");
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel userModel)
        {
            UserModel userToUpdate =  _context.Users.Where(a => a.Id == id).FirstOrDefault();
            if(userToUpdate !=null)
            {
                if(userToUpdate.Email != userModel.Email)
                {
                    userToUpdate.Email = userModel.Email;
                }
                if(userToUpdate.FirstName != userModel.FirstName)
                {
                    userToUpdate.FirstName = userModel.FirstName;
                }
                if (userToUpdate.Password != userModel.Password)
                {
                    userToUpdate.Password = userModel.Password;
                }
                if (userToUpdate.LastName != userModel.LastName)
                {
                    userToUpdate.LastName = userModel.LastName;
                }
            }

            return Ok("Updated Successfully");

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserModel user = _context.Users.Where(a=>a.Id == id).FirstOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok("User Deleted");
        }
    }
}
