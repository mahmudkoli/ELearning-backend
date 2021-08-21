using ELearning.Common.Exceptions;
using Course.Application.Common.Interfaces;
using Entity = Course.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCourseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entity.Course), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
