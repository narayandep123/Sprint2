using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly Sprint2DBContext _context;
        public ProjectController(Sprint2DBContext context)
        {
            _context = context;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public IActionResult Get()
        {
            List<ProjectModel> project = _context.Projects.ToList();
            return Ok(project);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public ProjectModel Get(int id)
        {
            ProjectModel user = _context.Projects.FirstOrDefault(a => a.Id == id);

            return user;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectModel value)
        {
            _context.Projects.Add(value);
            _context.SaveChanges();
            return Ok("Success");
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectModel value)
        {
            ProjectModel projectToUpdate = _context.Projects.Where(a => a.Id == id).FirstOrDefault();
            if (projectToUpdate != null)
            {
                if (projectToUpdate.Name != value.Name)
                {
                    projectToUpdate.Name = value.Name;
                }
                if (projectToUpdate.Detail != value.Detail)
                {
                    projectToUpdate.Detail = value.Detail;
                }
                if (projectToUpdate.CreatedOn != value.CreatedOn)
                {
                    projectToUpdate.CreatedOn = value.CreatedOn;
                }
            }
            _context.Projects.Update(projectToUpdate);
            _context.SaveChanges();
            return Ok("Updated Successfully");
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProjectModel project = _context.Projects.Where(a => a.Id == id).FirstOrDefault();
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return Ok("Project Deleted");
        }
    }
}
