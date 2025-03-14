using Task;

namespace Tests;

public class Test
{
    [Fact]
    public void TestIncorrectLengthValues()
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

        for(int i = 0; i < pascals_triangle.Length; i++)
        {
            for(int j = 0; j < pascals_triangle[i].Length; j++)
            {
                foreach(bool variant in variants)
                {
                    int res = Program.BinomialCoefficient(i,j,variant);
                    Assert.Equal(res, pascals_triangle[i][j]);
                }
            }
        }
    }

    [Fact]
    public void TestBinomialCoefficientMiddle()
    {
       bool[] variants = new bool[] {true,false};

       foreach(bool variant in variants)
       {
         Assert.Equal(252, Program.BinomialCoefficient(10,5,variant));
       }
        
    }

     [Fact]
    public void TestBinomialCoefficientLarge()
    {
       bool[] variants = new bool[] {true,false};

       foreach(bool variant in variants)
       {
         Assert.Equal(30045015, Program.BinomialCoefficient(30,20,variant));
       }
        
    }
}
