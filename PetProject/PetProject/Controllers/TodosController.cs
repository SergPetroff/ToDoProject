﻿using Microsoft.AspNetCore.Http;
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

        private TodoDBContext dbContext;
        public TodosController(TodoDBContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]

        public async Task<IActionResult> GetTodos()
        {
            return Ok(await dbContext.Todos.ToListAsync());
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
            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodo([FromRoute] Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
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
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.Title = updatetodo.Title;
                todo.Description = updatetodo.Description;
                todo.IsDone = updatetodo.IsDone;
                await dbContext.SaveChangesAsync();
                return Ok(todo);
            }

            return NotFound();

        }

    }
}
