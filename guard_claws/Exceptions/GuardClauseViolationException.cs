using System;

namespace GuardClaws.Exceptions
{
    public class GuardClauseViolationException<T> : ApplicationException
    {
        protected GuardClauseViolationException(Func<T> delinquent, string message)
            : base(BuildMessage(delinquent, message))
        {
            NameOfDelinquent = Reflect.VariableName(delinquent);
        }

        static string BuildMessage(Func<T> delinquent, string message)
        {
            return string.Format("{0}\n\nDelinquent: {1}", message, Reflect.VariableName(delinquent));
        }

        public string NameOfDelinquent { get; private set; }
    }
}