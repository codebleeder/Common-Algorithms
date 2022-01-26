public class TrieNode
{
    public Dictionary<char,TrieNode> child { get; set; }
    public bool isEnd { get; set; }
   
    public TrieNode()
    {
        this.child = new Dictionary<char, TrieNode>();
        this.isEnd = false;
    }
    public TrieNode(Dictionary<char, TrieNode> child, bool isEnd)
    {
        this.child = child;
        this.isEnd = isEnd;
    }
}

 public static TrieNode buildTrie(List<string> dictionary)
{
    var root = new TrieNode();
    foreach(var s in dictionary)
    {
        insertIntoTrie(root, s);
    }
    return root;
}
public static void insertIntoTrie(TrieNode root, string s)
{
    var curr = root;
    foreach(var c in s)
    {
        if(!curr.child.ContainsKey(c))
        {
            curr.child[c] = new TrieNode();
        }
        curr.child[c].count++;
        curr = curr.child[c];
    }
    curr.isEnd = true;
}
public static bool isPresent(TrieNode root, string s)
{
    var curr = root;
    for(var i=0; i<s.Length; ++i)
    {
        var c = s[i];
        if (!curr.child.ContainsKey(c))
        {
            return false;
        }
        else
        {
            curr = curr.child[c];
        }
    }
    return curr.isEnd;
}
