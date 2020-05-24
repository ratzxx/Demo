using Department.Application.Common.Interfaces;
using System;

namespace Department.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
