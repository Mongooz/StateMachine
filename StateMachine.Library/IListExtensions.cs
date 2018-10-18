using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.Library
{
    /// <summary>
    /// Provides static extensions for the IList class
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Adds a new item to the list if no existing item is found using the selector
        /// </summary>
        /// <typeparam name="TType">The type of item held in the list</typeparam>
        /// <typeparam name="TProperty">The type of the property to use to compare</typeparam>
        /// <param name="list">The source list</param>
        /// <param name="propertyToCompare">The selector for an item to be compared with the new item</param>
        /// <param name="newItem">The new item to add to the list if it does not already exist</param>
        /// <returns>The specified new item, or an item from the list if the selector matches</returns>
        public static TType AddIfNotPresent<TType, TProperty>(this IList<TType> list, Func<TType, TProperty> propertyToCompare, TType newItem)
        {
            var existing = list.SingleOrDefault(item => propertyToCompare(item).Equals(propertyToCompare(newItem)));
            if (existing != null)
            {
                return existing;
            }

            //No existing item was found, so add it to the list
            list.Add(newItem);
            return newItem;
        }
    }
}
