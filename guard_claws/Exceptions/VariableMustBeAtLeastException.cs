using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustBeAtLeastException<T> : GuardClauseComparisonViolationException<T>
    {
        public VariableMustBeAtLeastException(Func<T> delinquent, T comparedTo)
            : base(delinquent, comparedTo, "Variable must be at least the provided comparison value.")
        {
        }
    }
}