﻿using System;

namespace SiUpin.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(string entityName, object key) : base($"Entity [{entityName}] with key [{key}] was not found.")
        {
        }
    }
}