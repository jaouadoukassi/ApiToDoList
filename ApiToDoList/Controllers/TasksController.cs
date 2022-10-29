using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiToDoList.DataAccess;
using ApiToDoList.Models;

namespace ApiToDoList.Controllers
{
    [Route("api/[controller]")] // localhost:7261/api/Tasks
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ClsTodoList _context;

        public TasksController(ClsTodoList context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClsBaseEntity>>> GetTasksTable()
        {
            return await _context.TasksTable.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClsBaseEntity>> GetClsBaseEntity(int id)
        {
            var clsBaseEntity = await _context.TasksTable.FindAsync(id);

            if (clsBaseEntity == null)
            {
                return NotFound();
            }

            return clsBaseEntity;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClsBaseEntity(int id, ClsBaseEntity clsBaseEntity)
        {
            if (id != clsBaseEntity.Id)
            {
                return BadRequest();
            }

            // buscar la entrada de clsBaseEntity y ponerlo en el estado modificado.
            // para que sea modificado.
            _context.Entry(clsBaseEntity).State = EntityState.Modified;           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsBaseEntityExists(id))
                {
                    return NotFound(); // método de .Net que nos devuelva un error de 404
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tasks // localhost:7261/api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClsBaseEntity>> PostClsBaseEntity(ClsBaseEntity clsBaseEntity)
        {
            _context.TasksTable.Add(clsBaseEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClsBaseEntity", new { id = clsBaseEntity.Id }, clsBaseEntity);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClsBaseEntity(int id)
        {
            var clsBaseEntity = await _context.TasksTable.FindAsync(id);
            if (clsBaseEntity == null)
            {
                return NotFound();
            }

            _context.TasksTable.Remove(clsBaseEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClsBaseEntityExists(int id)
        {
            return _context.TasksTable.Any(TasksTable => TasksTable.Id == id);
        }
    }
}
