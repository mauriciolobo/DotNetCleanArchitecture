using CleanArch.Core.Features.Todo.Commands;
using FluentValidation;

namespace CleanArch.Core.Features.Todo.Validations
{
    public class AddTodoValidation : AbstractValidator<AddTodo>
    {
        public AddTodoValidation()
        {
            RuleFor(t => t.Name).NotEmpty();
        }
    }
}