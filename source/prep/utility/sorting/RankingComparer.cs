using System.Collections.Generic;

namespace prep.utility.sorting
{
	public class RankingComparer<Property> : IComparer<Property>
	{
		List<Property> _rankings = new List<Property>();

		public RankingComparer(params Property[] rankings)
		{
			_rankings.AddRange(rankings);
		}

		public int Compare(Property x, Property y)
		{
			var xIndex = _rankings.IndexOf(x);
			var yIndex = _rankings.IndexOf(y);

			return xIndex.CompareTo(yIndex);
		}
	}
}