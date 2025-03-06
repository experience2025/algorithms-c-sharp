using Task;

namespace Tests;

public class Test
{
    [Fact]
    public void TestSingle()
    {
       float [,] testMatrix = new float[1,1];
       testMatrix[0,0] = 1;

       int[] indexes = new int[2] {0,0};
       List<int[]> path = new List<int[]>() {indexes};
       Task.LengthPathObject result = new Task.LengthPathObject(1, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
    }

    [Fact]
    public void TestDouble()
    {
       float [,] testMatrix = new float[2,2] {{1.1f,2}, {3,4}};

       List<int[]> path = new List<int[]>() {{new int[2]{0,0}}, {new int[2]{0,1}}, {new int[2]{1,1}}};
       Task.LengthPathObject result = new Task.LengthPathObject(7.1f, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));

    }
    [Fact]
    public void TestNegative()
    {
       float [,] testMatrix = new float[2,2] {{1.1f,2}, {-3,4}};
        
       List<string> path = new List<string>() {"0, 0", "1, 0", "1, 1"};
       Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
       result.Add(2.1f, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
    }

    [Fact]
    public void TestTriple()
    {
       float [,] testMatrix = new float[3,3] {{1,2,2}, {3,4,2}, {1,1,2}};
        
       List<string> path = new List<string>() {"0, 0", "1, 0", "2, 0", "2, 1", "2, 2"};
       Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
       result.Add(8, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
    }

    [Fact]
    public void TestRectangle()
    {
       float [,] testMatrix = new float[2,3] {{1,2,2}, {3,4,1}};
        
       List<string> path = new List<string>() {"0, 0", "0, 1", "0, 2", "1, 2"};
       Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
       result.Add(6, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
    }

    [Fact]
    public void TestSquare()
    {
       float [,] testMatrix = new float[6,6] 
       {
            {1, 2, 2, 1, 3, 4},
            {3, 1, 1, 5, 7, 6},
            {3, 4, 1, 2, 7, 6},
            {5, 7, 1, 6, 4, 4},
            {5, 9, 2, 3, 5, 8},
            {2, 2, 1, 3, 1, 6},
       };
        
       List<string> path = new List<string>() 
       {
            "0, 0",
            "0, 1",
            "1, 1",
            "1, 2",
            "2, 2",
            "3, 2",
            "4, 2",
            "5, 2",
            "5, 3",
            "5, 4",
            "5, 5"
       };
       Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
       result.Add(20, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
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
        
       List<string> path = new List<string>() 
       {
                    "0, 0",
                    "1, 0",
                    "1, 1",
                    "2, 1",
                    "3, 1",
                    "3, 2",
                    "4, 2",
                    "5, 2",
                    "5, 3",
                    "5, 4",
                    "6, 4",
                    "7, 4",
                    "7, 5",
                    "8, 5",
                    "9, 5",
                    "10, 5",
                    "11, 5"
       };
       Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
       result.Add(52, path);
        
       Assert.Equal(result, Program.CalculatePath(testMatrix));
    }
}
