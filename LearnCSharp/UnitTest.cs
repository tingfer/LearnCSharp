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

    [Test]
    public void YieldReturnTest()
    {
        var yieldReturn = new YieldReturn();
        yieldReturn.Demo();
        Assert.True(true);
    }
}