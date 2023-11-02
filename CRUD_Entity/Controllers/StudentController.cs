using CRUD_Entity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;


        public StudentController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var value = _appDbContext.Students.ToList();
            return Ok(value);
        }
    }
}
