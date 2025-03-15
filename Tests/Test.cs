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
            Assert.Throws<ArgumentException>(() => Program.GeneratePermutations(obj));
        }
    }

    [Fact]
    public void TestDuplicates()
    {
       Assert.Throws<ArgumentException>(() => Program.GeneratePermutations(new string[] {"a","a","ab"}));
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
        Assert.Equivalent(new string[] {"1","2"}, Program.GeneratePermutations(new int[] {1,2})[0]);
        Assert.Equivalent(new string[] {"2","1"}, Program.GeneratePermutations(new int[] {1,2})[1]);
    }

    [Fact]
    public void TestDoubleBool()
    {
        Assert.Equivalent(new bool[] {true,false}, Program.GeneratePermutations(new bool[] {true,false})[0]);
        Assert.Equivalent(new bool[] {false,true}, Program.GeneratePermutations(new bool[] {true,false})[1]);
    }

    [Fact]
    public void TestTripleNum()
    {
        Assert.Equivalent(new int[] {1,2,3}, Program.GeneratePermutations(new int[] {3,2,1})[0]);
        Assert.Equivalent(new int[] {1,3,2}, Program.GeneratePermutations(new int[] {3,2,1})[1]);
        Assert.Equivalent(new int[] {2,1,3}, Program.GeneratePermutations(new int[] {3,2,1})[2]);
        Assert.Equivalent(new int[] {2,3,1}, Program.GeneratePermutations(new int[] {3,2,1})[3]);
        Assert.Equivalent(new int[] {3,1,2}, Program.GeneratePermutations(new int[] {3,2,1})[4]);
        Assert.Equivalent(new int[] {3,2,1}, Program.GeneratePermutations(new int[] {3,2,1})[5]);
    }

    [Fact]
    public void TestTripleChar()
    {
        Assert.Equivalent(new string[] {"a","b","c"}, Program.GeneratePermutations(new string[] {"a","b","c"})[0]);
        Assert.Equivalent(new string[] {"a","c","b"}, Program.GeneratePermutations(new string[] {"a","b","c"})[1]);
        Assert.Equivalent(new string[] {"b","a","c"}, Program.GeneratePermutations(new string[] {"a","b","c"})[2]);
        Assert.Equivalent(new string[] {"b","c","a"}, Program.GeneratePermutations(new string[] {"a","b","c"})[3]);
        Assert.Equivalent(new string[] {"c","a","b"}, Program.GeneratePermutations(new string[] {"a","b","c"})[4]);
        Assert.Equivalent(new string[] {"c","b","a"}, Program.GeneratePermutations(new string[] {"a","b","c"})[5]);
    }

    [Fact]
    public void TestQuadrupleNum()
    {
        Assert.Equivalent(new int[] {1,2,3,4}, Program.GeneratePermutations(new int[] {1,2,3,4})[0]);
        Assert.Equivalent(new int[] {1,2,4,3}, Program.GeneratePermutations(new int[] {1,2,3,4})[1]);
        Assert.Equivalent(new int[] {1,3,2,4}, Program.GeneratePermutations(new int[] {1,2,3,4})[2]);
        Assert.Equivalent(new int[] {1,3,4,2}, Program.GeneratePermutations(new int[] {1,2,3,4})[3]);
        Assert.Equivalent(new int[] {1,4,2,3}, Program.GeneratePermutations(new int[] {1,2,3,4})[4]);
        Assert.Equivalent(new int[] {1,4,3,2}, Program.GeneratePermutations(new int[] {1,2,3,4})[5]);
        Assert.Equivalent(new int[] {2,1,3,4}, Program.GeneratePermutations(new int[] {1,2,3,4})[6]);
        Assert.Equivalent(new int[] {2,1,4,3}, Program.GeneratePermutations(new int[] {1,2,3,4})[7]);
        Assert.Equivalent(new int[] {2,3,1,4}, Program.GeneratePermutations(new int[] {1,2,3,4})[8]);
        Assert.Equivalent(new int[] {2,3,4,1}, Program.GeneratePermutations(new int[] {1,2,3,4})[9]);
        Assert.Equivalent(new int[] {2,4,1,3}, Program.GeneratePermutations(new int[] {1,2,3,4})[10]);
        Assert.Equivalent(new int[] {2,4,3,1}, Program.GeneratePermutations(new int[] {1,2,3,4})[11]);
        Assert.Equivalent(new int[] {3,1,2,4}, Program.GeneratePermutations(new int[] {1,2,3,4})[12]);
        Assert.Equivalent(new int[] {3,1,4,2}, Program.GeneratePermutations(new int[] {1,2,3,4})[13]);
        Assert.Equivalent(new int[] {3,2,1,4}, Program.GeneratePermutations(new int[] {1,2,3,4})[14]);
        Assert.Equivalent(new int[] {3,2,4,1}, Program.GeneratePermutations(new int[] {1,2,3,4})[15]);
        Assert.Equivalent(new int[] {3,4,1,2}, Program.GeneratePermutations(new int[] {1,2,3,4})[16]);
        Assert.Equivalent(new int[] {3,4,2,1}, Program.GeneratePermutations(new int[] {1,2,3,4})[17]);
        Assert.Equivalent(new int[] {4,1,2,3}, Program.GeneratePermutations(new int[] {1,2,3,4})[18]);
        Assert.Equivalent(new int[] {4,1,3,2}, Program.GeneratePermutations(new int[] {1,2,3,4})[19]);
        Assert.Equivalent(new int[] {4,2,1,3}, Program.GeneratePermutations(new int[] {1,2,3,4})[20]);
        Assert.Equivalent(new int[] {4,2,3,1}, Program.GeneratePermutations(new int[] {1,2,3,4})[21]);
        Assert.Equivalent(new int[] {4,3,1,2}, Program.GeneratePermutations(new int[] {1,2,3,4})[22]);
        Assert.Equivalent(new int[] {4,3,2,1}, Program.GeneratePermutations(new int[] {1,2,3,4})[23]);
    }

}
