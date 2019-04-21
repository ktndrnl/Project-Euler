using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
	class Program
	{
		static void Main(string[] args)
		{
			var problem12 = new Problem12();
			problem12.Solution();
		}
	}

	public class Problem12
	{
		Dictionary<int, int> triangleNums;
		Dictionary<int, List<int>> triangleNumDivisors;

		public Problem12(){
			triangleNums = new Dictionary<int, int>();
			triangleNums.Add(1, 1);
			triangleNumDivisors = new Dictionary<int, List<int>>();
		}
    	public void Solution(){
        	bool foundValue = false;
			int i = 1;
			DateTime startTime = DateTime.Now;
			while(!foundValue){
				int triangleNum = GetNthTriangleNum(i);
				int numDivisors = GetTriangleNumDivisors(triangleNum).Count;
				if (numDivisors >= 500)
				{
					Console.WriteLine();
					Console.WriteLine($"{triangleNum} has {numDivisors} divisors.");
					Console.WriteLine();
					foundValue = true;
				}
				else
				{
					if (DateTime.Now - startTime >= TimeSpan.FromSeconds(10))
					{
						Console.WriteLine($"{triangleNum} has {numDivisors} divisors.");
						startTime = DateTime.Now;
					}
					i++;					
				}
			}
    	}

    	private int GetNthTriangleNum(int n){
        	int triangleNum;
			if (n <= 0)
			{
				return 0;
			}
			if (triangleNums.ContainsKey(n))
			{
				return triangleNums[n];
			}
			else
			{
				triangleNum = GetNthTriangleNum(n - 1) + n;
				triangleNums.Add(n, triangleNum);
				return triangleNum;
			}
    	}

		private List<int> GetTriangleNumDivisors(int triangleNum){
			List<int> divisors = new List<int> {triangleNum};
			for (int i = triangleNum / 2; i >= 1; i--){
				if (triangleNum % i == 0)
				{
					if (triangleNumDivisors.ContainsKey(i))
					{
						divisors.AddRange(triangleNumDivisors[i]);
						break;
					}
					divisors.Add(i);
				}
			}
			triangleNumDivisors.Add(triangleNum, divisors);
			return divisors;
		}
	}
}