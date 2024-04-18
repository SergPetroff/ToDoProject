using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetProject.Infrastructure;
using PetProject.Domain;
using PetProject.API.Contracts;

namespace PetProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private TodoDBContext _dbContext;
        public TodosController(TodoDBContext dbContext)
        {
            _dbContext = dbContext;

        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Todos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddTodoRequest addTodoRequest, CancellationToken ct)
        {
            var todo = new Todo(new Guid(), addTodoRequest.Title, addTodoRequest.Description, addTodoRequest.IsDone);
            
            await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
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
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateTodoRequest updatetodo)
        {
            _dbContext.Todos.Where(w => w.Id == id).ExecuteUpdate(updt =>
                updt
                    .SetProperty(t => t.Title, updatetodo.Title)
                    .SetProperty(t => t.Description, updatetodo.Description)
                    .SetProperty(t => t.IsDone, updatetodo.IsDone)

            );
            return Ok();
           
        }

    }
}
