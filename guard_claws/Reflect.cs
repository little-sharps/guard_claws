#region (c)2009 Lokad, (c) Brendan Erwin - New BSD license

// Portions Copyright (c) Lokad 2009 
// Company: http://www.lokad.com

// Other Portions Copyright (c) Brendan Erwin 2009

// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace GuardClaws
{
    /// <summary>
    /// Helper class for the IL-based strongly-typed reflection
    /// </summary>
    /// <remarks>This class is not supported by Silverlight 2.0</remarks>
    internal static class Reflect
    {
        static readonly byte Ldarg_0 = (byte)OpCodes.Ldarg_0.Value;
        static readonly byte Ldfld = (byte)OpCodes.Ldfld.Value;

        public static string VariableName<T>(Func<T> expression)
        {
            return Variable(expression).Name;
        }

        /// <summary>
        /// Retrieves via IL the information of the <b>local</b> variable passed in the expression.
        /// <code>
        /// var myVar = "string";
        /// var info = Reflect.Variable(() =&gt; myVar)
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression containing the local variable to reflect.</param>
        /// <returns>information about the variable</returns>
        static FieldInfo Variable<T>(Func<T> expression)
        {
            var method = expression.Method;
            var il = method.GetMethodBody().GetILAsByteArray();

            if ((il[0] == Ldarg_0) && (il[1] == Ldfld))
            {
                var fieldHandle = BitConverter.ToInt32(il, 2);

                var module = method.Module;
                var expressionType = expression.Target.GetType();

                if (!expressionType.IsGenericType)
                {
                    return module.ResolveField(fieldHandle);
                }
                var genericTypeArguments = expressionType.GetGenericArguments();

                return module.ResolveField(fieldHandle, genericTypeArguments, Type.EmptyTypes);
            }
            throw new ArgumentException("Expected simple field reference");
        }
    }
}