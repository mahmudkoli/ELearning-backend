using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ELearning.Common.Mappings;
using ELearning.Common.Models;

namespace Course.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CommonMappingProfile.ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly(), this);
            CreateMap(typeof(QueryResult<>), typeof(QueryResult<>));
        }
    }
}
