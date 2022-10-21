namespace LearnCSharp;

public class YieldReturn
{
    public void Demo1()
    {
        Console.Write($"normal return list : ");
        DisplayList(NormalReturnList(3));

        Console.Write($"yield return list : ");
        DisplayList(YieldReturnList(3));
    }

    private static void DisplayList(IEnumerable<int> inputList)
    {
        foreach (var num in inputList)
        {
            Console.Write($"{num} ");
        }

        Console.WriteLine("");
    }

    private IEnumerable<int> YieldReturnList(int max)
    {
        for (int i = 1; i <= max; i++)
        {
            Console.Write("y");
            yield return i;
        }
    }

    private IEnumerable<int> NormalReturnList(int max)
    {
        var list = new List<int>();
        for (int i = 1; i <= max; i++)
        {
            Console.Write("n");
            list.Add(i);
        }

        return list;
    }

    public void Demo2()
    {
        Console.Write($"yield break : ");
        DisplayList(YieldBreakList());
    }

    private IEnumerable<int> YieldBreakList()
    {
        yield return 5;
        yield return 4;
        yield return 3;

        yield break;

        yield return 2;
        yield return 1;
    }
}