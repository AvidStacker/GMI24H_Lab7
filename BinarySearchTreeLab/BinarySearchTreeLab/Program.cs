namespace BinarySearchTreeLab
{
    /// <summary>
    /// Entry point for the console application demonstrating basic BST operations with integers.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method. Runs a menu-driven console app for testing BinarySearchTree<int>.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nBinary Search Tree Menu");
                Console.WriteLine("1. Add Node (Recursive)");
                Console.WriteLine("2. Add Node (Iterative)");
                Console.WriteLine("3. Search Node (Recursive)");
                Console.WriteLine("4. Search Node (Iterative)");
                Console.WriteLine("5. Delete Node (Recursive)");
                Console.WriteLine("6. Delete Node (Iterative)");
                Console.WriteLine("7. In-order Traversal (Recursive)");
                Console.WriteLine("8. In-order Traversal (Iterative)");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter value to add: ");
                        if (int.TryParse(Console.ReadLine(), out int addRec))
                            bst.AddRecursive(addRec);
                        break;

                    case "2":
                        Console.Write("Enter value to add: ");
                        if (int.TryParse(Console.ReadLine(), out int addItr))
                            bst.AddIterative(addItr);
                        break;

                    case "3":
                        Console.Write("Enter value to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchRec))
                            Console.WriteLine(bst.SearchRecursive(searchRec) ? "Value found! (Recursive)" : "Value not found.");
                        break;

                    case "4":
                        Console.Write("Enter value to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchItr))
                            Console.WriteLine(bst.SearchIterative(searchItr) ? "Value found! (Iterative)" : "Value not found.");
                        break;

                    case "5":
                        Console.Write("Enter value to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delRec))
                            bst.DeleteRecursive(delRec);
                        break;

                    case "6":
                        Console.Write("Enter value to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delItr))
                            bst.DeleteIterative(delItr);
                        break;

                    case "7":
                        Console.WriteLine("In-order Traversal (Recursive):");
                        InOrderTraversal(bst.Root);
                        Console.WriteLine();
                        break;

                    case "8":
                        Console.WriteLine("In-order Traversal (Iterative):");
                        InOrderTraversalIterative(bst.Root);
                        Console.WriteLine();
                        break;

                    case "9":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Prints all values in the BST in sorted order using recursive in-order traversal.
        /// </summary>
        /// <typeparam name="T">The type of value stored in the tree nodes.</typeparam>
        /// <param name="node">The starting node (typically the BST root).</param>
        public static void InOrderTraversal<T>(TreeNode<T> node)
        {
            if (node == null)
                return;
            InOrderTraversal(node.Left);
            Console.Write($"{node.Value} ");
            InOrderTraversal(node.Right);
        }

        /// <summary>
        /// Prints all values in the BST in sorted order using iterative in-order traversal with a stack.
        /// </summary>
        /// <typeparam name="T">The type of value stored in the tree nodes.</typeparam>
        /// <param name="root">The starting node (typically the BST root).</param>
        public static void InOrderTraversalIterative<T>(TreeNode<T> root)
        {
            var stack = new Stack<TreeNode<T>>();
            TreeNode<T> current = root;

            while (current != null || stack.Count > 0)
            {
                // Traverse as far left as possible
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                Console.Write($"{current.Value} ");
                current = current.Right;
            }
        }
    }
}