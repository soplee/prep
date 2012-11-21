using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.sorting
{
	public class PropertyComparer<ItemToSort, Property> : IComparer<ItemToSort>
	{
		PropertyAccessor<ItemToSort, Property> accessor;
		IComparer<Property> real_comparer;

		public PropertyComparer(PropertyAccessor<ItemToSort, Property> accessor, IComparer<Property> real_comparer)
		{
			this.accessor = accessor;
			this.real_comparer = real_comparer;
		}

		public int Compare(ItemToSort x, ItemToSort y)
		{
			return real_comparer.Compare(accessor(x), accessor(y));
		}
	}
}