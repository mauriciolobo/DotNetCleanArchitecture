using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Core.Data;
using MediatR;

namespace CleanArch.Core.Features.Todo.Queries
{
    public class ListAll : IRequest<List<TodoDto>>
    {
        
    }

    public class TodoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Complete { get; set; }
    }

    public class ListAllHandler : IRequestHandler<ListAll, List<TodoDto>>
    {
        private readonly MyTodoDbContext _db;

        public ListAllHandler(MyTodoDbContext db)
        {
            _db = db;
        }
        public async Task<List<TodoDto>> Handle(ListAll request, CancellationToken cancellationToken)
        {
            return _db.Todos.Select(t => new TodoDto{Id = t.Id, Complete = t.Complete, Name = t.Name}).ToList();
        }
    }
}