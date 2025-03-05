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

        Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();
        result = CalculatePath(matrix);

        string pathString = "";

        foreach (var pair in result)
        {
            foreach (var index in pair.Value)
            {
            pathString += index + " | ";
            }
    
        Console.WriteLine($"Длина пути: {pair.Key}  Путь: {pathString}");
        }
    }

static Dictionary< float, List<string> > CalculatePath(float[,] matrix)
{
    List<string> path = new List<string>();
    float[,] coeffMatrix = (float[,])matrix.Clone();
    Dictionary<float, List<string> > result = new Dictionary<float, List<string> >();

    float cumulative = 0f;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        coeffMatrix[i, 0] = matrix[i, 0] + cumulative;
        path.Add(string.Format("{0}, 0 ", i));
        cumulative = matrix[i, 0] + cumulative;
    }

    if (matrix.GetLength(1) == 1)
    {
        float pathLength1 = coeffMatrix[coeffMatrix.GetLength(0) - 1, coeffMatrix.GetLength(1) - 1];
        result.Add(pathLength1, path);
        return result;
    }
    else
    {
        path = new List<string>();
    }

    cumulative = 0;

    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        coeffMatrix[0, i] = matrix[0, i] + cumulative;
        path.Add(string.Format("0, {0} ", i));
        cumulative = matrix[0, i] + cumulative;
    }

    if (matrix.GetLength(0) == 1)
    {
        float pathLength2 = coeffMatrix[coeffMatrix.GetLength(0) - 1, coeffMatrix.GetLength(1) - 1];
        result.Add(pathLength2, path);
        return result;
    }
    else
    {
        path = new List<string>();
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

    for (int i = 0; i < coeffMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < coeffMatrix.GetLength(1); j++)
        {
            Console.WriteLine(coeffMatrix[i, j]);
        }
    }

    int rowPosition = coeffMatrix.GetLength(0) - 1;
    int columnPosition = coeffMatrix.GetLength(1) - 1;

    while(rowPosition>=0 && columnPosition>=0)
    {
        if(rowPosition == 0)
        {
            path.Add ($" {rowPosition}, {columnPosition}");
            columnPosition--;
            continue;
        }

        if (columnPosition == 0)
        {
            path.Add($" {rowPosition}, {columnPosition}");
            rowPosition--;
            continue;
        }

        if (coeffMatrix[rowPosition,columnPosition - 1] < coeffMatrix[rowPosition - 1, columnPosition])
        {
            path.Add($" {rowPosition}, {columnPosition}");
            columnPosition--;
        }
        else
        {
            path.Add($" {rowPosition}, {columnPosition}");
            rowPosition--;
        }
    }

    float pathLength = coeffMatrix[coeffMatrix.GetLength(0) - 1, coeffMatrix.GetLength(1) - 1];
    path.Reverse();
    result.Add(pathLength, path);

    return result;

}
}
