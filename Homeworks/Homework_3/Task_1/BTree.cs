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

            public int GetIndexOfKey(string key)
            {
                for (int i = 0; i < Count; ++i)
                {
                    if (Data[i].key == key)
                    {
                        return i;
                    }
                }

                return -1;
            }

            public bool Contains(string key)
            {
                for (int i = 0; i < Count; ++i)
                {
                    if (Data[i].key == key)
                    {
                        return true;
                    }
                }

                return false;
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

            public void ChangeValue(int index, string value)
                => Data[index].value = value;

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

            public (Node, Node, string, string) SplitNode(int degree, bool shift)
            {
                Node leftNode = new Node(degree);
                Node rightNode = new Node(degree);

                int middleIndex = shift ? degree : degree - 1;

                for (int i = 0; i < middleIndex; ++i)
                {
                    leftNode.Data[i] = Data[i];
                    leftNode.Childrens[i] = Childrens[i];
                    if (i == middleIndex - 1)
                    {
                        leftNode.Childrens[i + 1] = Childrens[i + 1];
                    }
                }
                for (int i = middleIndex + 1; i < Count; ++i)
                {
                    rightNode.Data[i - middleIndex - 1] = Data[i];
                    rightNode.Childrens[i - middleIndex - 1] = Childrens[i];
                    if (i == Count - 1)
                    {
                        rightNode.Childrens[i - middleIndex] = Childrens[i + 1];
                    }
                }

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
                rightNode.IsLeaf = IsLeaf;

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

            public Node FindNodeToInserst(string key)
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
                return Childrens[Count + 1];
            }
        }

        public void Insert(string key, string value)
        {
            if (root == null)
            {
                root = new Node(degree);
                root.IsLeaf = true;
            }

            if (root.IsLeaf)
            {
                bool shiftInRoot = String.Compare(root.Data[(root.Count) / 2].key, key) > 0;
                root.AddData(key, value);
                if (root.Count > 2 * degree - 1)
                {
                    (Node leftNode, Node rightNode, string newKey, string newValue) = root.SplitNode(degree, shiftInRoot);
                    Node newRoot = new Node(degree);
                    newRoot.AddData(newKey, newValue);
                    newRoot.Childrens[0] = leftNode;
                    newRoot.Childrens[1] = rightNode;
                    newRoot.IsLeaf = false;
                    root = newRoot;
                }
                return;
            }

            int index = root.FindIndexToInsertion(key);
            bool shift = String.Compare(root.Data[(root.Count) / 2].key, root.Childrens[index].Data[(root.Childrens[index].Count) / 2].key) > 0;
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
            }
        }
        
    }
}
