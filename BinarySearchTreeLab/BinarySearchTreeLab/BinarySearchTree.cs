using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeLab
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public BinarySearchTree()
        {
        }

        public TreeNode<T> Root => root;

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

                // Case 1: No children
                if (current.Left == null && current.Right == null)
                {
                    return null;
                }

                // Case 2: One child
                if (current.Left == null) return current.Right;
                if (current.Right == null) return current.Left;

                // Case 3: Two children — find in-order successor inline
                TreeNode<T> successor = current.Right;
                while (successor.Left != null)
                {
                    successor = successor.Left;
                }

                current.Value = successor.Value;
                current.Right = DeleteRecursiveHelper(current.Right, successor.Value);
            }

            return current;
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
                throw new InvalidOperationException("Trädet är tomt.");

            TreeNode<T> current = this.root;
            TreeNode<T> parent = null;

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

            // Fall 1 & 2: 0 eller 1 barn
            TreeNode<T> child = current.Left ?? current.Right;

            if (parent == null)
                this.root = child;
            else if (parent.Left == current)
                parent.Left = child;
            else
                parent.Right = child;

            // Fall 3: två barn
            if (current.Left != null && current.Right != null)
            {
                TreeNode<T> succParent = current;
                TreeNode<T> successor = current.Right;
                while (successor.Left != null)
                {
                    succParent = successor;
                    successor = successor.Left;
                }

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
