using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_SelectionContainer
{
    public class Container
    {
        private readonly ConcurrentDictionary<Guid,IEnumerable> registeredElements = new ConcurrentDictionary<Guid, IEnumerable>();

        public Guid Register(IEnumerable element)
        {
            var id = Guid.NewGuid();

            if (!registeredElements.TryAdd(id, element))
            {
                id = Guid.Empty;
            }

            return id;
        }

        public IEnumerable<TType> Select<TType>(Guid id, int skip, int take)
        {
            if ((take <= 0)
                || (skip < 0))
            {
                throw new ArgumentException("Incorrect skip or take");
            }

            if (id.Equals(Guid.Empty))
            {
                throw new ArgumentException("Empty id");
            }

            var selection = new BlockingCollection<object>();
            foreach(var element in registeredElements[id])
            {
                if (skip > 0)
                {
                    skip--;
                    continue;
                }

                if (take > 0)
                {
                    selection.Add(element);
                    take--;
                }
            }
            return (IEnumerable<TType>)selection;
        }
       
    }
}
