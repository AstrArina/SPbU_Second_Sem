namespace Trees;
public class Trie {
    private readonly Node head;
    public Trie() {
        head = new Node();
    }
    public int Size => head.CountOfWords;
    public bool Contains(string element) {
        if (element == null) {
            throw new ArgumentNullException("NULL");
        }
        Node currentnode = head;
        foreach (var sign in element) {
            if (!currentnode.Next.ContainsKey(sign)) {
                return false;
            }
            currentnode = currentnode.Next[sign]; 
        }
        return currentnode.Terminal;
    }
    public bool Add(string element) {
        if (element == null) {
            throw new ArgumentNullException("Null");
        }
        if (element == string.Empty) {
            return head.Terminal 
            ? false
            : head.Terminal = true;
        }
        if (Contains(element)) {
            return false;
        }
        var currentnode = head;
        foreach (var sign in element) {
            currentnode.CountOfWords += 1;
            if (!currentnode.Next.ContainsKey(sign)) {
                currentnode.Next.Add(sign, new Node());
            }
            currentnode = currentnode.Next[sign];
        }
        currentnode.CountOfWords += 1;
        currentnode.Terminal = true;
        return currentnode.Terminal;
    }
    public bool Remove(string element) {
        if (element == null) {
            throw new ArgumentNullException("Null");
        }
        if (element == string.Empty) {
            return !head.Terminal
            ? false
            : !(head.Terminal = false);
        }
        if (!Contains(element)) {
            return false;
        }
        var currentnode = head;
        foreach (var sign in element) {
            currentnode.CountOfWords -= 1;
            if (currentnode.Next[sign].CountOfWords == 1) {
                currentnode.Next.Remove(sign);
                return true;
            }
            currentnode = currentnode.Next[sign];            
        }
        currentnode.CountOfWords -= 1;
        currentnode.Terminal = false;
        return true;
    }
    public int HowManyStartsWithPrefix(string prefix) {
        if (prefix == null) {
            throw new ArgumentNullException("NULL");
        }
        Node currentnode = head;
        foreach (var sign in prefix) {
            if (!currentnode.Next.ContainsKey(sign)) {
                return 0;
            }
            currentnode = currentnode.Next[sign];
        }
        return currentnode.CountOfWords;
    }
    private class Node {
        public Node() {
            Next = new Dictionary<char, Node>();
        }
        public bool Terminal {get; set; }
        public int CountOfWords {get; set; }
        public Dictionary<char, Node> Next {get; }
    }
}