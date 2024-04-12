using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetProject.Data;
using PetProject.Model;

namespace PetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private TodoDBContext _dbContext;
        public TodosController(TodoDBContext dbContext)
        {
            this._dbContext = dbContext;

        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Todos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoRequest addTodoRequest)
        {
            var todo = new Todo()
            {
                Id = new Guid(),
                Title = addTodoRequest.Title,
                Description = addTodoRequest.Description,
            };
            await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodo([FromRoute] Guid id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, UpdateTodoRequest updatetodo)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.Title = updatetodo.Title;
                todo.Description = updatetodo.Description;
                todo.IsDone = updatetodo.IsDone;
                await _dbContext.SaveChangesAsync();
                return Ok(todo);
            }

            return NotFound();

        }

    }
}
