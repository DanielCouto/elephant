﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Take.Elephant.Memory
{
    public class ListMap<TKey, TValue> : Map<TKey, IList<TValue>>, IListMap<TKey, TValue>
    {
        /// <summary>
        /// Gets the value for the key if the exists or a new list for the type, if not.
        /// If the later, the item is automatically added to the map.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>An existing list if the key exists; otherwise, an empty list.</returns>
        public Task<IList<TValue>> GetValueOrEmptyAsync(TKey key)
            => InternalDictionary.GetOrAdd(key, k => ValueFactory()).AsCompletedTask();
    }
}