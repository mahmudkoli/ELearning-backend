using Course.Application.Common.Interfaces;
using ELearning.Common.Services;
using System;

namespace Course.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
