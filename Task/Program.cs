namespace Task;

public class Program
{
    public static void Main(string[] args)
    {
        int result = binomial_coefficient(10,5);
        result = binomial_coefficient(10,5,true);
    }

public static int binomial_coefficient(int n, int k, bool rec = false)
{

   if(n < k)
   {
	throw new InvalidOperationException("n < k");
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
			
			 return binomial_coefficient(n-1,k-1, true) + binomial_coefficient(n-1,k, true);
		  }
		  
	}
}
