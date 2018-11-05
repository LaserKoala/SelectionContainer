using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace SelectionContainer
{
    public class Container
    {
        private readonly ConcurrentDictionary<Guid,IEnumerable> registeredElements = new ConcurrentDictionary<Guid, IEnumerable>();

        public int Count
        {
            get
            {
                return registeredElements.Count;
            }
        }


        public Guid Register(IEnumerable element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Null element");
            }

            var id = Guid.NewGuid();
            if (!registeredElements.TryAdd(id, element))
            {
                return Guid.Empty;
            }

            return id;
        }


        public IEnumerable<TType> Select<TType>(Guid id, int skip, int take)
        {
            if (!registeredElements.TryGetValue(id, out var elements))
            {
                return new List<TType>();
            }
            if (elements as IEnumerable<TType> == null)
            {
                return new List<TType>();
            }

            return (elements as IEnumerable<TType>).Skip(skip).Take(take);
        }

        public bool Remove(Guid id)
        {
            return registeredElements.TryRemove(id, out var value);
        }

        public void Clear()
        {
            registeredElements.Clear();
        }
    }
}
