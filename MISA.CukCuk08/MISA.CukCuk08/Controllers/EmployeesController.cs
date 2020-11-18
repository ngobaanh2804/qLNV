using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MISA.CukCuk08.Models;

namespace MISA.CukCuk08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DBContext _context;
        
        public EmployeesController(DBContext context)
        {
            _context = context;
        }

       /// <summary>
       /// API Lấy dữ liệu từ database để truyền lên Client
       /// </summary>
       /// <returns>List nhân viên</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.OrderByDescending(n => n.EmployeeCode).Take(50).ToListAsync();
           
        }

        /// <summary>
        /// Lấy ra số lượng bản ghi
        /// </summary>
        /// <returns></returns>
        [Route("[action]/count")]
        [HttpGet]
        public  int GetNumEmployee()
        {
            try
            {
                int sql = _context.Employee.Count();


                return sql;
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }

        /// <summary>
        /// Phân trang bảng dữ liệu
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("[action]/{pageNum}/{pageSize}")]
        [HttpGet]
        public List<Employee> Pagging([FromRoute] int pageNum, [FromRoute] int pageSize)
        {
            try
            {
                List<Employee> data = null;

                data = _context.Employee.OrderByDescending(n => n.EmployeeCode).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        /// <summary>
        /// Lấy ra một nhân viên theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            try
            {
                var employee = await _context.Employee.FindAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return employee;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        /// <summary>
        /// API sửa nhân viên theo EmployeeId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Api thêm nhân viên 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
           
            try
            {
              
                    _context.Employee.Add(employee);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
              
            }
            catch (Exception)
            {

                throw;
            }
          
            
           
        }

        /// <summary>
        ///  Api xử lý file ảnh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns>Employee</returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Employee>> PatchEmployee(Guid id, IFormFile file)
        {
            try
            {
                var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                if (file.Length > 0)
                {
                   
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "content", "upload", filename);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                else
                    return NotFound();
                Employee employee = _context.Employee.Where(ms => ms.EmployeeId.Equals(id)).FirstOrDefault();
                //var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                employee.ImageUrl = Path.Combine("content", "upload", filename);
                _context.SaveChanges();
                return employee;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Xóa nhân viên theo EmployeeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _context.Employee.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        /// <summary>
        /// Xóa một list nhân viên
        /// </summary>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee([FromBody]List<Guid> employeeIds)
        {
            try
            {
                List<Employee> lstEmployeeDelete = new List<Employee>();
                foreach (var employeeId in employeeIds)
                {
                    var employee = await _context.Employee.FindAsync(employeeId);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    else
                        lstEmployeeDelete.Add(employee);
                }



                _context.Employee.RemoveRange(lstEmployeeDelete);
                await _context.SaveChangesAsync();

                return Ok("Success");
            }
            catch (Exception)
            {

                throw;
            }

        }


        private bool EmployeeExists(Guid id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
