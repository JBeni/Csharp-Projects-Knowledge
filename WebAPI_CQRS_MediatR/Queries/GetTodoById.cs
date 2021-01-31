using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_CQRS_MediatR.Database;

namespace WebAPI_CQRS_MediatR.Queries
{
    public class GetTodoById
    {
        // Query / Command
        // All the data we need to execute
        public record Query(int Id) : IRequest<Response>;

        // Handler
        // All the business logic to execute. Returns a response.
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository _repository;

            public Handler(Repository repository)
            {
                _repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var todo = _repository.Todos.FirstOrDefault(x => x.Id == request.Id);
                return todo == null ? null : new Response(todo.Id, todo.Name, todo.Completed);
            }
        }

        // Reponse
        // The data we want to return
        public record Response(int Id, string Name, bool Completed);
    }
}
