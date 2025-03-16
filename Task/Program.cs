namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
   	Console.WriteLine(Rabbits(8,7));    
    }

public static int Rabbits(int targetMonth, int rabbitLifetime)
{
    int result = 0;
    int index = 3;

    Queue<int> Fibonacci = new Queue<int>();
    Fibonacci.Enqueue(1);
    Fibonacci.Enqueue(1);

    if(targetMonth == 1 || targetMonth == 2)
    {
        return 1;
    }

    if (rabbitLifetime == 1)
    {
        if (targetMonth == 1) return 1;
        else return 0;
    }

    if (rabbitLifetime == 2)
    {
        return 1;
    }

    while (index < targetMonth && index < rabbitLifetime)
    {       
        result = Fibonacci.ElementAt(Fibonacci.Count - 1) + Fibonacci.ElementAt(Fibonacci.Count - 2);
        Fibonacci.Enqueue(result);
        index++;
    }

    if (index == targetMonth)
    {
        result = Fibonacci.ElementAt(Fibonacci.Count - 1) + Fibonacci.ElementAt(Fibonacci.Count - 2);
        return result;
    }

    result = Fibonacci.ElementAt(Fibonacci.Count - 1) - 1 + Fibonacci.ElementAt(Fibonacci.Count - 2);
    Fibonacci.Enqueue(result);
    index++;

    if (index == targetMonth)
    {
        result = Fibonacci.ElementAt(Fibonacci.Count - 1) + Fibonacci.ElementAt(Fibonacci.Count - 2);
        return result;
    }

    result = Fibonacci.ElementAt(Fibonacci.Count - 1) + Fibonacci.ElementAt(Fibonacci.Count - 2);
    Fibonacci.Enqueue(result);
    index++;

    if (index == targetMonth)
    {
        result = Fibonacci.ElementAt(Fibonacci.Count - 1) + Fibonacci.ElementAt(Fibonacci.Count - 2);
        return result;
    }

    for (int i = index + 1; i <= targetMonth; i++)
    {
        result = Fibonacci.ElementAt(Fibonacci.Count - 1) - Fibonacci.Dequeue() + Fibonacci.ElementAt(Fibonacci.Count - 2);
        Fibonacci.Enqueue(result);
    }

    result = Fibonacci.ElementAt(Fibonacci.Count - 1) + Fibonacci.ElementAt(Fibonacci.Count - 2);
    return result;
}
}
