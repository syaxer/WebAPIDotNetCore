using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly EmployeeDetailContext _context;

        public EmployeeDetailsController(EmployeeDetailContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GettblEmployee()
        {
            return await _context.tblEmployee.ToListAsync();
        }

        // GET: api/EmployeeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeDetail(short id)
        {
            var employeeDetail = await _context.tblEmployee.FindAsync(id);

            if (employeeDetail == null)
            {
                return NotFound();
            }

            return employeeDetail;
        }

        // PUT: api/EmployeeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetail(short id, EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmpID)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
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

        // POST: api/EmployeeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            _context.tblEmployee.Add(employeeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeDetail), new { id = employeeDetail.EmpID }, employeeDetail);
        }

        // DELETE: api/EmployeeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetail(short id)
        {
            var employeeDetail = await _context.tblEmployee.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            _context.tblEmployee.Remove(employeeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDetailExists(short id)
        {
            return _context.tblEmployee.Any(e => e.EmpID == id);
        }
    }
}
