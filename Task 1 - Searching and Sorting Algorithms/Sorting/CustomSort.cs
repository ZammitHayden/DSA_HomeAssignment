using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Deliver Date (most recent first) 
    /// using any sorting algorithm of your choice
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class CustomSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> sortedList = new List<Order>(unsortedOrderList);

            HeapSort(sortedList);

            return sortedList;
        }

        private void HeapSort(List<Order> list)
        {
            int n = list.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(list, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Order temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                Heapify(list, i, 0);
            }
        }

        private void Heapify(List<Order> list, int n, int i)
        {
            int largest = i; 
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && list[left].deliverOn > list[largest].deliverOn)
                largest = left;

            if (right < n && list[right].deliverOn > list[largest].deliverOn)
                largest = right;

            if (largest != i)
            {
                Order swap = list[i];
                list[i] = list[largest];
                list[largest] = swap;

                Heapify(list, n, largest);
            }
        }
    }
}
