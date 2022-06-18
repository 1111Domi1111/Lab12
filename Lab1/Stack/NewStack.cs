using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Stack
{
    public class NewStack<T> : IEnumerable<T>, ICollection
    {
        private readonly LinkedList<T> _list;
        #region implement ICollection
        public int Count => _list.Count;
        public bool IsSynchronized => false;
        public object SyncRoot => this;
        public void CopyTo(Array array, int index)
        {
            _list.CopyTo(array, index);
        }
        #endregion
        #region implement IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        public delegate void Handler();
        public event Handler OnClear = delegate { };

        public delegate void ParameterHandler(T t);
        public event ParameterHandler OnPush = delegate { };
        public event ParameterHandler OnPop = delegate { };
        public event ParameterHandler OnPeek = delegate { };


        public NewStack()
        {
            _list = new LinkedList<T>();
        }

    

      

        public T Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            T item = _list.First();
            _list.RemoveFirst();
            OnPop.Invoke(item);

            return item;
        }

        public void Push(T item)
        {
            _list.AddFirst(item);
            OnPush.Invoke(item);
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Stack is empty");
            T item = _list.First();
            OnPeek.Invoke(item);
            return item;
        }

        public T[] ToArray()
        {
            T[] array = new T[_list.Count];
            _list.CopyTo(array, 0);

            return array;
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void Clear()
        {
            _list.Clear();
            OnClear.Invoke();
        }
    }
}
