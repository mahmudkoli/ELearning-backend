using AutoMapper;
using AutoMapper.QueryableExtensions;
using Course.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Application.Courses.Queries.GetCourses
{
    public class GetCoursesQuery : IRequest<CoursesVm>
    {

    }

    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, CoursesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CoursesVm> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            return new CoursesVm
            {
                Items = await _context.Courses
                    .AsNoTracking()
                    .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                    .OrderBy(c => c.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
