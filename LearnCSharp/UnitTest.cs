using System.Diagnostics;

namespace LearnCSharp;

public class Tests
{
    [Test]
    public void AsyncTest()
    {
        var _cAsync = new CAsync();
        // _cAsync.Sync();
        _cAsync.Async();
        Assert.True(true);
    }

    [Test]
    public void YieldReturnTest()
    {
        var yieldReturn = new YieldReturn();
        yieldReturn.Demo1();
        yieldReturn.Demo2();
        Assert.True(true);
    }

    [Test]
    public void ReflectionTest()
    {
    }
}