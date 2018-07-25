using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly TodoContext _context;

		public TodoController(TodoContext context)
		{
			_context = context;

			if (_context.TodoItems.Count() == 0)
			{
				_context.TodoItems.Add(new TodoItem { Name = "Item1" });
				_context.SaveChanges();
			}
		}
	}
}
