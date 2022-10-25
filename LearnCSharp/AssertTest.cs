using FluentAssertions;
using FluentAssertions.Extensions;

namespace LearnCSharp;

[TestFixture]
public class AssertTest
{
    [Test]
    [Category("Value")]
    public void IntegerAssert()
    {
        var theInt = 5;
        theInt.Should().Be(5);
        theInt.Should().NotBe(10);

        theInt.Should().BePositive();

        theInt.Should().BeGreaterThanOrEqualTo(5);
        theInt.Should().BeGreaterThan(4);

        theInt.Should().BeLessThanOrEqualTo(5);
        theInt.Should().BeLessThan(6);

        theInt.Should().BeInRange(1, 10);
        theInt.Should().NotBeInRange(6, 10);

        theInt.Should().Match(x => x % 2 == 1);

        // theInt = 0;
        //theInt.Should().BePositive(); => Expected positive value, but found 0
        //theInt.Should().BeNegative(); => Expected negative value, but found 0

        theInt = -8;
        theInt.Should().BeNegative();
        int? nullableInt = 3;
        nullableInt.Should().Be(3);

        byte theByte = 2;
        theByte.Should().Be(2);
    }

    [Test]
    [Category("Value")]
    public void DoubleAssert()
    {
        var theDouble = 5.1;
        theDouble.Should().BeGreaterThan(5);
        var value = 3.1415927F;
        value.Should().BeApproximately(3.14F, 0.01F);
        value = 3.5F;
        value.Should().NotBeApproximately(2.5F, 0.5F);
    }

    [Test]
    [Category("String")]
    public void StringContain()
    {
        StringAnd();

        var theString = "This is a String";
        theString.Should().Contain("is a");
        theString.Should().Contain("is a", Exactly.Once());
        theString.Should().Contain("is ", AtLeast.Twice());
        // theString.Should().Contain("i", MoreThan.Thrice());
        theString.Should().Contain("is a", AtMost.Times(5));
        theString.Should().Contain("is a", LessThan.Twice());
        // theString.Should().ContainAll("should", "contain", "all", "of", "these");
        // theString.Should().ContainAny("any", "of", "these", "will", "do");
        // theString.Should().NotContain("is a");
        theString.Should().NotContainAll("can", "contain", "some", "but", "not", "all");
        theString.Should().NotContainAny("can't", "contain", "any", "of", "these");
        // theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING");
        // theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", Exactly.Once());
        // theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", AtLeast.Twice());
        // theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", MoreThan.Thrice());
        // theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", AtMost.Times(5));
        // theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", LessThan.Twice());
        theString.Should().NotContainEquivalentOf("HeRe ThE CaSiNg Is IgNoReD As WeLl");
    }

    [Test]
    [Category("String")]
    public void StringAnd()
    {
        const string actual = "ABCDEFGHI";
        actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
    }

    [Test]
    [Category("String")]
    public void StringStartEndWith()
    {
        var theString = "This is a String";
        theString.Should().StartWith("This");
        theString.Should().NotStartWith("That");
        theString.Should().StartWithEquivalentOf("this");
        theString.Should().NotStartWithEquivalentOf("that");

        theString.Should().EndWith("a String");
        theString.Should().NotEndWith("a Strong");
        theString.Should().EndWithEquivalentOf("a string");
        theString.Should().NotEndWithEquivalentOf("a strong");
    }

    [Test]
    [Category("String")]
    public void StringBeEquivalent()
    {
        var theString = "This is a String";
        theString.Should().Be("This is a String");
        theString.Should().NotBe("This is another String");
        theString.Should().BeEquivalentTo("THIS IS A STRING");
        theString.Should().NotBeEquivalentTo("THIS IS ANOTHER STRING");

        theString.Should().BeOneOf("That is a String", "This is a String");
    }

    [Test]
    [Category("String")]
    public void StringCase()
    {
        var theString = "ABC";
        theString.Should().BeUpperCased();
        theString.Should().NotBeLowerCased();

        theString = "abc";
        theString.Should().BeLowerCased();
        theString.Should().NotBeUpperCased();
    }

    [Test]
    [Category("String")]
    public void StringNullEmpty()
    {
        var theString = "";
        theString.Should().NotBeNull();
        theString.Should().BeEmpty();
        theString.Should().HaveLength(0);
        theString.Should().BeNullOrWhiteSpace(); // either null, empty or whitespace only

        theString = null;
        theString.Should().BeNull();
        theString.Should().NotBeEmpty("because the string is not empty");
        // theString.Should().NotBeNullOrWhiteSpace();
    }

    [Test]
    [Category("Value")]
    public void BooleanAssert()
    {
        var theBoolean = false;
        theBoolean.Should().BeFalse("it's set to false");

        theBoolean = true;
        var otherBoolean = true;
        theBoolean.Should().BeTrue();
        theBoolean.Should().Be(otherBoolean);
        theBoolean.Should().NotBe(false);
    }

    [Test]
    [Category("Time")]
    public void ExecutionTimeTest()
    {
        var someAction = () => Thread.Sleep(100);

        someAction.ExecutionTime().Should().BeLessThanOrEqualTo(200.Milliseconds());
        someAction.ExecutionTime().Should().BeLessThan(200.Milliseconds());

        someAction.ExecutionTime().Should().BeGreaterThan(100.Milliseconds());
        someAction.ExecutionTime().Should().BeGreaterThanOrEqualTo(100.Milliseconds());

        someAction.ExecutionTime().Should().BeCloseTo(150.Milliseconds(), 50.Milliseconds());
    }
}