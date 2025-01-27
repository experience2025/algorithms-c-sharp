using Task;

namespace Tests;

public class FibonacciTest
{
    [Fact]
    public void TestZero()
    {
        Assert.Throws<ArgumentException>(() => Program.FibonacciRec(0));
    }

    [Fact]
    public void TestNegative()
    {
        Assert.Throws<ArgumentException>(() => Program.FibonacciRec(-1));
    }
    
    [Fact]
    public void TestNumbers()
    {
        int[] numbers =
        {
            1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711
        };
        for (var number = 1; number < numbers.Length + 1; number++)
        {
            Assert.Equal(numbers[number - 1], Program.FibonacciRec(number));
        }
    }
}