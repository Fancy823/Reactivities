using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            public DataContext Context { get; }

            public Handler(DataContext context)
            {
                Context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                this.Context.Activities.Add(request.Activity);

                await this.Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}