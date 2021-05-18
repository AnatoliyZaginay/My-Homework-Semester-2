using System;

namespace Task_1
{
    /// <summary>
    /// A tree containing from t - 1 to 2t - 1 elements in a node, where t is the degree of the tree.
    /// </summary>
    public class BTree
    {
        /// <summary>
        /// Degree of the b-tree.
        /// </summary>
        private int degree;

        /// <summary>
        /// Pointer to the root of the b-tree.
        /// </summary>
        private Node root;

        /// <summary>
        /// Creates a new b-tree with the specified degree.
        /// </summary>
        /// <param name="treeDegree">Degree of the b-tree</param>
        public BTree(int treeDegree)
        {
            if (treeDegree < 2)
            {
                throw new ArgumentException("Invalid degree value");
            }
            degree = treeDegree;
            root = null;
        }

        private class Node
        {
            public (string key, string value)[] Data { get; set;  }

            public Node[] Children { get; set; }

            public Node Parent { get; set; }

            public bool IsLeaf { get; set; }

            public int Count { get; set; }

            public Node(int degree)
            {
                Data = new (string, string)[2 * degree];
                Children = new Node[2 * degree + 1];
                Count = 0;
                IsLeaf = true;
            }

            public int GetIndex(string key)
            {
                for (int i = 0; i < Count; ++i)
                {
                    if (key == Data[i].key)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public int FindIndexToInsertion(string key)
            {
                for (int i = 0; i < Count; ++i)
                {
                    if (String.Compare(Data[i].key, key) > 0)
                    {
                        return i;
                    }
                }

                return Count;
            }

            public int AddData(string key, string value)
            {
                int position = 0;

                for (int i = 0; i < Count; ++i)
                {
                    if (key == Data[i].key)
                    {
                        Data[i].value = value;
                        return i;
                    }
                    position = i + 1;
                    if (String.Compare(Data[i].key, key) > 0)
                    {
                        position = i;
                        break;
                    }
                }

                for (int i = Count; i > position; --i)
                {
                    Data[i] = Data[i - 1];
                    Children[i + 1] = Children[i];
                }
                Data[position] = (key, value);
                Children[position + 1] = null;
                ++Count;
                return position;
            }

            public void CopyNode(Node newNode, int beginIndex, int endIndex)
            {
                for (int i = beginIndex; i < endIndex; ++i)
                {
                    int currentIndex = newNode.Count;
                    newNode.Data[currentIndex] = Data[i];
                    newNode.Children[currentIndex] = Children[i];
                    if (newNode.Children[currentIndex] != null)
                    {
                        newNode.Children[currentIndex].Parent = newNode;
                    }
                    ++newNode.Count;
                }

                newNode.Children[newNode.Count] = Children[endIndex];
                if (newNode.Children[newNode.Count] != null)
                {
                    newNode.Children[newNode.Count].Parent = newNode;
                }
            }

            public (Node, Node, string, string) SplitNode(int degree, bool shift)
            {
                Node leftNode = new Node(degree);
                Node rightNode = new Node(degree);

                int middleIndex = shift ? degree : degree - 1;

                CopyNode(leftNode, 0, middleIndex);
                CopyNode(rightNode, middleIndex + 1, Count);

                if (shift)
                {
                    leftNode.Count = degree;
                    rightNode.Count = degree - 1;
                }
                else
                {
                    leftNode.Count = degree - 1;
                    rightNode.Count = degree;
                }

                leftNode.IsLeaf = IsLeaf;
                leftNode.Parent = Parent;
                rightNode.IsLeaf = IsLeaf;
                rightNode.Parent = Parent;

                return (leftNode, rightNode, Data[middleIndex].key, Data[middleIndex].value);
            }

            public void Insert(string key, string value, int degree)
            {
                if (IsLeaf)
                {
                    AddData(key, value);
                    return;
                }

                int position = 0;

                for (int i = 0; i < Count; ++i)
                {
                    if (String.Compare(Data[i].key, key) == 0)
                    {
                        Data[i].value = value;
                        return;
                    }
                    if (String.Compare(Data[i].key, key) > 0)
                    {
                        position = i;
                        break;
                    }
                    if (i == Count - 1)
                    {
                        position = Count;
                    }
                }

                int childCount = Children[position].Count;
                bool shift = Children[position].IsLeaf ? String.Compare(Children[position].Data[(childCount) / 2].key, key) > 0 :
                    String.Compare(Data[(Count + 1) / 2].key, Children[position].Data[childCount / 2].key) > 0;
                Children[position].Insert(key, value, degree);
                if (Children[position].Count > 2 * degree - 1)
                {
                    (Node leftNode, Node rightNode, string newKey, string newValue) = Children[position].SplitNode(degree, shift);
                    int newPosition = AddData(newKey, newValue);
                    Children[newPosition] = leftNode;
                    Children[newPosition + 1] = rightNode;
                }
            }

            public void DeleteChildByKey(string key)
            {
                int position = -1;
                for (int i = 0; i < Count; ++i)
                {
                    if (Data[i].key == key)
                    {
                        position = i;
                        break;
                    }
                }
                if (position == -1)
                {
                    return;
                }
                for (int i = position; i < Count - 1; ++i)
                {
                    Data[i] = Data[i + 1];
                    Children[i] = Children[i + 1];
                }
                Children[Count - 1] = Children[Count];
                Data[Count - 1].key = null;
                Data[Count - 1].value = null;
                Children[Count] = null;
                --Count;
            }

            public Node FindNode(string key)
            {
                if (IsLeaf)
                {
                    return this;
                }
                for (int i = 0; i < Count; ++i)
                {
                    if (String.Compare(Data[i].key, key) == 0)
                    {
                        return this;
                    }
                    if (String.Compare(Data[i].key, key) > 0)
                    {
                        return Children[i].FindNode(key);
                    }
                }
                return Children[Count].FindNode(key);
            }
        }

        /// <summary>
        /// Inserts a key-value pair to the tree.
        /// </summary>
        public void Insert(string key, string value)
        {
            if (root == null)
            {
                root = new Node(degree);
                root.IsLeaf = true;
            }

            bool shift;
            if (root.IsLeaf)
            {
                shift = String.Compare(root.Data[root.Count / 2].key, key) > 0;
            }
            else
            {
                int index = root.FindIndexToInsertion(key);
                shift = String.Compare(root.Data[root.Count / 2].key, root.Children[index].Data[root.Children[index].Count / 2].key) > 0;
            }

            root.Insert(key, value, degree);
            if (root.Count > 2 * degree - 1)
            {
                (Node leftNode, Node rightNode, string newKey, string newValue) = root.SplitNode(degree, shift);
                Node newRoot = new Node(degree);
                newRoot.AddData(newKey, newValue);
                newRoot.Children[0] = leftNode;
                newRoot.Children[1] = rightNode;
                newRoot.IsLeaf = false;
                root = newRoot;
                root.Children[0].Parent = root;
                root.Children[1].Parent = root;
            }
        }

        private Node MergeNodes(Node firstNode, Node secondNode, Node parent, int position)
        {
            var mergedNode = new Node(degree);
            firstNode.CopyNode(mergedNode, 0, firstNode.Count);
            mergedNode.Data[mergedNode.Count] = parent.Data[position];
            ++mergedNode.Count;
            secondNode.CopyNode(mergedNode, 0, secondNode.Count);
            mergedNode.IsLeaf = mergedNode.Children[0] == null;
            return mergedNode;
        }

        private (Node, int) GetNodeAndKey(string key)
        {
            Node node = root.FindNode(key);
            int index = node.GetIndex(key);
            return index == -1 ? (null, -1) : (node, index);
        }

        private void RightRotation(Node node, Node parent, Node sibling, int position)
        {
            for (int i = node.Count - 1; i >= 0; --i)
            {
                node.Data[i + 1] = node.Data[i];
                node.Children[i + 2] = node.Children[i + 1];
            }
            node.Children[1] = node.Children[0];
            node.Data[0] = parent.Data[position];
            ++node.Count;
            parent.Data[position] = sibling.Data[sibling.Count - 1];
            node.Children[0] = sibling.Children[sibling.Count];
            if (node.Children[0] != null)
            {
                node.Children[0].Parent = node;
            }
            sibling.Children[sibling.Count] = null;
            sibling.Data[sibling.Count - 1] = (null, null);
            --sibling.Count;
        }

        private void LeftRotation(Node node, Node parent, Node sibling, int position)
        {
            node.Data[node.Count] = parent.Data[position];
            ++node.Count;
            parent.Data[position] = sibling.Data[0];
            node.Children[node.Count] = sibling.Children[0];
            if (node.Children[node.Count] != null)
            {
                node.Children[node.Count].Parent = node;
            }
            for (int i = 0; i < sibling.Count - 1; ++i)
            {
                sibling.Data[i] = sibling.Data[i + 1];
                sibling.Children[i] = sibling.Children[i + 1];
            }
            sibling.Children[sibling.Count - 1] = sibling.Children[sibling.Count];
            sibling.Children[sibling.Count] = null;
            sibling.Data[sibling.Count - 1] = (null, null);
            --sibling.Count;
        }

        private (Node, Node) GetSiblings(Node node, Node parent, out int position)
        {
            Node leftSibling = null;
            Node rightSibling = null;
            position = 0;
            for (int i = 0; i < parent.Count + 1; ++i)
            {
                if (parent.Children[i] == node)
                {
                    position = i;
                    if (i > 0 && i < parent.Count)
                    {
                        leftSibling = parent.Children[i - 1];
                        rightSibling = parent.Children[i + 1];
                    }
                    if (i == 0)
                    {
                        rightSibling = parent.Children[i + 1];
                    }
                    if (i == parent.Count)
                    {
                        leftSibling = parent.Children[i - 1];
                    }
                    break;
                }
            }
            return (leftSibling, rightSibling);
        }

        private void Rebalance(Node node)
        {
            if (node.Count >= degree - 1 || node == root)
            {
                return;
            }

            Node parent = node.Parent;
            (Node leftSibling, Node rightSibling) = GetSiblings(node, parent, out int position);

            if (leftSibling != null && leftSibling.Count > degree - 1)
            {
                RightRotation(node, parent, leftSibling, position - 1);
                return;
            }

            if (rightSibling != null && rightSibling.Count > degree - 1)
            {
                LeftRotation(node, parent, rightSibling, position);
                return;
            }

            Node newNode = leftSibling != null ? MergeNodes(leftSibling, node, parent, position - 1) : MergeNodes(node, rightSibling, parent, position);
            int index = leftSibling != null ? position : position + 1;
            parent.Children[index] = newNode;
            parent.DeleteChildByKey(parent.Data[index - 1].key);
            
            if (parent.Count == 0 && parent == root)
            {
                root = null;
                root = newNode;
                if (root.Children[0] != null)
                {
                    root.IsLeaf = false;
                }
                return;
            }

            newNode.Parent = parent;
            Rebalance(parent);
        }

        private Node GetMostRightNodeOfSubtree(Node node)
            => node.IsLeaf ? node : GetMostRightNodeOfSubtree(node.Children[node.Count]);

        /// <summary>
        /// Removes a key-value pair from the tree by key.
        /// </summary>
        public void Delete(string key)
        {
            if (root.Count == 0)
            {
                throw new InvalidOperationException("The tree is empty");
            }
            (Node node, int keyIndex) = GetNodeAndKey(key);
            if (keyIndex == -1)
            {
                throw new ArgumentException("The key isn't contained in the tree");
            }

            if (node.IsLeaf)
            {
                node.DeleteChildByKey(key);
                Rebalance(node);
                return;
            }

            Node mostRightNode = GetMostRightNodeOfSubtree(node.Children[keyIndex]);
            node.Data[keyIndex] = mostRightNode.Data[mostRightNode.Count - 1];
            mostRightNode.Data[mostRightNode.Count - 1] = (null, null);
            --mostRightNode.Count;
            Rebalance(mostRightNode);
        }

        /// <summary>
        /// Returns true if the key is contained in the tree, otherwise returns false.
        /// </summary>
        public bool Contains(string key)
        {
            Node node = root.FindNode(key);
            return node.GetIndex(key) != -1;
        }

        /// <summary>
        /// Returns the value by key.
        /// </summary>
        public string GetValue(string key)
        {
            Node node = root.FindNode(key);
            int index = node.GetIndex(key);
            if (index == -1)
            {
                throw new ArgumentException("The key isn't contained in the tree");
            }
            return node.Data[index].value;
        }

        /// <summary>
        /// Changes the value by key.
        /// </summary>
        public void ChangeValue(string key, string value)
        {
            Node node = root.FindNode(key);
            int index = node.GetIndex(key);
            if (index == -1)
            {
                throw new ArgumentException("The key isn't contained in the tree");
            }
            node.Data[index].value = value;
        }
    }
}