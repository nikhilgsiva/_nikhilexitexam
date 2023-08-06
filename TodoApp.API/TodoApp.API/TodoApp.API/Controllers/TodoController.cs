﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.Data;
using TodoApp.API.Models;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _todoDbContext;

        public TodoController(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTodo()

        {
            var todos = await _todoDbContext.Todos
            .Where(x => x.IsDeleted == false)            
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
            return Ok(todos);

        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(Todo todo)

        {
            todo.ID = Guid.NewGuid();
            _todoDbContext.Todos.Add(todo);
            await _todoDbContext.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, Todo todoUpdateRequest)
        {
            var todo = await _todoDbContext.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            todo.IsCompleted = todoUpdateRequest.IsCompleted;

            await _todoDbContext.SaveChangesAsync();

            return Ok(todo);

        }
        
         [HttpDelete]
         [Route("{id:Guid}")]
          public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
         var todo = await _todoDbContext.Todos.FindAsync(id);
        if (todo == null)
        return NotFound();

        todo.IsDeleted = true ; 
        todo.DeletedDate = DateTime.Now;
        await _todoDbContext.SaveChangesAsync();
        return Ok(todo);
        }

        }
    }