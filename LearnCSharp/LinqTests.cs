using NUnit.Framework;

namespace LearnCSharp;

//[TestFixture]
public class LinqTests
{
    [SetUp]
    public void SetUp()
    {
        _cLinq = new CLinq();
    }

    private CLinq? _cLinq;

    //[Test]
    public void WhatIsLinq()
    {
        _cLinq.WhatIsLinq();
        Assert.AreEqual(1, 1);
    }
}