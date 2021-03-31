using System;

namespace Task_1
{
    class BTree
    {
        public int degree;

        private Node root;

        public BTree(int treeDegree)
        {
            degree = treeDegree;
            root = null;
        }

        private class Node
        {
            public (string key, string value)[] Data { get; set;  }

            public Node[] Childrens { get; set; }

            public Node Parent { get; set; }

            public bool IsLeaf { get; set; }

            public int Count { get; set; }

            public Node(int degree)
            {
                Data = new (string, string)[2 * degree];
                Childrens = new Node[2 * degree + 1];
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
                    Childrens[i + 1] = Childrens[i];
                }
                Data[position] = (key, value);
                Childrens[position + 1] = null;
                ++Count;
                return position;
            }

            public void CopyNode(Node newNode, int beginIndex, int endIndex)
            {
                for (int i = beginIndex; i < endIndex; ++i)
                {
                    int currentIndex = newNode.Count;
                    newNode.Data[currentIndex] = Data[i];
                    newNode.Childrens[currentIndex] = Childrens[i];
                    if (newNode.Childrens[currentIndex] != null)
                    {
                        newNode.Childrens[currentIndex].Parent = newNode;
                    }
                    if (i == endIndex - 1)
                    {
                        newNode.Childrens[currentIndex + 1] = Childrens[i + 1];
                        if (newNode.Childrens[currentIndex + 1] != null)
                        {
                            newNode.Childrens[currentIndex + 1].Parent = newNode;
                        }
                    }
                    ++newNode.Count;
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

                int ChildCount = Childrens[position].Count;
                bool shift = Childrens[position].IsLeaf ? String.Compare(Childrens[position].Data[(ChildCount) / 2].key, key) > 0 :
                    String.Compare(Data[(Count + 1) / 2].key, Childrens[position].Data[(ChildCount) / 2].key) > 0;
                Childrens[position].Insert(key, value, degree);
                if (Childrens[position].Count > 2 * degree - 1)
                {
                    (Node leftNode, Node rightNode, string newKey, string newValue) = Childrens[position].SplitNode(degree, shift);
                    int newPosition = AddData(newKey, newValue);
                    Childrens[newPosition] = leftNode;
                    Childrens[newPosition + 1] = rightNode;
                }
            }

            public void DeleteDataByKeyFromLeaf(string key)
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
                    Childrens[i] = Childrens[i + 1];
                }
                Childrens[Count - 1] = Childrens[Count];
                Data[Count - 1].key = null;
                Data[Count - 1].value = null;
                Childrens[Count] = null;
                --Count;
            }

