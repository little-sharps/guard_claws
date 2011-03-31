using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;

namespace Numeric
{
    [TestFixture]
    public class when_called_with_a_numeric_string
    {
        [Test]
        public void
            it_should_do_nothing()
        {
            var test = "1";
            Claws.Numeric(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_string_containing_a_decimal
    {
        [Test]
        public void
            it_should_do_nothing()
        {
            var test = "1.2";
            Claws.Numeric(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_blank_string : expect_a_guard_clause_violation_exception<VariableMustBeNumericException, string>
    {
        protected override void StatementUnderTest()
        {
            test = string.Empty;
            Claws.Numeric(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_nonnumeric_string : expect_a_guard_clause_violation_exception<VariableMustBeNumericException, string>
    {
        protected override void StatementUnderTest()
        {
            test = "non-numeric";
            Claws.Numeric(() => test);
        }
    }
}
