using System.Diagnostics;
using NUnit.Framework;

namespace LearnCSharp;

[TestFixture]
public class BoxingTest
{
    private string _source;
    private readonly Stopwatch _stopWatch = new Stopwatch();
    private const int Loop = 100000000;

    [Test]
    public void StringBoxingCostTest()
    {
        _stopWatch.Start();
        for (int i = 0; i < Loop; i++)
        {
            _source = $"Number{i},{i},{i}";
        }

        _stopWatch.Stop();
        Console.Write($"Boxing Test 耗時 {_stopWatch.Elapsed.Milliseconds}毫秒");
    }

    [Test]
    public void NoStringBoxingCostTest()
    {
        _stopWatch.Start();
        for (int i = 0; i < Loop; i++)
        {
            _source = $"Number{i.ToString()},{i.ToString()},{i.ToString()}";
        }

        _stopWatch.Stop();
        Console.Write($"NoBoxing Test 耗時 {_stopWatch.Elapsed.Milliseconds}毫秒");
    }

    [Test]
    public void IntBoxingCostTest()
    {
        _stopWatch.Start();
        for (int i = 0; i < Loop; i++)
        {
            object intObj = i;
            int j = (int)intObj;
            _source = $"{j.ToString()}";
        }

        _stopWatch.Stop();
        Console.Write($"IntBoxing Test 耗時 {_stopWatch.Elapsed.Milliseconds}毫秒");
    }

    [Test]
    public void IntNoBoxingCostTest()
    {
        _stopWatch.Start();
        for (int i = 0; i < Loop; i++)
        {
            int j = i;
            _source = $"{j.ToString()}";
        }

        _stopWatch.Stop();
        Console.Write($"IntNoBoxing Test 耗時 {_stopWatch.Elapsed.Milliseconds}毫秒");
    }
}