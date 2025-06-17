using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on based on Order ID (ascending order) 
    /// using Quick Sort where the pivot is the left-most element
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> sortedList = new List<Order>(unsortedOrderList);

            QuickSortList(sortedList, 0, sortedList.Count - 1);

            return sortedList;
        }

        private void QuickSortList(List<Order> list, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            int pivotIndex = SelectPivotAndPartition(list, lo, hi);

            QuickSortList(list, lo, pivotIndex - 1);
            QuickSortList(list, pivotIndex + 1, hi);
        }

        private int SelectPivotAndPartition(List<Order> list, int lo, int hi)
        {
            int pivotIndex = lo; 
            Order pivotValue = list[pivotIndex];

            List<Order> smallerOrEqualValues = new List<Order>();
            List<Order> largerValues = new List<Order>();

            for (int i = lo; i <= hi; i++)
            {
                if (i == pivotIndex)
                {
                    continue;
                }

                if (list[i].ID.CompareTo(pivotValue.ID) > 0)
                {
                    largerValues.Add(list[i]);
                }
                else
                {
                    smallerOrEqualValues.Add(list[i]);
                }
            }

            for (int i = 0; i < smallerOrEqualValues.Count; i++)
            {
                list[lo + i] = smallerOrEqualValues[i];
            }

            int finalPivotIndex = lo + smallerOrEqualValues.Count;
            list[finalPivotIndex] = pivotValue;

            for (int i = 0; i < largerValues.Count; i++)
            {
                list[finalPivotIndex + 1 + i] = largerValues[i];
            }

            return finalPivotIndex;
        }
    }
}
