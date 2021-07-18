﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Contracts.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public ValidationException(string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            ValidationErrors = string.Join(",", innerException);
        }
        public int StatusCode { get; }
        public string ValidationErrors { get; set; }
    }
}