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
			while(!foundValue){
				int triangleNum = GetNthTriangleNum(i);
				int numDivisors = GetTriangleNumDivisors(triangleNum).Count;
				if (numDivisors >= 500)
				{
					Console.WriteLine();
					Console.WriteLine($"{triangleNum} has {numDivisors} divisors.");
					Console.WriteLine();
					foundValue = true;
					break;
				}
				else
				{
					i++;					
				}
			}
    	}

    	private int GetNthTriangleNum(int n){
        	int triangleNum = 0;
			if (n <= 0)
			{
				return 0;
			}
			else if (triangleNums.ContainsKey(n))
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
			List<int> divisors = new List<int>();
			for (int i = triangleNum; i >= 1; i--){
				if (triangleNum % i == 0)
				{
					if (triangleNumDivisors.ContainsKey(i))
					{
						divisors.Concat(triangleNumDivisors[i]);
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