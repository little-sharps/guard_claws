using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustBeGreaterThanException<T> : GuardClauseComparisonViolationException<T>
    {
        public VariableMustBeGreaterThanException(Func<T> delinquent, T comparedTo)
            : base(delinquent, comparedTo, "Variable must not be greater than the provided comparison value.")
        {
        }
    }
}