using Task;

namespace Tests;

public class Test
{
    [Fact]
    public void TestIncorrectInputs()
    {
        object[][] incorrect_inputs = {new object[] {null}, new object[] {1.1}};
        foreach(object[] obj in incorrect_inputs)
        {
            Assert.Throws<Exception>(() => Program.GeneratePermutations(obj));
        }
    }

    [Fact]
    public void TestDuplicates()
    {
       Assert.Throws<Exception>(() => Program.GeneratePermutations(new string[] {"a","a","ab"}));
    }
    
    [Fact]
    public void TestEmpty()
    {
        Assert.Equal("", Program.GeneratePermutations(new object[] {})[0][0]);
    }

    [Fact]
    public void TestSingleNum()
    {
        Assert.Equal("1", Program.GeneratePermutations(new int[] {1})[0][0]);
    }

    [Fact]
    public void TestDoubleNum()
    {
        Assert.Equivalent([{"1","2"}], Program.GeneratePermutations(new int[] {1,2})[0]));
        Assert.Equivalent([{"2","1"}], Program.GeneratePermutations(new int[] {1,2})[1]));
    }

    [Fact]
    public void TestDoubleBool()
    {
        Assert.Equivalent([{true,false}], Program.GeneratePermutations(new bool[] {true,false})[0]));
        Assert.Equivalent([{false,true}], Program.GeneratePermutations(new bool[] {true,false})[1]));
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
