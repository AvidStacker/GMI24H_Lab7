using System;
using System.Diagnostics.CodeAnalysis;

namespace BinarySearchTreeLab
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public BinarySearchTree()
        {
        }

        public void AddRecursive(T value)
        {
            if (this.root == null)
            {
                this.root = new TreeNode<T>(value);
                return;
            }
            AddRecursiveHelper(this.root, value);
        }

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
        }

        public bool SearchRecursive(T value)
        {
            if (this.root == null)
            {
                return false;
            }
            return SearchRecursiveHelper(this.root, value);
        }

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

        private TreeNode<T> DeleteRecursiveHelper(TreeNode<T> current, T value)
        {
            int comparison = current.Value.CompareTo(value);

            if (comparison > 0)
            {
                current.Left = DeleteRecursiveHelper(current.Left, value);
            }
            else if (comparison < 0)
            {
                current.Right = DeleteRecursiveHelper(current.Right, value);
            }

            // FIXA !!!!!!!!!!!!!!!
        }

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

        public TreeNode<T> DeleteIterative(T value)
        {

            if (this.root == null)
            {
                throw new Exception(); // FIXA!!!!!!!
            }
            if (SearchIterative(value) == false)
            {
                throw new Exception(); // FIXA!!!!!!
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

            // FIXA!!!!!!!!!!!!!!!!!!!!!!

        }

    }

    internal class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}
