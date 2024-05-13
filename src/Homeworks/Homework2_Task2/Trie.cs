namespace Bor
{
    /// <summary>
    /// Represents a trie data structure.
    /// </summary>
    public class Trie
    {
        private readonly Node _head;

        /// <summary>
        /// Initializes a new instance of the Trie class.
        /// </summary>
        public Trie()
        {
            _head = new Node();
        }

        /// <summary>
        /// Gets the number of words in the trie.
        /// </summary>
        public int Size => _head.CountOfWords;

        /// <summary>
        /// Checks if the trie contains the specified element.
        /// </summary>
        public bool Contains(string element)
        {
            if (element == null)
                throw new ArgumentNullException("NULL");

            Node currentNode = _head;
            foreach (char c in element)
            {
                if (!currentNode.Next.ContainsKey(c))
                    return false;

                currentNode = currentNode.Next[c];
            }

            return currentNode.IsTerminal;
        }

        /// <summary>
        /// Adds a new element to the trie.
        /// </summary>
        public bool Add(string element)
        {
            if (element == null)
                throw new ArgumentNullException("Null");

            if (element == string.Empty)
            {
                if (_head.IsTerminal)
                    return false;

                _head.IsTerminal = true;
                return true;
            }

            if (Contains(element))
                return false;

            var currentNode = _head;
            foreach (char c in element)
            {
                currentNode.CountOfWords += 1;

                if (!currentNode.Next.ContainsKey(c))
                    currentNode.Next.Add(c, new Node());

                currentNode = currentNode.Next[c];
            }

            currentNode.CountOfWords += 1;
            currentNode.IsTerminal = true;
            return true;
        }

        /// <summary>
        /// Removes an element from the trie.
        /// </summary>
        public bool Remove(string element)
        {
            if (element == null)
                throw new ArgumentNullException("Null");

            if (element == string.Empty)
            {
                if (!_head.IsTerminal)
                    return false;

                _head.IsTerminal = false;
                return true;
            }

            if (!Contains(element))
                return false;

            var currentNode = _head;
            foreach (char c in element)
            {
                currentNode.CountOfWords -= 1;

                if (currentNode.Next[c].CountOfWords == 1)
                {
                    currentNode.Next.Remove(c);
                    return true;
                }

                currentNode = currentNode.Next[c];
            }

            currentNode.CountOfWords -= 1;
            currentNode.IsTerminal = false;
            return true;
        }

        /// <summary>
        /// Returns the number of elements that start with the specified prefix.
        /// </summary>
        public int HowManyStartsWithPrefix(string prefix)
        {
            if (prefix == null)
                throw new ArgumentNullException("NULL");

            Node currentNode = _head;
            foreach (char c in prefix)
            {
                if (!currentNode.Next.ContainsKey(c))
                    return 0;

                currentNode = currentNode.Next[c];
            }

            return currentNode.CountOfWords;
        }

        private class Node
        {
            public Node()
            {
                Next = new Dictionary<char, Node>();
            }

            public bool IsTerminal { get; set; }
            public int CountOfWords { get; set; }
            public Dictionary<char, Node> Next { get; }
        }
    }
}