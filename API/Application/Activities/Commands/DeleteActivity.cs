using API.Persistence;
using AutoMapper;
using MediatR;

namespace API.Application.Activities.Commands;

public class DeleteActivity
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Id], cancellationToken) ?? throw new Exception("Activity not found");

            context.Remove(activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
