using System;
using System.Linq;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;


        public MinHeap(T[] initialArray = null)
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

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(?)
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        // TODO
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(?)
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex);

            Count++;

            // resize if full
            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }

        }

        public T Extract()
        {
            return ExtractMin();
        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O(N*log(N))
        /// </summary>
        public T ExtractMax()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            // create a new max heap and insert all elements from min heap
            var maxHeap = new MaxHeap<T>();
            while (!IsEmpty)
            {
                maxHeap.Add(ExtractMin());
            }

            // extract the maximum value from the max heap
            return maxHeap.Extract();
        }


        // TODO
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time complexity: O( log(n) )
        /// </summary>
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T min = array[0];

            // swap root (first) and last element
            Swap(0, Count - 1);

            // "remove" last
            Count--;

            // trickle down from root (first)
            TrickleDown(0);

            return min;
        }

        // TODO
        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O( N )
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

        }

        // TODO
        /// <summary>
        /// Updates the first element with the given value from the heap.
        /// Time complexity: O(N)
        /// </summary>
        public void Update(T oldValue, T newValue)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(oldValue))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new ArgumentException("Value not found in heap");
            }

            array[index] = newValue;

            if (index == 0 || array[index].CompareTo(array[Parent(index)]) > 0)
            {
                TrickleDown(index);
            }
            else
            {
                TrickleUp(index);
            }
        }



        // TODO
        /// <summary>
        /// Removes the first element with the given value from the heap.
        /// Time complexity: O(N)
        /// </summary>
        public void Remove(T value)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new ArgumentException("Value not found in heap");
            }

            Swap(index, Count - 1);
            Count--;

            if (index == 0 || array[index].CompareTo(array[Parent(index)]) > 0)
            {
                TrickleDown(index);
            }
            else
            {
                TrickleUp(index);
            }
        }


        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            // Get the parent index
            int parentIndex = Parent(index);

            // While the index is not at the root and the parent is greater than the current node
            while (index > 0 && array[parentIndex].CompareTo(array[index]) > 0)
            {
                // Swap the parent and current node
                Swap(parentIndex, index);

                // Update the current index and parent index
                index = parentIndex;
                parentIndex = Parent(index);
            }
        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {
            int leftChildIndex, rightChildIndex, minIndex;

            while (true)
            {
                leftChildIndex = LeftChild(index);
                rightChildIndex = RightChild(index);
                minIndex = index;

                // If left child is smaller than parent
                if (leftChildIndex < Count && array[leftChildIndex].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = leftChildIndex;
                }

                // If right child is smaller than parent
                if (rightChildIndex < Count && array[rightChildIndex].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = rightChildIndex;
                }

                // If the minimum index is not the parent index
                if (minIndex != index)
                {
                    // Swap the parent and the minimum element
                    Swap(minIndex, index);

                    // Update the index
                    index = minIndex;
                }
                else
                {
                    break;
                }
            }
        }

        // TODO
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            return (position - 1) / 2;
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            return (2 * position) + 1;
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            return (2 * position) + 2;
        }


        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }


    }
}
