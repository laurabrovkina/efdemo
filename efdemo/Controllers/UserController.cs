using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace efdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        // constructor DI, it has been set up in Startup.cs
        public UserController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> users = _unitOfWork.Users.GetByFirstName("John").ToList();
            return users;
        }

        // GET: api/<UserController>/GetAllFirstNames
        [HttpGet("GetAllFirstNames")]
        public IEnumerable GetAllFirstNames()
        {
            IEnumerable users = _unitOfWork.Users.GetAllFirstNames();
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{firstName}")]
        public User Get(string lastName)
        {
            User user = _unitOfWork.Users.GetOnlyByFirstName(lastName);
            return user;
        }

        // GET api/<UserController>/countMatching/{firstName}
        [HttpGet("countMatching/{firstName}")]
        public int GetNumberOfMatchingFirstNames(string firstName)
        {
            var numberOfMatchingFirstNames = _unitOfWork.Users.CountMatchingFirstame(firstName);
            return numberOfMatchingFirstNames;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            // create user in memory
            _context.Users.Add(user);
            // apply changes to db
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get),
                new { id = user.UserId }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
