using System;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility.sorting
{
  public static class ComparerExtensions
  {
    public static IComparer<ItemToSort> then_by<Property, ItemToSort>(this IComparer<ItemToSort> first,
                                                                      PropertyAccessor<ItemToSort, Property> accessor)
      where Property : IComparable<Property>
    {
      return new CompositeComparer<ItemToSort>(first, Sort<ItemToSort>.by(accessor));
    }
  }
}