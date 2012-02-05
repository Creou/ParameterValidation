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
        /// Checks that a provided object is not null.
        /// </summary>
        /// <param name="stringExpressionToValidate">A expression that returns the object to validate.</param>
        public static void IsNotNull(Expression<Func<Object>> objectExpressionToValidate)
        {
            String paramName;
            var value = ExpressionHelper.Resolve(objectExpressionToValidate, out paramName);

            value.IsNotNull(paramName);
        }

        private static void IsNotNull(this Object objectToValidate, String paramName)
        {
            if (objectToValidate == null)
            {
                AssertAndThrowNull("{0} cannot be null.", paramName);
            }
        }
    }
}
