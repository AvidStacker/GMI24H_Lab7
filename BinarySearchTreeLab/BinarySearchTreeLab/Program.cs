namespace BinarySearchTreeLab
{
    internal class Program
    {
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
                            Console.WriteLine(bst.SearchRecursive(searchRec) ? "Found!" : "Not found.");
                        break;

                    case "4":
                        Console.Write("Enter value to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchItr))
                            Console.WriteLine(bst.SearchIterative(searchItr) ? "Found!" : "Not found.");
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

        public static void InOrderTraversal(TreeNode node)
        {
            if (node == null)
                return;
            InOrderTraversal(node.Left);
            Console.Write($"{node.Value} ");
            InOrderTraversal(node.Right);
        }

        public static void InOrderTraversalIterative(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (current != null || stack.Count > 0)
            {
                // Gå så långt vänster som möjligt
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