using CRUD_Entity.Data;
using CRUD_Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var value = _appDbContext.Customers.ToList();
            return Ok(value);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatStudent(Customers customers)
        {
        

            await _appDbContext.Customers.AddAsync(customers);
            await _appDbContext.SaveChangesAsync();
            return Ok(customers);
        }

        [HttpPatch]
        public async ValueTask<IActionResult> UpdateCustomer(int id,string name)
        {
            var value=await _appDbContext.Customers.FirstOrDefaultAsync(customer=>customer.id==id);
            if(value!=null)
            {
                value.name = name;
                _appDbContext.Update(value);
                await _appDbContext.SaveChangesAsync();
            }
            return Ok(value);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudent(int Id)
        {
            var value=await _appDbContext.Customers.FirstOrDefaultAsync(x=>x.id==Id);
            if(value!=null)
            {
                _appDbContext.Customers.Remove(value);
                await _appDbContext.SaveChangesAsync();
            }
            return Ok(value);
        }



    }
}
