using FluentAssertions;
using NSubstitute;

namespace LearnCSharp;

[TestFixture]
public class NSub
{
    [SetUp]
    public void SetUp()
    {
        _calculator = Substitute.For<ICalculator>();
    }

    private ICalculator? _calculator;

    public interface ICalculator
    {
        string Mode { get; set; }
        int Add(int a, int b);
    }

    [Test]
    public void ReturnsTest()
    {
        //arrange
        //NSubstitute會產生一個ICalculator 假的實體出來

        //設定假的實體的Add方法當傳入3,6 回傳 9
        _calculator.Add(3, 6).Returns(9);

        //act
        var actual = _calculator.Add(3, 6);

        //assert
        actual.Should().Be(9);
    }

    [Test]
    public void PropertyReturnsTest()
    {
        _calculator.Mode.Returns("A", "B", "C");

        //act
        _calculator.Mode.Should().Be("A");
        _calculator.Mode.Should().Be("B");
        _calculator.Mode.Should().Be("C");
        _calculator.Mode.Should().Be("C");
    }

    [Test]
    public void ReturnsForAnyArgsTest()
    {
        _calculator.Add(default, default).ReturnsForAnyArgs(9);
        _calculator.Add(1, 2).Should().Be(9);
        _calculator.Add(3, 4).Should().Be(9);
    }

    [Test]
    public void ArgAnyTest()
    {
        _calculator.Add(Arg.Any<int>(), 6).Returns(10);
        _calculator.Add(1, 6).Should().Be(10);
        _calculator.Add(3, 6).Should().Be(10);

        _calculator.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(10);
        _calculator.Add(3, 6).Should().Be(10);
        _calculator.Add(10, 5).Should().Be(10);
    }

    [Test]
    public void ArgIsTest()
    {
        _calculator.Add(Arg.Is<int>(x => x > 3), Arg.Is<int>(x => x < 3)).Returns(10);
        _calculator.Add(5, 1).Should().Be(10);
    }
}