using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class used to build the Heap serving as the underlying data structure for the Priority Queue required to
    /// get the most urgent orders i.e. the ones with the soonest deliver date
    /// 
    /// TODO: You are to determine whether this Heap should be a MinHeap or a MaxHeap 
    /// based on the way that urgent orders need to be identified i.e. soonest delivery date first.
    /// Implement the Insert() and Remove() method for this class; additional methods may be added but these 
    /// must be declared as private and called within the Insert() or Remove() method
    /// </summary>
    internal class Heap
    {
        //The array contaaining order elements upon which the heap is based
        private Order[] orderHeap;

        private int size;


        //Constructs a heap of the given size (based on how many orders need to be stored)
        public Heap(int maxSize)
        {
            orderHeap = new Order[maxSize];
            size = 0;
        }


        /// <summary>
        /// Inserts an order into the heap based on its delivery date.  
        /// Orders having the most recent delivery date should be place at the top of the heap
        /// </summary>
        /// <param name="order">Order to be inserted in the heap</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Insert(Order order)
        {
            if (size == orderHeap.Length)
                throw new InvalidOperationException("Heap is full");

            orderHeap[size] = order;
            size++;
            HeapifyUp(size - 1);
        }

        /// <summary>
        /// Returns the most recent order i.e. the one with the soonest delivery date
        /// </summary>
        /// <returns>Order with the soonest delivery date</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Order Remove()
        {
            if (size == 0)
                throw new InvalidOperationException("Heap is empty");

            Order root = orderHeap[0];
            orderHeap[0] = orderHeap[size - 1];
            size--;
            HeapifyDown(0);
            return root;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (orderHeap[index].deliverOn < orderHeap[parent].deliverOn)
                {
                    Swap(index, parent);
                    index = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < size && orderHeap[left].deliverOn < orderHeap[smallest].deliverOn)
                smallest = left;

            if (right < size && orderHeap[right].deliverOn < orderHeap[smallest].deliverOn)
                smallest = right;

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            Order temp = orderHeap[i];
            orderHeap[i] = orderHeap[j];
            orderHeap[j] = temp;
        }

        public int Count => size;
    }
}