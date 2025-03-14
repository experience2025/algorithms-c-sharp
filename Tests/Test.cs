using Task;

namespace Tests;

public class Test
{
    [Fact]
    public void test_incorrect_length_values()
    {
        Assert.Throws<InvalidOperationException>(() => Program.Generate_strings(-1,10));
        Assert.Throws<InvalidOperationException>(() => Program.Generate_strings(10,-1));
    }

    [Fact]
    public void TestZeroOne()
    {
      for(int i = 1; i <= 20; i++)
      {
          Assert.Equal(Program.Generate_strings(10, i).Length, i);
      }

    }
    
    [Fact]
    public void TestNLessThanK()
    {
        Assert.Throws<InvalidOperationException>(() => Program.BinomialCoefficient(1,5));
    }

    [Fact]
    public void TestNegativeN()
    {
        Assert.Throws<InvalidOperationException>(() => Program.BinomialCoefficient(-1,5));
    }

    [Fact]
    public void TestNegativeK()
    {
        Assert.Throws<InvalidOperationException>(() => Program.BinomialCoefficient(5,-1));
    }

    [Fact]
    public void TestBinomialCoefficientTiny()
    {
        int [][] pascals_triangle = new int [][] {new int[]{1}, new int[]{1, 1}, new int[]{1, 2, 1}, new int[]{1, 3, 3, 1}, new int[]{1, 4, 6, 4, 1}};
        bool[] variants = new bool[] {true,false};
    }

    [Fact]
    public void TestRectangleLarge()
    {
       float [,] testMatrix = new float[12,6] 
       {
           {8, 9, 2, 1, 6, 9},
           {2, 3, 4, 8, 5, 1},
           {4, 1, 7, 7, 1, 7},
           {5, 6, 2, 8, 5, 6},
           {3, 5, 2, 5, 8, 3},
           {6, 9, 1, 3, 1, 5},
           {7, 5, 4, 4, 2, 9},
           {8, 7, 4, 1, 3, 5},
           {6, 5, 7, 7, 6, 2},
           {6, 2, 4, 8, 6, 3},
           {7, 7, 2, 4, 5, 7},
           {3, 8, 1, 6, 7, 1},
       };
        
       List<int[]> path = new List<int[]>() 
       {
                    {new int[2]{0,0}},
                    {new int[2]{1,0}},
                    {new int[2]{1,1}},
                    {new int[2]{2,1}},
                    {new int[2]{3,1}},
                    {new int[2]{3,2}},
                    {new int[2]{4,2}},
                    {new int[2]{5,2}},
                    {new int[2]{5,3}},
                    {new int[2]{5,4}},
                    {new int[2]{6,4}},
                    {new int[2]{7,4}},
                    {new int[2]{7,5}},
                    {new int[2]{8,5}},
                    {new int[2]{9,5}},
                    {new int[2]{10,5}},
                    {new int[2]{11,5}},
       };
       Task.LengthPathObject result = new Task.LengthPathObject(52, path);
        
       Assert.Equivalent(result, Program.CalculatePath(testMatrix));
    }
}
