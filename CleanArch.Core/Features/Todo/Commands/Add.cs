using System.Threading;
using System.Threading.Tasks;
using CleanArch.Core.Data;
using MediatR;

namespace CleanArch.Core.Features.Todo.Commands
{
    public class AddTodo : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class AddHandler : IRequestHandler<AddTodo,int>
    {
        private readonly MyTodoDbContext _db;

        public AddHandler(MyTodoDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddTodo request, CancellationToken cancellationToken)
        {
            var todo = new Entities.Todo {Name = request.Name, Complete = false};
            _db.Add(todo);
            await _db.SaveChangesAsync(cancellationToken);

            return todo.Id;
        }
    }
}