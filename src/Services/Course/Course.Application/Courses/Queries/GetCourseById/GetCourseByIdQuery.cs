using AutoMapper;
using AutoMapper.QueryableExtensions;
using Course.Application.Common.Interfaces;
using Entity = Course.Domain.Entities;
using ELearning.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Application.Courses.Queries.GetCourseById
{
    public class GetCourseById : IRequest<CourseDetailsVm>
    {
        public Guid Id { get; set; }
    }

    public class GetCoursesQueryHandler : IRequestHandler<GetCourseById, CourseDetailsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CourseDetailsVm> Handle(GetCourseById request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses
                .Where(c => c.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entity.Course), request.Id);
            }

            return new CourseDetailsVm
            {
                Item = _mapper.Map<CourseDetailsDto>(entity)
            };
        }
    }
}
