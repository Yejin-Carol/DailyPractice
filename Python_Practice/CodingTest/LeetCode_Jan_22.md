2022-01-01

226. Invert Binary Tree (Easy)

- Method 1) Recursive Search (Shortest and Bottom-up approach)
    - The code is short however it's hard to explain. 
    - First, searching from right and swap the last nodes (6 <-> 9), then left nodes (1 <-> 3)
    - Second, upper (parents) nodes swap (2 <-> 7) with their children
    - In Python, return None can be omitted (Dynamic Typing- big advantage of Python)

```python

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def invertTree(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        if root:
            root.left, root.right = \
                self.invertTree(root.right), self.invertTree(root.left)
            return root
        return None
```        

- Method 2) BFS
    - similar to 104. Maximum Depth of Binary Tree (using while queue and Top-Down approach) 

```python
def invertTree(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        queue = collections.deque([root])
    
        while queue:
            node = queue.popleft()
            if node:
                node.left, node.right = node.right, node.left
                
                queue.append(node.left)
                queue.append(node.right)
    
        return root
```

- Method 3) DFS
    - There is only one change from BFS codes node= queue.popleft() -> stack.pop()

- Method 4) DFS Post-Order
    - post-order for node.left, node.right = node.right, node.left (swap)

- Java (recursive)

```java
class Solution {
    public TreeNode invertTree(TreeNode root) {
        if(root == null) {
            return null;
        }
        
        TreeNode right = invertTree(root.right);
        TreeNode left = invertTree(root.left);
        
        root.left = right;
        root.right = left;
        
        return root;    
    }
}
```
2022-01-02

617. Merge Two Binary Trees

- Recursive (post-order)
```python
class Solution:
    def mergeTrees(self, t1: TreeNode, t2: TreeNode) -> TreeNode:
        if t1 and t2:
            node = TreeNode(t1.val + t2.val)
            node.left = self.mergeTrees(t1.left, t2.left)
            node.right = self.mergeTrees(t1.right, t2.right)
            
            return node
        else:
            return t1 or t2
```

- Java (참고: https://afteracademy.com/blog/merge-two-binary-trees)
1) Recursive
```java
class Solution {
    public TreeNode mergeTrees(TreeNode root1, TreeNode root2) {
        if(root1 == null) {
            return root2;
        } else if(root2 == null) {
            return root1; 
        }
        root1.val += root2.val;
        root1.left = mergeTrees(root1.left, root2.left);
        root1.right = mergeTrees(root1.right, root2.right);
        
        return root1;        
        
    }
}
```
2) Iterator (by using stack-more complicated)
