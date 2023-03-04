using System;

namespace Lab2
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;

        public MaxHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            if (initialArray == null)
            {
                return;
            }

            foreach (var item in initialArray)
            {
                Add(item);
            }
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex);

            Count++;

            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }
        }

        public T Extract()
        {
            return ExtractMax();
        }

        public T ExtractMax()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T max = array[0];

            Swap(0, Count - 1);

            Count--;

            TrickleDown(0);

            return max;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Update(T oldValue, T newValue)
        {
            int index = Array.IndexOf(array, oldValue);
            if (index < 0)
            {
                throw new ArgumentException("Old value not found in heap");
            }

            array[index] = newValue;

            if (newValue.CompareTo(oldValue) > 0)
            {
                TrickleUp(index);
            }
            else
            {
                TrickleDown(index);
            }
        }

        public void Remove(T value)
        {
            int index = Array.IndexOf(array, value);
            if (index < 0)
            {
                throw new ArgumentException("Value not found in heap");
            }

            // Swap the target element with the last element in the heap
            Swap(index, Count - 1);

            // Decrement the Count property to exclude the last element
            Count--;

            // Restore the heap property by trickling down the target element
            TrickleDown(index);
        }


        private void TrickleUp(int index)
        {
            int parentIndex = Parent(index);

            while (index > 0 && array[parentIndex].CompareTo(array[index]) < 0)
            {
                Swap(parentIndex, index);

                index = parentIndex;
                parentIndex = Parent(index);
            }
        }
        private void TrickleDown(int index)
        {
            int leftChildIndex, rightChildIndex, maxIndex;

            while (true)
            {
                leftChildIndex = LeftChild(index);
                rightChildIndex = RightChild(index);
                maxIndex = index;

                // If left child is greater than parent
                if (leftChildIndex < Count && array[leftChildIndex].CompareTo(array[maxIndex]) > 0)
                {
                    maxIndex = leftChildIndex;
                }

                // If right child is greater than parent
                if (rightChildIndex < Count && array[rightChildIndex].CompareTo(array[maxIndex]) > 0)
                {
                    maxIndex = rightChildIndex;
                }

                // If the maximum index is not the parent index
                if (maxIndex != index)
                {
                    // Swap the parent and the maximum element
                    Swap(maxIndex, index);

                    // Update the index
                    index = maxIndex;
                }
                else
                {
                    break;
                }
            }
        }
        private static int Parent(int position)
        {
            return (position - 1) / 2;
        }

        private static int LeftChild(int position)
        {
            return (2 * position) + 1;
        }

        private static int RightChild(int position)
        {
            return (2 * position) + 2;
        }

        private void Swap(int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }


    }
}






