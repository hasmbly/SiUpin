using System;

namespace SiUpin.Application.Common.Interfaces
{
    public interface IDateTimeOffsetService
    {
        DateTimeOffset Now { get; }
    }
}