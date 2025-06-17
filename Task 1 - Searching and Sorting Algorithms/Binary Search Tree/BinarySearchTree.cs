using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// A class representing a Binary Search Tree aimed at facilitating the search of orders by order id.
    /// TODO: You are to implement the Build() and Find() methods for this class; additional methods may be added but
    /// any methods added to this class must be declared as private and called within the Build() or Find() method
    /// </summary>
    internal class BinarySearchTree:Order
    {
        //Points to the top node in the tree
        public TreeNode Root { get; private set; }

        /// <summary>
        /// Builds a Binary Search tree based on the list of orders passed as parameter i.e.
        /// It inserts each order in the list into the tree
        /// 
        /// TODO: Implement this methods as described above and in Task 1
        /// 
        /// </summary>
        /// <param name="Orders">List<Order> list of orders to be inserted in the tree</param>
        /// <exception cref="NotImplementedException"></exception> name="orders">List of orders to insert into the tree</param>
        public void Build(List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
                return;

            // Set first order as root
            Root = new TreeNode(orders[0]);

            // Insert remaining orders
            for (int i = 1; i < orders.Count; i++)
            {
                Insert(Root, orders[i]);
            }
        }

        private void Insert(TreeNode node, Order order)
        {
            int comparison = order.ID.CompareTo(node.order.ID);

            if (comparison < 0)
            {
                if (node.Left == null)
                    node.Left = new TreeNode(order);
                else
                    Insert(node.Left, order);
            }
            else if (comparison > 0)
            {
                if (node.Right == null)
                    node.Right = new TreeNode(order);
                else
                    Insert(node.Right, order);
            }
        }

        /// <summary>
        /// Searches for an Order with given id in the tree, if no match is found, null is returned
        /// 
        /// TODO: Implement this methods as described above and in Task 1
        /// 
        /// </summary>
        /// <param name="orderID">Guid id of order to search for</param>
        /// <returns>Order matching id or null</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Order Get(Guid orderID)
        {
            Order foundOrder = Search(Root, orderID);
            if(foundOrder == null)
            {
                throw new Exception($"Order with ID {orderID} does not exist in the tree.");
            }

            return foundOrder;
        }

        private Order Search(TreeNode node, Guid orderID)
        {
            if (node == null)
            {
                return null;
            }

            int comparison = orderID.CompareTo(node.order.ID);

            if (comparison == 0)
            {
                return node.order;
            }
            else if (comparison < 0)
            { 
                return Search(node.Left, orderID);
            }
            else 
            { 
                return Search(node.Right, orderID);
            }
        }
    }
}
