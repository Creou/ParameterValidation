using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using ParameterValidation.Expression;

namespace ParameterValidation
{
    /// <summary>
    /// Class to provide help with method precondition checks.
    /// </summary>
    public static partial class Check
    {
        /// <summary>
        /// Checks that a provided string is not null or white space.
        /// </summary>
        /// <param name="stringExpressionToValidate">A expression that returns the string to validate.</param>
        public static void IsNotNullOrWhiteSpace(Expression<Func<String>> stringExpressionToValidate)
        {
            String paramName;
            var value = ExpressionHelper.Resolve(stringExpressionToValidate, out paramName);

            value.IsNotNullOrWhiteSpace(paramName);
        }

        /// <summary>
        /// Checks that a provided string is not null or white space.
        /// </summary>
        /// <param name="stringExpressionToValidate">A expression that returns the string to validate.</param>
        public static void IsNotNullOrEmpty(Expression<Func<String>> stringExpressionToValidate)
        {
            String paramName;
            var value = ExpressionHelper.Resolve(stringExpressionToValidate, out paramName);

            value.IsNotNullOrEmpty(paramName);
        }

        private static void IsNotNullOrWhiteSpace(this String stringToValidate, String paramName)
        {
            stringToValidate.IsNotNull(paramName);

            if (String.IsNullOrWhiteSpace(stringToValidate))
            {
                AssertAndThrow("{0} cannot be null or contain only whitespace.", paramName);
            }
        }

        private static void IsNotNullOrEmpty(this String stringToValidate, String paramName)
        {
            stringToValidate.IsNotNull(paramName);

            if (String.IsNullOrEmpty(stringToValidate))
            {
                AssertAndThrow("{0} cannot be null or empty.", paramName);
            }
        }
    }
}
