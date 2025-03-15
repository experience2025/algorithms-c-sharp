namespace Task;

public class Program
{
  public static void Main(string[] args)
  {
    string[] a = { "2" , "1", "3" };

    foreach (string[] permutation in GeneratePermutations(a))
    {
  	foreach(string s in permutation)
        {
      	  Console.Write(s + " ");
 	}
     Console.WriteLine();	    
     }
  }

static List<string[]> GeneratePermutations<T>(T[] objects) 
{
   string[] sortedObjects = new string[objects.Length];
   List<string[]> result = new List<string[]>();

  for (int i = 0; i < objects.Length; i++)
  {
     if (objects[i].GetType() != typeof(String)
     && objects[i].GetType() != typeof(Int32)
     && objects[i].GetType() != typeof(Boolean))
     {
         throw new ArgumentException("Можно использовать только строки, логические переменные и целые числа");
     }
   }

  if (objects.Length == 1)
  {
     result.Add([objects[0].ToString()]);
     return result;
  }

 if (objects.Length == 0)
 {
     return result;
 }

 if (objects.Distinct().Count() != objects.Length)
 {
     throw new ArgumentException("В массиве есть дубликаты");
 }

 for (int i = 0; i < objects.Length; i++)
 {
     sortedObjects[i] = objects[i].ToString();
 }

    Array.Sort(sortedObjects);

    string[] firstEntry = new string[sortedObjects.Length];
    Array.Copy(sortedObjects, firstEntry, sortedObjects.Length);
    result.Add(firstEntry);

    bool stopFlag = false;

    while(!stopFlag)
    {
        int j = 0;

        for (int i = sortedObjects.Length - 1; i >= 1; i--)
        {
            if (sortedObjects[i-1].CompareTo(sortedObjects[i]) < 0)
            {
                j = i - 1;
                break;
            }

            if (i == 1)
            {
                stopFlag = true;
                break;
            }
        }

        if (stopFlag == true)
        {
            break;
        }

        for (int i = sortedObjects.Length - 1; i > j; i--)
        {
            if (sortedObjects[i].CompareTo(sortedObjects[j]) > 0)
            {
                string s = sortedObjects[j];
                sortedObjects[j] = sortedObjects[i];
                sortedObjects[i] = s;

                break;
            }
        }

        Array.Reverse(sortedObjects, j + 1, sortedObjects.Length - j - 1);

        string[] arrayToAdd = new string[sortedObjects.Length];
        Array.Copy(sortedObjects,arrayToAdd, sortedObjects.Length);
        
        result.Add(arrayToAdd);

    }

    return result;
}
}
