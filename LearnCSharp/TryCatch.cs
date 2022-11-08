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

    [Test]
    public void TryCatch_ThrowException()
    {
        try
        {
            DoSomethingInAoo();
        }
        catch (Exception ex)
        {
            // display stack trace info
            Console.WriteLine("----- stack info -----");
            Console.WriteLine(ex.StackTrace.ToString());
            Console.WriteLine("----------------------");
        }
    }

    // level 1
    private void DoSomethingInAoo()
    {
        DoSomethingInBoo();
    }

    // level 2
    private void DoSomethingInBoo()
    {
        try
        {
            DoSomethingInCoo();
        }
        catch (Exception ex)
        {
            // log here
            // ...

            // ## Rethrow exception ##
            // destroys the strack trace info!
            // throw ex;

            // ## Rethrow exception ##
            // preserves the stack trace
            throw;
        }
    }

    // level 3 
    private void DoSomethingInCoo()
    {
        DoSomethingInDoo();
    }

    // level 4 
    private void DoSomethingInDoo()
    {
        int i = 0;
        i = 1 / i; // cause exception 
    }
}