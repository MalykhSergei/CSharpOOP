using System;
using System.Collections.Generic;
using System.Text;

namespace TreeTask
{
    class BinaryTree<T>
    {
        private TreeNode<T> root;
        private readonly IComparer<T> comparer;

        public int Count { get; private set; }

        public BinaryTree() : this(Comparer<T>.Default)
        {

        }

        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException("Tree is empty!");
        }

        private int ResultCompare(T data, T data2)
        {
            if (data == null && data2 == null)
            {
                return 0;
            }
            else if (data != null && data2 == null)
            {
                return 1;
            }
            else if (data == null)
            {
                return -1;
            }
            else
            {
                int result;
                if (comparer != null)
                {
                    result = comparer.Compare(data, data2);
                }
                else
                {
                    IComparable<T> comparable = (IComparable<T>)data;
                    result = comparable.CompareTo(data2);
                }
                return result;
            }
        }

        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
                return;
            }

            TreeNode<T> currentNode = root;
            TreeNode<T> parentNode;

            while (currentNode != null)
            {
                parentNode = currentNode;

                if (ResultCompare(data, currentNode.Data) < 0)
                {
                    currentNode = currentNode.Left;

                    if (currentNode == null)
                    {
                        parentNode.Left = new TreeNode<T>(data);
                    }
                }
                else
                {
                    currentNode = currentNode.Right;

                    if (currentNode == null)
                    {
                        parentNode.Right = new TreeNode<T>(data);
                    }
                }
            }
        }

        public bool Contains(T data)
        {
            if (root == null)
            {
                return false;
            }

            TreeNode<T> currentNode = root;

            while (true)
            {
                int result = ResultCompare(data, currentNode.Data);

                if (result < 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (result > 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    break;
                }

                if (currentNode == null)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<T> PassInWidth()
        {
            if (root == null)
            {
                yield break;
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                yield return currentNode.Data;

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }

        public IEnumerable<T> PassInDepthWithoutRecursion()
        {
            if (root == null)
            {
                yield break;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> currentNode = root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode == null)
                {
                    currentNode = stack.Pop();

                    if (stack.Count > 0 && currentNode.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(currentNode);
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        yield return currentNode.Data;
                        currentNode = null;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        stack.Push(currentNode.Right);
                    }

                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
            }
        }

        private static void VisitNode(TreeNode<T> node, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Action is null");
            }

            action(node.Data);

            if (node.Left != null)
            {
                VisitNode(node.Left, action);
            }

            if (node.Right != null)
            {
                VisitNode(node.Right, action);
            }
        }

        public void PassInDepthWithRecursion(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Action is null");
            }

            if (root == null)
            {
                return;
            }

            VisitNode(root, action);
        }

        public bool Remove(T data)
        {
            if (root == null)
            {
                return false;
            }

            TreeNode<T> currentNode = root;
            TreeNode<T> parentNode = null;

            while (true)
            {
                int result = ResultCompare(data, currentNode.Data);

                if (result < 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Left;
                }
                else if (result > 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.Right;
                }
                else
                {
                    break;
                }

                if (currentNode == null)
                {
                    return false;
                }
            }

            if (currentNode.Right == null)
            {
                if (currentNode == root)
                {
                    root = currentNode.Left;
                }
                else
                {
                    if (parentNode != null)
                    {
                        if (ResultCompare(parentNode.Data, currentNode.Data) > 0)
                        {
                            parentNode.Left = currentNode.Left;
                        }
                        else
                        {
                            parentNode.Right = currentNode.Left;
                        }
                    }
                }
            }
            else if (currentNode.Right.Left == null)
            {
                currentNode.Right.Left = currentNode.Left;

                if (currentNode == root)
                {
                    root = currentNode.Right;
                }
                else
                {
                    if (parentNode != null)
                    {
                        if (ResultCompare(parentNode.Data, currentNode.Data) > 0)
                        {
                            parentNode.Left = currentNode.Right;
                        }
                        else
                        {
                            parentNode.Right = currentNode.Right;
                        }
                    }
                }
            }
            else
            {
                TreeNode<T> minNode = currentNode.Right.Left;
                TreeNode<T> previousNode = currentNode.Right;

                while (minNode.Left != null)
                {
                    previousNode = minNode;
                    minNode = minNode.Left;
                }

                previousNode.Left = minNode.Right;

                minNode.Left = currentNode.Left;
                minNode.Right = currentNode.Right;

                if (currentNode == root)
                {
                    root = minNode;
                }
                else
                {
                    if (parentNode != null)
                    {
                        if (ResultCompare(parentNode.Data, currentNode.Data) > 0)
                        {
                            parentNode.Left = minNode;
                        }
                        else
                        {
                            parentNode.Right = minNode;
                        }
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            if (root == null)
            {
                return " ";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in PassInWidth())
            {
                sb.Append(item).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }
    }
}
