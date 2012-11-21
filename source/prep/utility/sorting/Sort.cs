using System;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.sorting
{
  public interface ISpecifyASortOrder
  {
    IComparer<T> apply_to<T>(IComparer<T> comparer);
  }

  public class RegularSort : ISpecifyASortOrder
  {
    public IComparer<T> apply_to<T>(IComparer<T> comparer)
    {
      return comparer;
    }
  }
  public class SortDirection
  {
    public static readonly ISpecifyASortOrder ascending = new RegularSort();
    public static readonly ISpecifyASortOrder descending = new DescendingSort();
  }

  public class DescendingSort : ISpecifyASortOrder
  {
    public IComparer<T> apply_to<T>(IComparer<T> comparer)
    {
      return new ReverseComparer<T>(comparer);
    }
  }

  public static class Sort<ItemToSort>
	{
		public static IComparer<ItemToSort> by<Property>(PropertyAccessor<ItemToSort, Property> accessor,ISpecifyASortOrder direction) where Property : IComparable<Property>
		{
		  return direction.apply_to(get_builder(accessor, new ComparableComparer<Property>()));
		}
		public static IComparer<ItemToSort> by<Property>(PropertyAccessor<ItemToSort, Property> accessor) where Property : IComparable<Property>
		{
		  return get_builder(accessor, new ComparableComparer<Property>());
		}

		public static IComparer<ItemToSort> by_descending<Property>(PropertyAccessor<ItemToSort, Property> accessor) where Property : IComparable<Property>
		{
		  return new ReverseComparer<ItemToSort>(by(accessor));
		}

		static IComparer<ItemToSort> get_builder<Property>(PropertyAccessor<ItemToSort, Property> accessor, IComparer<Property> comparer) 
		{
			return new PropertyComparer<ItemToSort, Property>(accessor, comparer);
		}

		public static IComparer<ItemToSort> by<Property>(PropertyAccessor<ItemToSort, Property> accessor, params Property[] fixed_order)
		{
		  return get_builder(accessor, new RankingComparer<Property>(fixed_order));
		}
	}
}