using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustPassProvidedPredicateException<T> : GuardClauseViolationException<T>
    {
        public VariableMustPassProvidedPredicateException(Func<T> delinquent) : base(delinquent, "Variable must pass the provided predicate function. (The function must return TRUE for this guard clause to pass.)") { }
    }
}