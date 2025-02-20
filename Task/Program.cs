namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        int[,] example = new int[4, 4]
        {
            { 12, 5, 6, 1}, { 7, 8, 9, 4 }, { 11, -1, 2, 5 }, { 20, 3, 6, 9 }
        };

        calculateDeterminant(example);
    }

public static long calculateDeterminant(int[,] matrix)
{
    if (matrix.GetLength(0) != matrix.GetLength(1))
    {
        throw new ArgumentException("Матрица не квадратная");
    }

    bool flag = false;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[i, j] != 0 || matrix.GetUpperBound(0) + 1 == 1) flag = true;
        }
    }

    if(flag == false)
    {
        throw new ArgumentException("Матрица вырожденная");
    }

    if (matrix.GetUpperBound(0) + 1 == 1)
    {
        return (long)matrix[0, 0];
    }

    else
    {

        long cumulative = 0;

        for(int i = 0; i < matrix.GetLength(1); i++)
        {
            int[,] minor = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

            for(int j = 1; j < matrix.GetLength(0); j++)
            {
                int y = 0;

                for (int k = 0; k < matrix.GetLength(1); k++)
                {

                    if (k == i)
                    {
                        continue;
                    }

                    minor[j - 1, y] = matrix[j, k];

                    y++;
                 
                }

            }

            cumulative += (long)Math.Pow(-1, 1 + i + 1) * matrix[0, i] * calculateDeterminant(minor);

        }

        return cumulative;
    }

}

}
