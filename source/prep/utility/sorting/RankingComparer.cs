using System.Collections.Generic;

namespace prep.utility.sorting
{
	public class RankingComparer<Property> : IComparer<Property>
	{
		IList<Property> rankings = new List<Property>();

		public RankingComparer(params Property[] rankings)
		{
		  this.rankings = new List<Property>(rankings);
		}

		public int Compare(Property x, Property y)
		{
		  return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
		}
	}
}