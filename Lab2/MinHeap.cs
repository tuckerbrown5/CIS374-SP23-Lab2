using System;
using System.Linq;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        
        public MinHeap(T[] initialArray = null)
        {



        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(?).
        /// </summary>
        public T Peek()
        {

        }

        // TODO
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(?).
        /// </summary>
        public void Add(T item)
        {


        }

        public T Extract()
        {
            return ExtractMin();
        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O(?).
        /// </summary>
        public T ExtractMax()
        {

        }

        // TODO
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time complexity: O(?).
        /// </summary>
        public T ExtractMin()
        {

        }

        // TODO
        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O(N).
        /// </summary>
        public bool Contains(T value)
        {

        }

        // TODO
        private void TrickleUp(int index)
        {


        }

        // TODO
        private void TrickleDown(int index)
        {

        }

        // TODO
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {

        }

        // TODO
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
        }

        // TODO
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
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


