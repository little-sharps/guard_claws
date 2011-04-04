using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;

namespace NotNull
{
    [TestFixture]
    public class when_called_with_a_not_null
    {
        [Test]
        public void
            it_should_do_nothing()
        {
            string test = string.Empty;
            Claws.NotNull(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_null : expect_a_guard_clause_violation_exception<VariableMustNotBeNullException<string>, string>
    {
        protected override void StatementUnderTest()
        {
            test = null;
            Claws.NotNull(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_null_nullable_type : expect_a_guard_clause_violation_exception<VariableMustNotBeNullException<decimal?>, decimal?>
    {
        protected override void StatementUnderTest()
        {
            test = null;
            Claws.NotNull(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_not_null_nullable_type
    {
        [Test]
        public void It_should_do_nothing()
        {
            decimal? test = 123.5M;
            Claws.NotNull(() => test);
        }
    }
}