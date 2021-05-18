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
            this.comparer = comparer ?? throw new ArgumentNullException("Comparer is null");
        }

        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
                Count++;

                return;
            }

            TreeNode<T> currentNode = root;

            while (currentNode != null)
            {
                TreeNode<T> parentNode = currentNode;

                if (Compare(data, currentNode.Data) < 0)
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

            Count++;
        }

        private int Compare(T data1, T data2)
        {
            return comparer.Compare(data1, data2);
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
                int result = Compare(data, currentNode.Data);

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
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                yield return currentNode.Data;

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }

        private static void VisitNode(TreeNode<T> node, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "Action is empty");
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
                throw new ArgumentNullException(nameof(action), "Action is empty");
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
                int result = Compare(data, currentNode.Data);

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
                        if (Compare(parentNode.Data, currentNode.Data) > 0)
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
                        if (Compare(parentNode.Data, currentNode.Data) > 0)
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
                        if (Compare(parentNode.Data, currentNode.Data) > 0)
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

            Count--;

            return true;
        }

        public override string ToString()
        {
            if (root == null)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            foreach (T item in PassInWidth())
            {
                if (item == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(item);
                }

                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.Append("]").ToString();
        }
    }
}