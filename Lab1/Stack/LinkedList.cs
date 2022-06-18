using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Stack
{
    internal class LinkedList<T> : ICollection<T>, ICollection
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;
        public LinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        #region implement ICollection<T>
        public int Count => _count;

        public bool IsReadOnly => false;

        
       

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                if (_tail != null)
                {
                    _tail.Next = newNode;
                    _tail = newNode;
                }
            }
            _count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }


        public bool Contains(T item)
        {

            if (item == null) throw new ArgumentException("Passed object cannot be null");

            if (_head == null) return false;

            Node<T> current = _head;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next!;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (_head == null)
                throw new InvalidOperationException("Collection is empty");

            Node<T> current = _head;
            while (current != null)
            {
                array[arrayIndex++] = current.Data;
                current = current.Next!;
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentException("Passed object cannot be null");

            if (_head == null)
                throw new InvalidOperationException("Collection is empty");

            Node<T> current = _head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(item))
                {
                    if (previous == null)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    _count--;
                    return true;
            }
            previous = current;
            current = current.Next!;
        }
            return false;
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

       

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region implement ICollection
        public bool IsSynchronized => false;

        public object SyncRoot => this;
        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("Passed array cannot be null");

            if (_head == null)
                throw new InvalidOperationException("Collection is empty");

            Node<T> current = _head;
            while (current != null)
            {
                array.SetValue(current.Data, index++);
                current = current.Next;
            }
        }
        #endregion

        public void AddFirst(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Passed object cannot be null");

            Node<T> newNode = new Node<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
            _count++;
        }
        public void RemoveFirst()
        {
            if (_head == null)
                throw new InvalidOperationException("Collection is empty");
            _head = _head.Next;
            _count--;
        }
    }
}
