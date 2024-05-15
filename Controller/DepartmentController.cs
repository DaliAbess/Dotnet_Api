using Api_Dotnet.Model;
using Api_Dotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
           _department = department;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive=null)
        {
            return Ok(_department.GetAllList(isActive));
        }
        [HttpGet]
        [Route("{id}")]
        public  IActionResult Get(int id)
        {
            var dept = _department.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);

        }

        [HttpPost]
        public IActionResult Post(AddUpdateDepartment obj)
        {
            var dept = _department.AddDeparement(obj);
            if(dept == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Deparment Created Successfully...!",
                id = dept!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody]  AddUpdateDepartment obj)
        {
            var dept = _department.UpdateDepartment(id, obj);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Deparement Updated Successfully...!",
                id = dept!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            
            if (!_department.DeleteDepartmentById(id))
            {
                return NotFound();
            }
            return Ok(new {
                message = "Department Deleted Successfully..!",
                id = id
            });
        }
    }
}