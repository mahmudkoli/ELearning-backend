using ELearning.Common.Mappings;
using Entity = Course.Domain.Entities;
using System.Collections.Generic;

namespace Course.Application.Courses.Queries.GetCourses
{
    public class CourseDto : IMapFrom<Entity.Course>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public CourseDto()
        {

        }
    }
}
