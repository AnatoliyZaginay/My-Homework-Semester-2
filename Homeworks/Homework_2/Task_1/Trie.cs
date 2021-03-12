using System;
using System.Collections.Generic;

namespace Task_1
{
    /// <summary>
    /// Tree containing byte sequence codes.
    /// </summary>
    public class Trie
    {
        /// <summary>
        /// Element of trie containing code and dictionary of childrens.
        /// </summary>
        private class TrieElement
        {
            public int Code { get; set; }
            private Dictionary<byte, TrieElement> childrens;

            /// <summary>
            /// Creates a new trie element.
            /// </summary>
            /// <param name="code">Code of new element.</param>
            public TrieElement(int code)
            {
                childrens = new Dictionary<byte, TrieElement>();
                Code = code;
            }

            /// <summary>
            /// Creates a new trie element.
            /// </summary>
            public TrieElement()
                : this(0)
            {
            }

            /// <summary>
            /// Returns child of the element by byte key.
            /// </summary>
            /// <param name="key">Child byte key.</param>
            public TrieElement GetChild(byte key)
                => childrens[key];

            /// <summary>
            /// Adds a new child to the element.
            /// </summary>
            /// <param name="key">Child byte key.</param>
            /// <param name="code">Child code.</param>
            public void AddElement(byte key, int code)
                => childrens.Add(key, new TrieElement(code));

            /// <summary>
            /// Returns true if the element has a child with specified key, otherwise returns false.
            /// </summary>
            /// <param name="key">Child byte key.</param>
            public bool Contains(byte key)
                => childrens.ContainsKey(key);
        }

        private TrieElement root;
        private TrieElement pointer;

        /// <summary>
        /// Current max code in trie.
        /// </summary>
        public int CurrentCode { get; set; }

        /// <summary>
        /// Сode of the element that the pointer points to.
        /// </summary>
        public int PointerCode => pointer.Code;

        /// <summary>
        /// Creates a new trie.
        /// </summary>
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

        /// <summary>
        /// Moves pointer to the root of the trie.
        /// </summary>
        private void MovePointerToRoot()
            => pointer = root;

        /// <summary>
        /// Moves pointer to the child with specified key. 
        /// </summary>
        /// <param name="key">Child byte key.</param>
        public void MovePointer(byte key)
            => pointer = pointer.GetChild(key);

        /// <summary>
        /// Returns true if pointer has a child with specified key, otherwise returns false.
        /// </summary>
        /// <param name="key">Child byte key.</param>
        public bool PointerContains(byte key)
            => pointer.Contains(key);

        /// <summary>
        /// Adds new element in the trie as a child of the pointer by specified key. Then moves pointer to the first element in trie with that key.
        /// </summary>
        /// <param name="key">Child byte key.</param>
        public void Add(byte key)
        {
            ++CurrentCode;
            pointer.AddElement(key, CurrentCode);
            MovePointerToRoot();
            MovePointer(key);
        }
    }
}