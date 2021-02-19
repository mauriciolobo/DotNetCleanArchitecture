using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Core.Data;
using MediatR;

namespace CleanArch.Core.Features.Todo.Commands
{
    public class CompleteTodo : IRequest
    {
        public int TodoId { get; set; }
    }

    public class CompleteTodoHandler : AsyncRequestHandler<CompleteTodo>
    {
        private readonly MyTodoDbContext _db;

        public CompleteTodoHandler(MyTodoDbContext db)
        {
            _db = db;
        }

        protected override async Task Handle(CompleteTodo request, CancellationToken cancellationToken)
        {
            var todo = _db.Todos.First(t => t.Id == request.TodoId);
            todo.CompleteTask();
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}