using System;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.sorting
{
	public static class Sort<ItemToSort>
	{
		public static SortingBuilder<ItemToSort, Property> by_ascending<Property>(PropertyAccessor<ItemToSort, Property> accessor) where Property : IComparable<Property>
		{
			var comparer = new ComparerWhenTypeIsComparable<Property>();

			return GetBuilder(accessor, comparer);
		}

		public static SortingBuilder<ItemToSort, Property> by_descending<Property>(PropertyAccessor<ItemToSort, Property> accessor) where Property : IComparable<Property>
		{
			var innerComparer = new ComparerWhenTypeIsComparable<Property>();
			var comparer = new NegatingComparer<Property>(innerComparer);

			return GetBuilder(accessor, comparer);
		}

		static SortingBuilder<ItemToSort, Property> GetBuilder<Property>(PropertyAccessor<ItemToSort, Property> accessor, IComparer<Property> comparer) where Property : IComparable<Property>
		{
			return new SortingBuilder<ItemToSort, Property>(accessor, comparer);
		}

		public static SortingBuilder<ItemToSort, Property> by<Property>(PropertyAccessor<ItemToSort, Property> accessor, params Property[] rankings)
		{
			var comparer = new RankingComparer<Property>(rankings);

			return new SortingBuilder<ItemToSort, Property>(accessor, comparer);
		}
	}
}