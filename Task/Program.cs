namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Числа Фибоначчи:");
            for (var number = 1; number < 10; number++)
            {
                Console.WriteLine($"{number}: {FibonacciRec(number)}");
            }
    }

    public static int FibonacciRec(int n)
    {
        if (n < 1)
        {
            throw new ArgumentException("Номер числа Фибоначчи должен быть положительным числом", nameof(n));
        }
        if (n <= 2)
        {
            return 1;
        }

        return FibonacciRec(n - 1) + FibonacciRec(n - 2);
    }
}
