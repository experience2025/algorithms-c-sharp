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

        string pathString = "";
        Console.WriteLine("Длина пути: {0}", result.Length);
        
        foreach (var indexes in result.Path)
        {
          Console.WriteLine($"{indexes[0]}, {indexes[1]}");
        }
    }

public static LengthPathObject CalculatePath(float[,] matrix)
{
    List<int[]> path = new List<int[]>();
    float[,] coeffMatrix = (float[,])matrix.Clone();
    LehgthPathObject result = new LengthPathObject();

    float cumulative = 0f;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        coeffMatrix[i, 0] = matrix[i, 0] + cumulative;
        int[] indexes = new int[2] {i, 0};
        path.Add(indexes);
        cumulative = matrix[i, 0] + cumulative;
    }

    if (matrix.GetLength(1) == 1)
    {
        float pathLength1 = coeffMatrix[coeffMatrix.GetLength(0) - 1, coeffMatrix.GetLength(1) - 1];
        result.Path = path;
        result.Length = pathLength1;
        return result;
    }
    else
    {
        path = new List<int[]>();
    }

    cumulative = 0;

    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        coeffMatrix[0, i] = matrix[0, i] + cumulative;
        int[] indexes = new int[2] {0, i};
        path.Add(indexes);
        cumulative = matrix[0, i] + cumulative;
    }

    if (matrix.GetLength(0) == 1)
    {
        float pathLength2 = coeffMatrix[coeffMatrix.GetLength(0) - 1, coeffMatrix.GetLength(1) - 1];
        result.Path = path;
        result.Length = pathLength2;
        return result;
    }
    else
    {
        path = new List<int[]>();
    }

    for (int i = 1; i < coeffMatrix.GetLength(0); i++)
    {
        for (int j = 1; j < coeffMatrix.GetLength(1); j++)
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

    int rowPosition = coeffMatrix.GetLength(0) - 1;
    int columnPosition = coeffMatrix.GetLength(1) - 1;

    while(rowPosition>=0 && columnPosition>=0)
    {
        if(rowPosition == 0)
        {
            int[] indexes = new int[2] {rowPosition, columnPosition};
            path.Add (indexes);
            columnPosition--;
            continue;
        }

        if (columnPosition == 0)
        {
            int[] indexes = new int[2] {rowPosition, columnPosition};
            path.Add (indexes);
            rowPosition--;
            continue;
        }

        if (coeffMatrix[rowPosition,columnPosition - 1] < coeffMatrix[rowPosition - 1, columnPosition])
        {
            int[] indexes = new int[2] {rowPosition, columnPosition};
            path.Add (indexes);
            columnPosition--;
        }
        else
        {
            int[] indexes = new int[2] {rowPosition, columnPosition};
            path.Add (indexes);
            rowPosition--;
        }
    }

    float pathLength = coeffMatrix[coeffMatrix.GetLength(0) - 1, coeffMatrix.GetLength(1) - 1];
    path.Reverse();
    result.Length = pathLength;
    result.Path = path;

    return result;

}

public class LengthPathObject
{
    public int Length;
    public List<int[]> Path;

    public LengthPathObject(int length, List<int[]> path)
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
    
}
