using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLab
{
    /// <summary>
    /// Represents a single node in a binary search tree (BST).
    /// </summary>
    /// <typeparam name="T">The type of value stored in the node.</typeparam>
    public class TreeNode<T>
    {
        /// <summary>
        /// Gets or sets the value stored in this node.
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// Gets or sets the left child node.
        /// </summary>
        public TreeNode<T> Left { get; set; }
        /// <summary>
        /// Gets or sets the right child node.
        /// </summary>
        public TreeNode<T> Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the TreeNode class with the specified value.
        /// </summary>
        /// <param name="value">The value to store in this node.</param>
        public TreeNode(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
