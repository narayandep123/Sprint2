using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly Sprint2DBContext _context;
        public TaskController(Sprint2DBContext context)
        {
            _context = context;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            List<TaskModel> task = _context.Tasks.ToList();
            return Ok(task);
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TaskModel task = _context.Tasks.FirstOrDefault(a => a.Id == id);
            return Ok(task);
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskModel value)
        {
            _context.Tasks.Add(value);
            _context.SaveChanges();
            return Ok("Task Added");
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TaskModel value)
        {
            TaskModel taskToUpdate = _context.Tasks.FirstOrDefault(a => a.Id == id);
            if (taskToUpdate != null)
            {
                if (taskToUpdate.ProjectId != value.ProjectId)
                {
                    taskToUpdate.ProjectId = value.ProjectId;
                }
                if (taskToUpdate.Detail != value.Detail)
                {
                    taskToUpdate.Detail = value.Detail;
                }
                if (taskToUpdate.CreatedOn != value.CreatedOn)
                {
                    taskToUpdate.CreatedOn = value.CreatedOn;
                }
                if (taskToUpdate.Status != value.Status)
                {
                    taskToUpdate.Status = value.Status;
                }
                if (taskToUpdate.AssignedToUserID != value.AssignedToUserID)
                {
                    taskToUpdate.AssignedToUserID = value.AssignedToUserID;
                }
            }
            _context.Tasks.Update(taskToUpdate);
            _context.SaveChanges();
            return Ok(taskToUpdate);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TaskModel task = _context.Tasks.Where(a => a.Id == id).FirstOrDefault();
            _context.Tasks.Remove(task);
            return Ok("deleted");
        }
    }
}
