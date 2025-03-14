namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        int result = BinomialCoefficient(10,5);
        result = binomial_coefficient(10,5,true);
    }

public static int BinomialCoefficient(int n, int k, bool rec = false)
{

   if(n < k)
   {
	throw new InvalidOperationException("n < k");
   }

   if(n < 0 || k < 0)
   {
	throw new InvalidOperationException("n or k less than 0");
   }
   if(rec == false)
		  {
		      
		    List<int> PascalTriangleLine = new List<int>();
		    List<int> NextLine = new List<int>();
		    
		    PascalTriangleLine.Add(1);
		    PascalTriangleLine.Add(1);
		    
		    for(int i = 1; i < n; i++)
		    {
		        for(int j = 0; j < PascalTriangleLine.Count - 1; j++)
		        {
		            NextLine.Add(PascalTriangleLine[j] + PascalTriangleLine[j+1]);
		        }
		        
		        PascalTriangleLine.Clear();
		        
		        foreach(int x in NextLine)
		        {
		            PascalTriangleLine.Add(x);
		        }
		        
		        PascalTriangleLine.Insert(0,1);
		        PascalTriangleLine.Add(1);
		        
		        NextLine.Clear();
		        
		    }
			
			return PascalTriangleLine[k];
			
		  }
		  else
		  {
		     if(n==0 || k==0 || n==k)
			 {
			   return 1;
		     }
			
			 return BinomialCoefficient(n-1,k-1, true) + BinomialCoefficient(n-1,k, true);
		  }
		  
	}

public static string[] Generate_strings(int Maxlength, int array_length)
{

    if(Maxlength <= 0) throw new InvalidOperationException("Length <= 0");
    if(array_length <= 0) throw new InvalidOperationException("Array length <= 0");
	
    string[] result = new string[array_length];
    
    for(int i = 0; i < array_length; i++)
    {
        result[i] = "";
        Generate0(result, Maxlength, i);
    }

    return result;
}

public static void Generate0(string []imput, int Maxlength, int index)
{
    if (imput[index].Length != Maxlength)
    {
        imput[index] += "0";
        Generate1(imput, Maxlength, index);
    }
}

public static void Generate1(string []imput, int Maxlength, int index)
{
    if (imput[index].Length != Maxlength)
    {
        imput[index] += "1";
        Generate0(imput, Maxlength, index);
    }
}
}
