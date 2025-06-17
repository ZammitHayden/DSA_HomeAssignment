using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Date Placed (most recent first) using Merge Sort
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class MergeSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> sortedList = new List<Order>(unsortedOrderList);

            List<Order> result = MergeSortList(sortedList);

            return result;
        }

        private List<Order> MergeSortList(List<Order> list)
        {
            int n = list.Count;

            if (n <= 1)
            {
                return list;
            }

            List<Order> p1_unsorted = list.Take(n / 2).ToList();
            List<Order> p2_unsorted = list.Skip(n / 2).Take(n - (n / 2)).ToList();

            List<Order> p1_sorted = MergeSortList(p1_unsorted);
            List<Order> p2_sorted = MergeSortList(p2_unsorted);

            return Merge(p1_sorted, p2_sorted);
        }

        private List<Order> Merge(List<Order> p1_sorted, List<Order> p2_sorted)
        {
            List<Order> output = new List<Order>(p1_sorted.Count + p2_sorted.Count);

            int i = 0; 
            int j = 0; 

            while (i < p1_sorted.Count && j < p2_sorted.Count)
            {
                if (p1_sorted[i].placedOn >= p2_sorted[j].placedOn)
                {
                    output.Add(p1_sorted[i]);
                    i++;
                }
                else
                {
                    output.Add(p2_sorted[j]);
                    j++;
                }
            }

            while (i < p1_sorted.Count)
            {
                output.Add(p1_sorted[i]);
                i++;
            }

            while (j < p2_sorted.Count)
            {
                output.Add(p2_sorted[j]);
                j++;
            }

            return output;
        }
    }
}

