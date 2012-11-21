using System.Collections.Generic;

namespace prep.utility.sorting
{
	public class CompositeComparer<ItemToSort> : IComparer<ItemToSort>
	{
		readonly IComparer<ItemToSort> _first;
		readonly IComparer<ItemToSort> _second;

		public CompositeComparer(IComparer<ItemToSort> first, IComparer<ItemToSort> second)
		{
			_first = first;
			_second = second;
		}

		public int Compare(ItemToSort x, ItemToSort y)
		{
			var result = _first.Compare(x, y);

			return result == 0 ? _second.Compare(x, y) : result;
		}
	}
}