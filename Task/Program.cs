namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        float[,] matrix = new float[6, 6] 
        {
            { 1, 2, 2, 1, 3, 4 },
            { 3, 1, 1, 5, 7, 6 },
            { 3, 4, 1, 2, 7, 6 },
            { 5, 7, 1, 6, 4, 4 },
            { 5, 9, 2, 3, 5, 8 },
            { 2, 2, 1, 3, 1, 6 },
        };

        LengthPathObject result = new LengthPathObject();
        result = CalculatePath(matrix);

        Console.WriteLine("Длина пути: {0}", result.Length);
        
        foreach (var indexes in result.Path)
        {
          Console.WriteLine($"{indexes[0]}, {indexes[1]}");
        }
    }

public static LengthPathObject CalculatePath(float[,] matrix)
{
    List<int[]> path = new List<int[]>();
    LengthPathObject result = new LengthPathObject();

    float[,] coeffMatrix = new float[matrix.GetLength(0)+2, matrix.GetLength(1)+2];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            coeffMatrix[i+1, j+1] = matrix[i, j];
        }
    }

    for (int i = 0; i < coeffMatrix.GetLength(0); i+= coeffMatrix.GetLength(0)-1)
    {
        for (int j = 0; j < coeffMatrix.GetLength(1); j++)
        {
            coeffMatrix[i, j] = float.PositiveInfinity;
        }
    }

    for (int i = 0; i < coeffMatrix.GetLength(1); i += coeffMatrix.GetLength(1) - 1)
    {
        for (int j = 0; j < coeffMatrix.GetLength(0); j++)
        {
            coeffMatrix[j, i] = float.PositiveInfinity;
        }
    }

    float cumulative = 0f;
    
    for (int i = 1; i < coeffMatrix.GetLength(0) - 1; i++)
    {
        coeffMatrix[i, 1] = coeffMatrix[i, 1] + cumulative;
        cumulative = coeffMatrix[i, 1];
    }

    cumulative = 0f;

    for (int i = 1; i < coeffMatrix.GetLength(1) - 1; i++)
    {
        coeffMatrix[1, i] = coeffMatrix[1, i] + cumulative;
        cumulative = coeffMatrix[1, i];
    }

    for (int i = 2; i < coeffMatrix.GetLength(0) - 1; i++)
    {
        for (int j = 2; j < coeffMatrix.GetLength(1) - 1; j++)
        {
            bool comparisonResult = coeffMatrix[i - 1, j] < coeffMatrix[i, j - 1];

            if (comparisonResult)
            {
                coeffMatrix[i, j] = coeffMatrix[i - 1, j] + coeffMatrix[i, j];
            }
            else
            {
                coeffMatrix[i, j] = coeffMatrix[i, j - 1] + coeffMatrix[i, j];
            }
        }
    }

    int rowPosition = coeffMatrix.GetLength(0) - 2;
    int columnPosition = coeffMatrix.GetLength(1) - 2;

    while (rowPosition >= 1 && columnPosition >= 1)
    {
        if (coeffMatrix[rowPosition, columnPosition - 1] < coeffMatrix[rowPosition - 1, columnPosition])
        {
            int[] indexes = { rowPosition, columnPosition };
            path.Add(indexes);
            columnPosition--;
        }
        else
        {
            int[] indexes = { rowPosition, columnPosition };
            path.Add(indexes);
            rowPosition--;
        }
    }

    float pathLength = coeffMatrix[coeffMatrix.GetLength(0) - 2, coeffMatrix.GetLength(1) - 2];
    path.Reverse();
    result.Length = pathLength;
    result.Path = path;

    return result;

}
}

public class LengthPathObject
{
    public float Length;
    public List<int[]> Path;

    public LengthPathObject(float length, List<int[]> path)
    {
      Length = length;
      Path = path;
    }

    public LengthPathObject()
    {
      Length = 0;
      Path = new List<int[]>();
    }

    
}
