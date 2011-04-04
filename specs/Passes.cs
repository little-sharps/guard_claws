using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;
using SharpTestsEx;

namespace Passes
{
    [TestFixture]
    public class when_called_with_a_failing_predicate : expect_a_guard_clause_violation_exception<VariableMustPassProvidedPredicateException<string>, string>
    {
        protected override void StatementUnderTest()
        {
            var test = "hello";

            Claws.Ensure(() => test).Passes(x => x == "goodbye");
        }
    }

    [TestFixture]
    public class when_called_with_a_passing_predicate
    {
        [Test]
        public void ItShouldDoNothing()
        {
            var test = "anything";

            Claws.Ensure(() => test).Passes(x => true);
        }
    }

    [TestFixture]
    public class when_called
    {
        [Test]
        public void ItShouldPassTheVariableValueIntoThePredicate()
        {
            var test = "some value";

            Claws.Ensure(() => test).Passes(x =>
            {
                x.Should().Be.EqualTo(test);
                return true;
            });
        }
    }
}