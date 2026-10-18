using System;
using System.Collections.Generic;

namespace Vehicles.Core.Repositories
{
    public class Repository<T>
    {
        private readonly List<T> _items = new();

        public event Action<T, T>? OnItemAdded;
        public event Action<T, T>? OnItemRemoved;

        public void Add(T item)
        {
            foreach (var existing in _items)
            {
                OnItemAdded?.Invoke(item, existing);
            }
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            foreach (var remaining in _items)
            {
                OnItemRemoved?.Invoke(item, remaining);
            }
        }

        public IEnumerable<T> GetAll() => _items;
    }
}