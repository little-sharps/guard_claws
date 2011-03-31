using System.Collections.Generic;
using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;


// ReSharper disable InconsistentNaming

namespace NotNullNotEmpty
{
    [TestFixture]
    public class when_called_with_a_not_null_not_empty_value
    {
        [Test]
        public void it_should_do_nothing()
        {
            var test = new[] { "foo", "bar" };
            Claws.NotNullNotEmpty(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_null : expect_a_guard_clause_violation_exception<VariableMustNotBeNullException<IList<string>>, IList<string>>
    {
        protected override void StatementUnderTest()
        {
            test = null;
            Claws.NotNullNotEmpty(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_an_empty_list : expect_a_guard_clause_violation_exception<VariableMustNotBeEmptyException<IList<string>>, IList<string>>
    {
        protected override void StatementUnderTest()
        {
            test = new List<string>();
            test.Clear(); //To be sure
            Claws.NotNullNotEmpty(() => test);
        }
    }
}

// ReSharper restore InconsistentNaming