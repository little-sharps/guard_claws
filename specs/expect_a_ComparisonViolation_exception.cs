using GuardClaws.Exceptions;
using NUnit.Framework;
using SharpTestsEx;


public abstract class expect_a_ComparisonViolation_exception<TExpectedExceptionType, TVariableType> :
    expect_an_exception<TExpectedExceptionType, TVariableType>
    where TExpectedExceptionType : GuardClauseComparisonViolationException<TVariableType>
{
    protected TVariableType compareTo;

    [Test]
    public void
        it_should_put_the_compareTo_value_in_the_ComparedTo_on_the_exception()
    {
        the_exception.ComparedTo.Should().Be.EqualTo(compareTo);
    }
}