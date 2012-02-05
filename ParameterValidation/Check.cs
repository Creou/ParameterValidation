using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ParameterValidation
{
    public static partial class Check
    {
        private static void AssertAndThrow(String messageFormat, String paramName)
        {
            var formattedMessage = String.Format(messageFormat, paramName);

            Debug.Fail(formattedMessage, paramName);
            throw new ArgumentException(formattedMessage, paramName);
        }

        private static void AssertAndThrowNull(String messageFormat, String paramName)
        {
            var formattedMessage = String.Format(messageFormat, paramName);

            Debug.Fail(formattedMessage, paramName);
            throw new ArgumentNullException(formattedMessage, paramName);
        }
    }
}
