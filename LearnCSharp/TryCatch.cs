using NUnit.Framework;

namespace LearnCSharp;

[TestFixture]
public class TryCatch
{
    [Test]
    public void TryCatch_IndexOutOfRangeException()
    {
        var luckyman = new string[] { "man1", "man2" };
        try
        {
            Console.WriteLine(luckyman[3]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Catch " + ex.ToString()); //把ex印出來
        }
    }
}