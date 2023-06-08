﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocioFormador.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("There have been one or more validation errors")
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
