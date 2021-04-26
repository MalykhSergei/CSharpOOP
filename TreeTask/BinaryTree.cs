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

        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException("Comparer is null");
        }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Element value is null");
            }

            if (root == null)
            {
                root = new TreeNode<T>(data);
                Count++;

                return;
            }

            TreeNode<T> currentNode = root;

            while (true)
            {
                if (comparer.Compare(currentNode.Data, data) < 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        currentNode.Left = new TreeNode<T>(data);
                        Count++;

                        return;
                    }
                }

                if (currentNode.Right != null)
                {
                    currentNode = currentNode.Right;
                    continue;
                }
                else
                {
                    currentNode.Right = new TreeNode<T>(data);
                    Count++;

                    return;
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

            int comparerResult = comparer.Compare(currentNode.Data, data);

            if (comparerResult == 0)
            {
                return true;
            }

            while (comparerResult != 0)
            {
                if (comparerResult < 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
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

            while (queue.Count != 0)
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

            while (stack.Count != 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                yield return currentNode.Data;

                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
            }
        }

        private void VisitNode(TreeNode<T> node, Action<T> action)
        {
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
            if (Count == 0)
            {
                return;
            }

            VisitNode(root, action);
        }

        public bool Remove(T value)
        {
            if (!Contains(value))
            {
                return false;
            }

            TreeNode<T> currentNode = root;
            TreeNode<T> parentNode = new TreeNode<T>();
            bool rightTransfer = false;
            int compareResult = comparer.Compare(currentNode.Data, value);

            while (currentNode.Data != null)
            {
                if (compareResult == 0)
                {
                    if (currentNode == root)
                    {
                        TreeNode<T> rootOfRightSubTree = currentNode.Right;
                        TreeNode<T> roorOfLeftSubTree = currentNode.Left;

                        currentNode = currentNode.Right;

                        while (currentNode.Left != null)
                        {
                            parentNode = currentNode;
                            currentNode = currentNode.Left;
                        }

                        parentNode.Left = null;
                        root = currentNode;
                        currentNode.Right = rootOfRightSubTree;
                        currentNode.Left = roorOfLeftSubTree;
                    }
                    else if (currentNode.Left == null && currentNode.Right == null)
                    {
                        if (rightTransfer)
                        {
                            parentNode.Right = null;
                        }
                        else
                        {
                            parentNode.Left = null;
                        }
                    }
                    else if (currentNode.Left == null || currentNode.Right == null)
                    {
                        if (rightTransfer)
                        {
                            parentNode.Right = currentNode.Right ?? currentNode.Left;
                        }
                        else
                        {
                            parentNode.Left = currentNode.Right ?? currentNode.Left;
                        }
                    }
                    else
                    {
                        TreeNode<T> subtreeParent = parentNode;
                        TreeNode<T> rightSubtreeRoot = currentNode.Right;
                        TreeNode<T> leftSubtreeRoot = currentNode.Left;

                        currentNode = currentNode.Right;

                        while (currentNode.Left != null)
                        {
                            parentNode = currentNode;
                            currentNode = currentNode.Left;
                        }

                        parentNode.Left = null;

                        if (rightTransfer)
                        {
                            subtreeParent.Right = currentNode;
                        }
                        else
                        {
                            subtreeParent.Left = currentNode;
                        }

                        currentNode.Right = rightSubtreeRoot;
                        currentNode.Left = leftSubtreeRoot;
                    }

                    break;
                }

                if (compareResult < 0)
                {
                    if (currentNode.Left != null)
                    {
                        parentNode = currentNode;
                        rightTransfer = false;
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        parentNode = currentNode;
                        rightTransfer = true;
                        currentNode = currentNode.Right;
                    }
                }
            }

            Count--;

            return true;
        }

        public override string ToString()
        {
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
