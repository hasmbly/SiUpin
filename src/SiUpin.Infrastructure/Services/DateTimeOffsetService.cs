using System;
using SiUpin.Application.Common.Interfaces;

namespace SiUpin.Infrastructure.Services
{
    public class DateTimeOffsetService : IDateTimeOffsetService
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}