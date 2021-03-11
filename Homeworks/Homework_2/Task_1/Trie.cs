using System;
using System.Collections.Generic;

namespace Task_1
{
    public class Trie
    {
        private class TrieElement
        {
            public int Code { get; set; }
            private Dictionary<byte, TrieElement> childrens;

            public TrieElement()
                => childrens = new Dictionary<byte, TrieElement>();

            public TrieElement GetChild(byte key)
                => childrens[key];

            public void AddElement(byte key, int code)
            {
                childrens.Add(key, new TrieElement());
                childrens[key].Code = code;
            }

            public bool Contains(byte key)
                => childrens.ContainsKey(key);
        }

        private TrieElement root;
        private TrieElement pointer;
        public int CurrentCode { get; set; }

        public Trie()
        {
            root = new TrieElement();
            for (int i = 0; i < 256; ++i)
            {
                root.AddElement((byte)i, i);
            }
            pointer = root;
            CurrentCode = byte.MaxValue;
        }

        public int PointerCode => pointer.Code;

        private void MovePointerToRoot()
            => pointer = root;

        public void MovePointer(byte key)
            => pointer = pointer.GetChild(key);

        public bool PointerContains(byte key)
            => pointer.Contains(key);

        public void Add(byte key)
        {
            ++CurrentCode;
            pointer.AddElement(key, CurrentCode);
            MovePointerToRoot();
            MovePointer(key);
        }
    }
}