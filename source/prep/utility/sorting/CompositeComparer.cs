using System.Collections.Generic;

namespace prep.utility.sorting
{
	public class CompositeComparer<ItemToSort> : IComparer<ItemToSort>
	{
		IComparer<ItemToSort> first;
		IComparer<ItemToSort> second;

		public CompositeComparer(IComparer<ItemToSort> first, IComparer<ItemToSort> second)
		{
			this.first = first;
			this.second = second;
		}

		public int Compare(ItemToSort x, ItemToSort y)
		{
			var result = first.Compare(x, y);

			return result == 0 ? second.Compare(x, y) : result;
		}
	}
}