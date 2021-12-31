2021-01-01

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
