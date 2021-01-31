using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_CQRS_MediatR.Database;

namespace WebAPI_CQRS_MediatR.Commands
{
    public static class AddTodo
    {
        // Command
        public record Command(string Name) : IRequest<int>;

        // Handler
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly Repository _repository;

            public Handler(Repository repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var counter = _repository.Todos.Count + 1;
                _repository.Todos.Add(new Domain.Todo { Id = counter, Name = request.Name });
                return counter;
            }
        }
    }
}
