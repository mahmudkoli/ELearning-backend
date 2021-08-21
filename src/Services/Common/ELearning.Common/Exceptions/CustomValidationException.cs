using System;
using System.Collections.Generic;
using System.Linq;
using ELearning.Common.Models;
using FluentValidation.Results;

namespace ELearning.Common.Exceptions
{
    public class CustomValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public CustomValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public CustomValidationException(string message)
            : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public CustomValidationException(List<ValidationFailure> failures)
            : this(failures?.GroupBy(e => e.PropertyName, e => e.ErrorMessage)?.FirstOrDefault()?.ToList().FirstOrDefault() ?? "One or more validation failures have occurred.")
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public CustomValidationException(List<(string PropertyName, string[] PropertyFailures)> failures)
            : this(failures?.FirstOrDefault().PropertyFailures?.FirstOrDefault() ?? "One or more validation failures have occurred.")
        {
            foreach (var failure in failures)
            {
                var propertyName = failure.PropertyName;
                var propertyFailures = failure.PropertyFailures;

                Errors.Add(propertyName, propertyFailures);
            }
        }

        public CustomValidationException(List<ValidationError> failures)
            : this(failures?.FirstOrDefault()?.PropertyFailures?.FirstOrDefault() ?? "One or more validation failures have occurred.")
        {
            foreach (var failure in failures)
            {
                var propertyName = failure.PropertyName;
                var propertyFailures = failure.PropertyFailures.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }
    }
}