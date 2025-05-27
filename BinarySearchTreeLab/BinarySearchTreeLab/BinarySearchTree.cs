using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeLab
{
    /// <summary>
    /// Represents a generic binary search tree (BST) data structure.
    /// </summary>
    /// <typeparam name="T">Type of data to store, must implement IComparable.</typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        /// <summary>
        /// Gets the root node of the tree.
        /// </summary>
        public TreeNode<T> Root => root;

        /// <summary>
        /// Initializes a new instance of the BinarySearchTree class.
        /// </summary>
        public BinarySearchTree()
        {
            // No explicit initialization required; root is null by default.
        }

        /// <summary>
        /// Adds a value to the BST using a recursive approach.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void AddRecursive(T value)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(value);
                return;
            }
            AddRecursiveHelper(this.root, value);
        }

        /// <summary>
        /// Helper method for recursively adding a value to the BST.
        /// </summary>
        private void AddRecursiveHelper(TreeNode<T> current, T value)
        {
            int comparison = current.Value.CompareTo(value);

            if (comparison > 0)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(value);
                }
                else
                {
                    AddRecursiveHelper(current.Left, value);
                }
            }
            else if (comparison < 0)
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(value);
                }
                else
                {
                    AddRecursiveHelper(current.Right, value);
                }
            }
            // If value already exists, do nothing (no duplicates)
        }

        /// <summary>
        /// Searches for a value in the BST using a recursive approach.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the value exists, otherwise false.</returns>
        public bool SearchRecursive(T value)
        {
            if (this.root == null)
            {
                return false;
            }
            return SearchRecursiveHelper(this.root, value);
        }

        /// <summary>
        /// Helper method for recursively searching for a value in the BST.
        /// </summary>
        private bool SearchRecursiveHelper(TreeNode<T> current, T value)
        {

            int comparison = current.Value.CompareTo(value);

            if (comparison == 0)
            {
                return true;
            }
            else if (comparison > 0)
            {
                return SearchRecursiveHelper(current.Left, value);
            }
            else
            {
                return SearchRecursiveHelper(current.Right, value);
            }
        }

        /// <summary>
        /// Deletes a value from the BST using a recursive approach.
        /// </summary>
        /// <param name="value">The value to delete.</param>
        /// <returns>The updated root node after deletion.</returns>
        public TreeNode<T> DeleteRecursive(T value)
        {
            if (this.root == null)
            {
                throw new Exception(); // FIXA!!!!!!!
            }
            if (SearchRecursive(value) == false)
            {
                throw new Exception(); // FIXA!!!!!!
            }
            return DeleteRecursiveHelper(this.root, value);
        }

        /// <summary>
        /// Helper method for recursively deleting a value from the BST.
        /// </summary>
        private TreeNode<T> DeleteRecursiveHelper(TreeNode<T> current, T value)
        {
            if (current == null) return null;

            int comparison = value.CompareTo(current.Value);

            if (comparison < 0)
            {
                current.Left = DeleteRecursiveHelper(current.Left, value);
            }
            else if (comparison > 0)
            {
                current.Right = DeleteRecursiveHelper(current.Right, value);
            }
            else
            {

                // Node to be deleted found

                // Case 1: No children
                if (current.Left == null && current.Right == null)
                {
                    return null;
                }

                // Case 2: One child
                if (current.Left == null) return current.Right;
                if (current.Right == null) return current.Left;

                // Case 3: Two children — find in-order successor
                TreeNode<T> successor = current.Right;
                while (successor.Left != null)
                {
                    successor = successor.Left;
                }

                // Copy successor's value to current node and delete successor
                current.Value = successor.Value;
                current.Right = DeleteRecursiveHelper(current.Right, successor.Value);
            }

            return current;
        }

        /// <summary>
        /// Adds a value to the BST using an iterative approach.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void AddIterative(T value)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(value);
                return;
            }

            TreeNode<T> current = this.root;
            TreeNode<T> parent = null;

            while (current != null)
            {
                parent = current;
                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            if (parent.Value.CompareTo(value) > 0)
            {
                parent.Left = new TreeNode<T>(value);
            }
            else
            {
                parent.Right = new TreeNode<T>(value);
            }
        }

        /// <summary>
        /// Searches for a value in the BST using an iterative approach.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the value exists, otherwise false.</returns>
        public bool SearchIterative(T value)
        {
            TreeNode<T> current = this.root;

            while (current != null)
            {
                int comparison = current.Value.CompareTo(value);
                if (comparison == 0)
                {
                    return true;
                }
                else if (comparison > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return false;
        }

        /// <summary>
        /// Deletes a value from the BST using an iterative approach.
        /// </summary>
        /// <param name="value">The value to delete.</param>
        /// <returns>The deleted node (if needed), otherwise throws exception if value does not exist.</returns>
        public TreeNode<T> DeleteIterative(T value)
        {
            if (this.root == null)
                throw new InvalidOperationException("Trädet är tomt.");

            TreeNode<T> current = this.root;
            TreeNode<T> parent = null;

            // Find node to delete
            while (current != null && current.Value.CompareTo(value) != 0)
            {
                parent = current;
                if (value.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            if (current == null)
                throw new InvalidOperationException("Värdet finns inte i trädet.");

            // Case 1 & 2: Node has at most one child
            TreeNode<T> child = current.Left ?? current.Right;

            if (parent == null)
                this.root = child;
            else if (parent.Left == current)
                parent.Left = child;
            else
                parent.Right = child;

            // Case 3: Node has two children
            if (current.Left != null && current.Right != null)
            {
                TreeNode<T> succParent = current;
                TreeNode<T> successor = current.Right;
                while (successor.Left != null)
                {
                    succParent = successor;
                    successor = successor.Left;
                }

                // Copy successor's value to current node and delete successor
                current.Value = successor.Value;

                if (succParent.Left == successor)
                    succParent.Left = successor.Right;
                else
                    succParent.Right = successor.Right;
            }

            return current;
        }
    }
}
