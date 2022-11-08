using System.Net.NetworkInformation;
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
            Console.WriteLine(ex.StackTrace);
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
            // throw ex; // ## Rethrow exception ## // destroys the strack trace info!
            throw; // ## Rethrow exception ## // preserves the stack trace
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

    private void SpecificException(int type)
    {
        switch (type)
        {
            case 1: throw new NewException();
            case 2: throw new NewException("2");
            case 3: throw new NewException("3", new DllNotFoundException());
        }
    }

    [Test]
    public void TryCatch_ThrowSpecificException()
    {
        try
        {
            SpecificException(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }

        try
        {
            SpecificException(2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }

        try
        {
            SpecificException(3);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}

internal class NewException : Exception
{
    public NewException() : base()
    {
        Console.WriteLine("default NewException");
    }

    public NewException(string message) : base(message)
    {
        Console.WriteLine("NewException with message");
    }

    public NewException(string message, Exception inner) : base(message, inner)
    {
        Console.WriteLine("NewException with message, inner Exception");
    }
}