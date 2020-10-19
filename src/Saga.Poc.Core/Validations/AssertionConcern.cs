using System.Text.RegularExpressions;
using Saga.Poc.Domain.Core.Exceptions;

namespace Saga.Poc.Domain.Core.Validations
{
    public static class AssertionConcern
    {
        public static DomainException GreaterThan(this int objRef, int limit, string message)
        {
            DomainException exception = null;

            if (objRef > limit)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException GreaterThan(this long objRef, long limit, string message)
        {
            DomainException exception = null;

            if (objRef > limit)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException GreaterThan(this decimal objRef, decimal limit, string message)
        {
            DomainException exception = null;

            if (objRef > limit)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException IsEqual(this object objRef, object objComp, string message)
        {
            DomainException exception = null;

            if (objRef != objComp)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException NotEqual(this object objRef, object objComp, string message)
        {
            DomainException exception = null;

            if (objRef == objComp)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException NotEmpty(this string value, string message)
        {
            DomainException exception = null;

            if (string.IsNullOrEmpty(value))
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException NotEmpty(this int value, string message)
        {
            DomainException exception = null;

            if (value == 0)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException NotEmpty(this long value, string message)
        {
            DomainException exception = null;

            if (value == 0)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException NotEmpty(this decimal value, string message)
        {
            DomainException exception = null;

            if (value == 0M)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException NotNull(this object objRef, string message)
        {
            DomainException exception = null;

            if (objRef == null)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException MinimumLength(this string value, int minLength, string message)
        {
            DomainException exception = null;

            var length = value?.Length ?? 0;
            if (length < minLength)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException MaximumLength(this string value, int maxLength, string message)
        {
            DomainException exception = null;

            var length = value?.Length ?? 0;
            if (length > maxLength)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException RangeLength(this string value, int minLength, int maxLength, string message)
        {
            DomainException exception = null;

            var length = value?.Length ?? 0;
            if (length < minLength || length > maxLength)
                exception = new DomainException(message);

            return exception;
        }

        public static DomainException Match(this string value, string pattern, string message)
        {
            DomainException exception = null;

            Regex regexPattern = new Regex(pattern);

            if (regexPattern.IsMatch(value))
                exception = new DomainException(message);

            return exception;
        }
    }
}
