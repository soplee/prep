using System.Collections.Generic;

namespace prep.utility.sorting
{
	public class NegatingComparer<PropertyType> : IComparer<PropertyType>
	{
		readonly IComparer<PropertyType> _inner;

		public NegatingComparer(IComparer<PropertyType> inner)
		{
			_inner = inner;
		}

		public int Compare(PropertyType x, PropertyType y)
		{
			return -_inner.Compare(x, y);
		}
	}
}