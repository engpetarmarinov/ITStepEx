using System;

namespace List
{
    public class ListGeneric<T>
    {
        private T[] _elements;
        private const int InitialCapacity = 8;
        public int Length { get; private set; } = 0;

        private event Action OnSizeChangeEvent;
        private event Action OnListFullEvent;

        public ListGeneric()
        {
            if (_elements == null)
                _elements = new T[InitialCapacity];
            //bind handlers
            OnSizeChangeEvent += CheckSize;
            OnListFullEvent += IncreaseSize;
        }

        public ListGeneric(int capacity) : this()
        {
            _elements = new T[capacity];
        }

        private void CheckSize()
        {
            Console.WriteLine("CheckSize");
            if (_elements != null && _elements.Length <= Length)
            {
                OnListFullEvent?.Invoke();
            }
        }

        private void IncreaseSize()
        {
            Console.WriteLine("Increase size");
            var newElements = new T[_elements.Length + InitialCapacity];
            _elements.CopyTo(newElements, 0);
            _elements = newElements;
        }

        public T Get(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new ArgumentException("Index is not in the list");
            }
            return _elements[index];
        }

        public void Add(T el)
        {
            OnSizeChangeEvent?.Invoke();
            _elements[Length] = el;
            Length++;
        }

        public void AddAt(int index, T el)
        {
            OnSizeChangeEvent?.Invoke();
            MoveToRightAt(index);
            UpdateAt(index, el);
            Length++;
        }

        private void MoveToRightAt(int index)
        {
            if (index > Length || index < 0)
            {
                throw new Exception("No such index in the list.");
            }
            var rightElements = new T[Length - index];
            //create right part
            if (rightElements.Length < 0)
            {
                Array.Copy(_elements, index + 1, rightElements, 0, rightElements.Length);
            }
            //move the right part to the right
            Array.Copy(rightElements, 0, _elements, index + 1, rightElements.Length);

        }

        public void RemoveAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new Exception("No such index in the list.");
            }
            var rightElements = new T[Length - 1 - index];
            //create right part
            if (rightElements.Length < 0)
            {
                Array.Copy(_elements, index + 1, rightElements, 0, rightElements.Length);
                //move the right to the left
                Array.Copy(rightElements, 0, _elements, index, rightElements.Length);
            }
            else
            {
                UpdateAt(index, default(T));
            }
            Length--;
        }

        public bool HasIndex(int index)
        {
            return (index < Length && index >= 0);
        }

        public T this[int index]
        {
            get { return Get(index); }
            set
            {
                if (HasIndex(index))
                    UpdateAt(index, value);
                else
                    AddAt(index, value);
            }
        }

        private void UpdateAt(int index, T value)
        {
            _elements[index] = value;
        }
    }
}