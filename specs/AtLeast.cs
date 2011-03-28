using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;

namespace AtLeast
{
    [TestFixture]
    public class when_called_with_a_value_greater_than_the_comparedTo
    {
        [Test]
        public void
            it_should_do_nothing()
        {
            var test = 30;
            Claws.AtLeast(() => test, 20);
        }
    }

    [TestFixture]
    public class when_called_with_a_value_equal_to_the_comparedTo
    {
        [Test]
        public void
            it_should_do_nothing()
        {
            var test = 30;
            Claws.AtLeast(() => test, 30);
        }
    }

    [TestFixture]
    public class when_called_with_a_value_less_than_the_comparedTo : expect_a_ComparisonViolation_exception<VariableMustBeAtLeastException<int>, int>
    {
        protected override void StatementUnderTest()
        {
            test = 10;
            compareTo = 15;

            Claws.AtLeast(() => test, compareTo);
        }
    }
}
