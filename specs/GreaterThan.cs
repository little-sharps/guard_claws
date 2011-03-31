using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;

namespace GreaterThan
{
    [TestFixture]
    public class when_called_with_a_value_less_than_the_comparedTo : expect_a_ComparisonViolation_exception<VariableMustBeGreaterThanException<int>, int>
    {
        protected override void StatementUnderTest()
        {
            test = 10;
            compareTo = 11;

            Claws.GreaterThan(() => test, compareTo);
        }
    }

    [TestFixture]
    public class when_called_with_a_value_equal_to_the_comparedTo : expect_a_ComparisonViolation_exception<VariableMustBeGreaterThanException<int>, int>
    {
        protected override void StatementUnderTest()
        {
            test = 23;
            compareTo = test;

            Claws.GreaterThan(() => test, compareTo);
        }
    }

    [TestFixture]
    public class when_called_with_a_value_greater_than_the_comparedTo
    {
        [Test]
        public void ItShouldDoNothing()
        {
            var test = 23;
            Claws.GreaterThan(() => test, 20);
        }
    }

}