            public void Rotation(Node parent, Node sibling, int position, bool type)
            {
                int siblingIndex = type ? sibling.Count - 1 : 0;
                AddData(parent.Data[position].key, parent.Data[position].value);
                parent.Data[position] = sibling.Data[siblingIndex];
                DeleteDataByKeyFromLeaf(sibling.Data[siblingIndex].key);
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
                        return Childrens[i];
                    }
                }
                return Childrens[Count];
            }
        }

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
                shift = String.Compare(root.Data[root.Count / 2].key, root.Childrens[index].Data[root.Childrens[index].Count / 2].key) > 0;
            }

            root.Insert(key, value, degree);
            if (root.Count > 2 * degree - 1)
            {
                (Node leftNode, Node rightNode, string newKey, string newValue) = root.SplitNode(degree, shift);
                Node newRoot = new Node(degree);
                newRoot.AddData(newKey, newValue);
                newRoot.Childrens[0] = leftNode;
                newRoot.Childrens[1] = rightNode;
                newRoot.IsLeaf = false;
                root = newRoot;
                root.Childrens[0].Parent = root;
                root.Childrens[1].Parent = root;
            }
        }

        private Node MergeNodes(Node firstNode, Node secondNode, Node parent, int position)
        {
            Node mergedNode = new Node(degree);
            firstNode.CopyNode(mergedNode, 0, firstNode.Count);
            mergedNode.Data[mergedNode.Count] = parent.Data[position];
            ++mergedNode.Count;
            secondNode.CopyNode(mergedNode, 0, secondNode.Count);
            return mergedNode;
        }

        private (Node, int) GetNodeAndKey(string key)
        {
            Node node = root.FindNode(key);
            int index = node.GetIndex(key);
            return index == -1 ? (null, -1) : (node, index);
        }

        private void Rebalance(Node node)
        {
            if (node.Count >= degree - 1 || node == root)
            {
                return;
            }

            Node parent = node.Parent;
            Node leftSibling = null;
            Node rightSibling = null;
            int position = 0;
            for (int i = 0; i < parent.Count + 1; ++i)
            {
                if (parent.Childrens[i] == node)
                {
                    position = i;
                    if (i > 0 && i < parent.Count)
                    {
                        leftSibling = parent.Childrens[i - 1];
                        rightSibling = parent.Childrens[i + 1];
                    }
                    if (i == 0)
                    {
                        rightSibling = parent.Childrens[i + 1];
                    }
                    if (i == parent.Count)
                    {
                        leftSibling = parent.Childrens[i - 1];
                    }
                    break;
                }
            }

            if (leftSibling != null && leftSibling.Count > degree - 1)
            {
                node.AddData(parent.Data[position - 1].key, parent.Data[position - 1].value);
                parent.Data[position - 1] = leftSibling.Data[leftSibling.Count - 1];
                node.Childrens[0] = leftSibling.Childrens[leftSibling.Count];
                if (node.Childrens[0] != null)
                {
                    node.Childrens[0].Parent = node;
                }
                leftSibling.DeleteDataByKeyFromLeaf(leftSibling.Data[leftSibling.Count - 1].key);
                return;
            }

            if (rightSibling != null && rightSibling.Count > degree - 1)
            {
                node.AddData(parent.Data[position].key, parent.Data[position].value);
                parent.Data[position] = rightSibling.Data[0];
                node.Childrens[node.Count] = rightSibling.Childrens[0];
                if (node.Childrens[node.Count] != null)
                {
                    node.Childrens[node.Count].Parent = node;
                }
                rightSibling.DeleteDataByKeyFromLeaf(rightSibling.Data[0].key);
                return;
            }

            Node newNode = leftSibling != null ? MergeNodes(leftSibling, node, parent, position - 1) : MergeNodes(node, rightSibling, parent, position);
            int index = leftSibling != null ? position : position + 1;
            parent.Childrens[index] = newNode;
            parent.DeleteDataByKeyFromLeaf(parent.Data[index - 1].key);
            
            if (parent.Count == 0 && parent == root)
            {
                root = null;
                root = newNode;
                if (root.Childrens[0] != null)
                {
                    root.IsLeaf = false;
                }
                return;
            }

            newNode.Parent = parent;
            Rebalance(parent);
        }

        private Node GetMostRightNodeOfSubtree(Node node)
        {
            if (node.IsLeaf)
            {
                return node;
            }
            return node.Childrens[node.Count];
        }

        private Node GetMostLeftNodeOfSubtree(Node node)
        {
            if (node.IsLeaf)
            {
                return node;
            }
            return node.Childrens[0];
        }

        public void Delete(string key)
        {
            (Node node, int keyIndex) = GetNodeAndKey(key);
            if (keyIndex == -1)
            {
                return;
            }

            if (node.IsLeaf)
            {
                node.DeleteDataByKeyFromLeaf(key);
                Rebalance(node);
                return;
            }

            Node mostRightNode = GetMostRightNodeOfSubtree(node.Childrens[keyIndex]);
            node.Data[keyIndex] = mostRightNode.Data[mostRightNode.Count - 1];
            mostRightNode.Data[mostRightNode.Count - 1] = (null, null);
            --mostRightNode.Count;
            Rebalance(mostRightNode);
        }
    }
}