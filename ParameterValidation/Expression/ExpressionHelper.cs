using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace ParameterValidation.Expression
{
    internal static class ExpressionHelper
    {
        /// <summary>
        /// Resolves a basic member expression into it's value and member name.
        /// Does not support anything other than simple member expressions containing a single field.
        /// </summary>
        /// <typeparam name="T">The return type of the expression.</typeparam>
        /// <param name="expr">The expression to resolve.</param>
        /// <param name="memberName">The resolved member name.</param>
        /// <returns></returns>
        public static T Resolve<T>(Expression<Func<T>> expr, out String memberName)
        {
            // Get the body of the expression.
            var expressionBody = (expr.Body as MemberExpression);
            if (expressionBody == null)
            {
                throw new NotSupportedException(String.Format("Unable to resolve expression. Expression body could not be resolved to a MemberExpression. The expression body is of type {0}", expr.Body.GetType()));
            }

            memberName = expressionBody.Member.Name;

            // Get the field information of the expression.
            var fieldInfo = (FieldInfo)expressionBody.Member;
            var constantExpression = (ConstantExpression)expressionBody.Expression;

            if (fieldInfo == null)
            {
                throw new NotSupportedException(String.Format("Unable to resolve expression. MemberInfo could not be resolved to a field. MemberInfo is of type {0}", expressionBody.Member.GetType()));
            }
            if (constantExpression == null)
            {
                throw new NotSupportedException(String.Format("Unable to resolve expression. body expression could not be resolved to a constant expression. Expression is of type {0}", expressionBody.Expression.GetType()));
            }

            // Get the value for the field from the expression.
            T resolvedValue = (T)fieldInfo.GetValue(constantExpression.Value);
            return resolvedValue;
        }

        // An alternative method for resolving param names from functions instead of expressions.
        // http://abdullin.com/journal/2008/12/19/how-to-get-parameter-name-and-argument-value-from-c-lambda-v.html
        //private static String ResolveParamName<K>(Func<K> argument)
        //{
        //    // get IL code behind the delegate
        //    var il = argument.Method.GetMethodBody().GetILAsByteArray();
        //    // bytes 2-6 represent the field handle
        //    var fieldHandle = BitConverter.ToInt32(il, 2);
        //    // resolve the handle
        //    var field = argument.Target.GetType().Module.ResolveField(fieldHandle);
        //    return field.Name;
        //}
    }
}