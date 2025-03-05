using Task;

namespace Tests;

public class Test
{
    [Fact]
    public void TestSingle()
    {
       float [,] testMatrix = new float[1,1];
       testMatrix[0,0] = 1;

       List<string> path = new List<string>() {0, 0};
       Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
       result.Add(1, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
    }

    [Fact]
    public void TestNotSquareRectangle()
    {
       int [,] testMatrix = new int[1,2];
       testMatrix[0,0] = 1;
       testMatrix[0,1] = 2;
       Assert.Throws<ArgumentException>(() => Program.calculateDeterminant(testMatrix));
    }

    [Fact]
    public void TestDouble()
    {
       int [,] testMatrix = new int[3,3];

       testMatrix[0,0] = 1;
       testMatrix[0,1] = -2;
       testMatrix[0,2] = 3;
       testMatrix[1,0] = -4;
       testMatrix[1,1] = 5;
       testMatrix[1,2] = -6;
       testMatrix[2,0] = 7;
       testMatrix[2,1] = -8;
       testMatrix[2,2] = 9;

       Assert.Throws<ArgumentException>(() => Program.calculateDeterminant(testMatrix));

    }
    [Fact]
    public void TestFourthOrder()
    {
       int [,] testMatrix = new int[4,4];

       testMatrix[0,0] = 3;
       testMatrix[0,1] = -3;
       testMatrix[0,2] = -5;
       testMatrix[0,3] = 8;
       testMatrix[1,0] = -3;
       testMatrix[1,1] = 2;
       testMatrix[1,2] = 4;
       testMatrix[1,3] = -6;
       testMatrix[2,0] = 2;
       testMatrix[2,1] = -5;
       testMatrix[2,2] = -7;
       testMatrix[2,3] = 5;
       testMatrix[3,0] = -4;
       testMatrix[3,1] = 3;
       testMatrix[3,2] = 5;
       testMatrix[3,3] = -6;

       Assert.Equal(18, Program.calculateDeterminant(testMatrix));
    }

    [Fact]
    public void TestLarge()
    {
       int [,] testMatrix = 
       {
            {3, 7, -5, 1, 19, 5, 0, -2, 4, 10},
            {-2, 2, 4, -6, 1, 0, 3, 5, 7, 1},
            {5, -5, -7, 5, 8, 9, -1, 0, 2, 2},
            {-4, 3, 5, -6, 17, -1, 9, 0, 2, 3},
            {3, -3, -5, 8, -9, -1, 0, 2, 4, 7},
            {-3, 2, 4, -6, 1, 0, 3, 5, 7, 11},
            {2, -5, -7, 7, 8, 9, -1, 0, -2, 5},
            {-4, 3, 15, -6, 7, -1, 9, 1, 2, 13},
            {3, -3, -5, 8, 9, -1, 0, 2, 4, 17},
            {-13, 2, 4, -6, 1, 0, -3, 5, 7, 1},
       };

       Assert.Equal(4204289520, (ulong)Program.calculateDeterminant(testMatrix));
    }
}
