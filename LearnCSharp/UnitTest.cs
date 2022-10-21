using FluentAssertions;
using FluentAssertions.Execution;

namespace LearnCSharp;

public class Tests
{
    //[Test]
    public void AsyncTest()
    {
        CAsync _cAsync = new CAsync();
        // _cAsync.Sync();
        _cAsync.Async();
        Assert.True(true);
    }

    //[Test]
    public void YieldReturnTest()
    {
        var yieldReturn = new YieldReturn();
        yieldReturn.Demo1();
        yieldReturn.Demo2();
        Assert.True(true);
    }

    [Test]
    public void FluentAssertionTest()
    {
        const string actual = "ABCDEFGHI";
        actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);

        IEnumerable<int> numbers = new[] { 1, 2, 3 };

        numbers.Should().OnlyContain(n => n > 0);
        // numbers.Should().HaveCount(4, "because we thought we put four items in the collection");

        using (new AssertionScope())
        {
            5.Should().Be(10);
            "Actual".Should().Be("Expected");
        }
    }
}