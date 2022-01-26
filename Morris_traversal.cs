public class TreeNode
{
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode(int x) { this.val = x; this.left = this.right = null; }
}

public static void morris(TreeNode root)
{
    var visited = new List<int>();
    var current = root;
    TreeNode pred = null;
    
    while (current != null)
    {
        if (current.left == null)
        {
            visited.Add(current.val);
            current = current.right;
        }
        else
        {
            var pred = findPred(current);
            if (pred.right == null)
            {
                pred.right = current;
                current = current.left;
            }
            else
            {
                pred.right = null;
                visited.Add(current.val);
                updateABC(pred, current, ref a, ref b, ref c);
                current = current.right;
            }
        }
    }
}

public static TreeNode findPred(TreeNode root)
{
    var iter = root.left;
    while(iter.right != null && iter.right != root)
    {
        iter = iter.right;
    }
    return iter;
}
