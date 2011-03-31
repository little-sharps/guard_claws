using System;
using System.Collections;
using GuardClaws.Exceptions;

namespace GuardClaws
{
    public static class Claws
    {
        public static CallThrough<T> Ensure<T>(Func<T> variable)
        {
            return new CallThrough<T>(variable);
        }

        public static void NotNull<T>(Func<T> variable) where T : class
        {
            if (variable.Invoke() != null) return;
            throw new VariableMustNotBeNullException<T>(variable);
        }

        public static void NotNull<T>(Func<T?> variable) where T : struct
        {
            var instance = variable.Invoke();
            if (!instance.HasValue)
            {
                throw new VariableMustNotBeNullException<T?>(variable);
            }
        }

        public static void NotNullNotBlank(Func<string> variable)
        {
            NotNull(variable);

            if (variable.Invoke() != string.Empty) return;
            throw new VariableMustNotBeBlankException(variable);
        }

        public static void NotNullNotEmpty<T>(Func<T> variable) where T : class, IEnumerable
        {
            NotNull(variable);

            var enumerator = variable.Invoke().GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new VariableMustNotBeEmptyException<T>(variable);
            }
        }

        public static void Numeric(Func<string> variable)
        {
            double junk;
            if (double.TryParse(variable.Invoke(), out junk)) return;
            throw new VariableMustBeNumericException(variable);
        }

        public static void NotDefault<T>(Func<T> variable)
        {
            if (default(T) == null)
            {
                if (!(variable.Invoke() == null)) return;
            }
            else
            {
                if (!variable.Invoke().Equals(default(T))) return;
            }
            throw new VariableMustNotBeDefaultValueException<T>(variable);
        }

        public static void NotEqual<T>(Func<T> variable, T comparedTo)
        {
            if (!variable.Invoke().Equals(comparedTo)) return;
            throw new VariableMustNotBeEqualException<T>(variable, comparedTo);
        }

        public static void AtLeast<T>(Func<T> variable, T comparedTo) where T : IComparable
        {
            var val = variable.Invoke();
            if (val.Equals(comparedTo)) return;
            if (((IComparable)val).CompareTo(comparedTo) > 0) return;

            throw new VariableMustBeAtLeastException<T>(variable, comparedTo);
        }
    }


    public class CallThrough<T>
    {
        private readonly Func<T> variable;

        public CallThrough(Func<T> variable)
        {
            this.variable = variable;
        }

        public void Passes(Predicate<T> predicate)
        {
            if (!predicate(variable.Invoke()))
            {
                throw new VariableMustPassProvidedPredicateException<T>(variable);
            }
        }
    }
}