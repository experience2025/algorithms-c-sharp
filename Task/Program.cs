namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Числа Фибоначчи:");
            for (var number = 1; number < 10; number++)
            {
                Console.WriteLine($"{number}: {FibonacciRec(number)}");
                Console.WriteLine($"{number}: {FibonacciIter(number)}");
                Console.WriteLine($"{number}: {Fibonacci(number)}");
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

     public static int FibonacciIter(int n)
    {
     if (n < 1)
     {
         throw new ArgumentException("Номер числа Фибоначчи должен быть положительным числом", nameof(n));
     }

     if (n <= 2)
     {
         return 1;
     }

     int[] fibonacci_numbers = new int[n + 1];
     fibonacci_numbers[0] = 0;
     fibonacci_numbers[1] = 1;

     for (int i = 2; i <= n; i++)
     {
         fibonacci_numbers[i] = fibonacci_numbers[i - 2] + fibonacci_numbers[i - 1];
     }

     return fibonacci_numbers[n];
    }

     public static int Fibonacci(int n)
    {
     if (n < 1)
     {
         throw new ArgumentException("Номер числа Фибоначчи должен быть положительным числом", nameof(n));
     }

     if (n <= 2)
     {
         return 1;
     }

     int first_number = 0;
     int second_number = 1;
     int sum = 0;

     for (int i = 2; i <= n; i++)
     {
         sum = first_number + second_number;

         first_number = second_number;
         second_number = sum;
     }

     return sum;
    }
}
