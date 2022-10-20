namespace LearnCSharp;

public class AsyncTests
{
    [SetUp]
    public void SetUp()
    {
        _cAsync = new CAsync();
    }

    private CAsync _cAsync;

    [Test]
    public void SyncTest()
    {
        _cAsync.Sync();
        Assert.True(true);
    }

    [Test]
    public void AsyncTest()
    {
        _cAsync.Async();
        Assert.True(true);
    }
}