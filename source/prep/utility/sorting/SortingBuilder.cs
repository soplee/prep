using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.sorting
{
	public class SortingBuilder<ItemToSort, Property> : IComparer<ItemToSort>
	{
		readonly PropertyAccessor<ItemToSort, Property> _accessor;
		readonly IComparer<Property> _propertyComparer;

		public SortingBuilder(PropertyAccessor<ItemToSort, Property> accessor, IComparer<Property> propertyComparer)
		{
			_accessor = accessor;
			_propertyComparer = propertyComparer;
		}

		public int Compare(ItemToSort x, ItemToSort y)
		{
			return _propertyComparer.Compare(_accessor(x), _accessor(y));
		}
	}
}