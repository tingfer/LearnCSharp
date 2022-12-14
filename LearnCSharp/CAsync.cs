namespace LearnCSharp;

public class CAsync
{
    public void Sync()
    {
        Print("Sync");
        Print("A");
        Print("B");
    }

    private static void Print(string msg)
    {
        var threadId = Environment.CurrentManagedThreadId;
        Console.WriteLine($"{threadId} {msg}");
    }

    public void Async()
    {
        Print("1");
        var task1 = PrintTaskAsync("A", 20);
        Print("2");
        var task2 = PrintTaskAsync("B", 10);
        Print("3");
        var task3 = PrintTaskAsync("C", 0);
        Print("4");

        var task1Result = task1.Result;
        Print("5");
        var task2Result = task2.Result;
        Print("6");
        var task3Result = task3.Result;
        Print("7");
    }

    private async Task<Task> PrintTaskAsync(string msg, int delay)
    {
        Print("enter " + msg);
        var task = Task.Run(() => { Thread.Sleep(delay); });
        await task;

        Print("exit " + msg);
        return task;
    }
}