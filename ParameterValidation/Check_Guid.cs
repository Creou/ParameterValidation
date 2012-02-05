using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Linq.Expressions;
using ParameterValidation.Expression;

namespace ParameterValidation
{
    public static partial class Check
    {
        /// <summary>
        /// Checks that a provide Guid is non empty.
        /// </summary>
        /// <param name="guidExpressionToValidate">An expression that returns the Guid to validate</param>
        public static void IsNotEmpty(Expression<Func<Guid>> guidExpressionToValidate)
        {
            // Resolve the value and parameter name to be validated.
            String paramName;
            var value = ExpressionHelper.Resolve(guidExpressionToValidate, out paramName);

            value.IsNotEmpty(paramName);
        }

        /// <summary>
        /// Checks that a provide string is a valid Guid.
        /// </summary>
        /// <param name="guidExpressionToValidate">An expression that returns the string to validate</param>
        /// <returns>The Guid if valid, (throws an exception if not)</returns>
        public static Guid IsValidGuid(Expression<Func<String>> guidExpressionToValidate)
        {
            // Resolve the value and parameter name to be validated.
            String paramName;
            var value = ExpressionHelper.Resolve(guidExpressionToValidate, out paramName);

            return value.IsValidGuid(paramName);
        }

        /// <summary>
        /// Checks that a provide string is a valid GUID.
        /// </summary>
        /// <param name="guidExpressionToValidate">An expression that returns the string to validate</param>
        /// <returns>The Guid if valid, (throws an exception if not)</returns>
        public static Guid IsValidNotEmptyGuid(Expression<Func<String>> guidExpressionToValidate)
        {
            // Resolve the value and parameter name to be validated.
            String paramName;
            var value = ExpressionHelper.Resolve(guidExpressionToValidate, out paramName);

            return value.IsValidNotEmptyGuid(paramName);
        }

        private static void IsNotEmpty(this Guid guidToValidate, String paramName)
        {
            if (guidToValidate == Guid.Empty)
            {
                AssertAndThrow("{0} must not be an empty GUID", paramName);
            }
        }

        private static Guid IsValidNotEmptyGuid(this String guidToValidate, String paramName)
        {
            Guid guidValue = guidToValidate.IsValidGuid(paramName);

            guidValue.IsNotEmpty(paramName);

            return guidValue;
        }

        private static Guid IsValidGuid(this String guidToValidate, String paramName)
        {
            if (guidToValidate == null)
            {
                AssertAndThrowNull("{0} cannot be null", paramName);
            }

            if (String.IsNullOrWhiteSpace(guidToValidate))
            {
                AssertAndThrow("{0} cannot be null or empty", paramName);
            }

            Guid guidValue;
            if (!Guid.TryParse(guidToValidate, out guidValue))
            {
                AssertAndThrow("{0} must be a valid GUID", paramName);
            }
            return guidValue;
        }
    }
}
