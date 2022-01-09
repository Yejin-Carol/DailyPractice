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

2022-01-03

297. Serialize and Deserialize Binary Tree (Hard - referenced by the textbook)
- file, disk -> Serialize <-> Deserialize
- Pickle: serialization module of python 
- Pickling: Hierarchy Structure -> Byte Stream (Marshalling, Flattening, etc.)
``` python
class Codec:

    def serialize(self, root: TreeNode) -> str:
        queue = collections.deque([(root)])
        result = ['#']
        # Tree BFS Serialization
        while queue:
            node = queue.popleft()
            if node:
                queue.append(node.left)
                queue.append(node.right)
                
                result.append(str(node.val))
            else : 
                result.append('#')
        return ' '.join(result)

    def deserialize(self, data: str) -> TreeNode:
        # Exception
        if data == '# #':
            return None
        
        nodes = data.split()
        
        root = TreeNode(int(nodes[1]))
        queue = collections.deque([root])
        index = 2
        # like fast runner
        while queue:
            node = queue.popleft()
            if nodes[index] is not '#':
                node.left = TreeNode(int(nodes[index]))
                queue.append(node.left)
            index += 1
            
            if nodes[index] is not '#':
                node.right = TreeNode(int(nodes[index]))
                queue.append(node.right)
            index += 1
        return root
        
```

2022-01-04

110. Balanced Binary Tree

* AVL (Adelson-Velsky Landis)

```python
class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        def check(root):
            if not root:
                return 0
            
            left = check(root.left)
            right = check(root.right)
            if left == -1 or right == -1 or abs(left - right) > 1:
                return -1
            return max(left, right) + 1
        
        return check(root) != -1

```
2022-01-05

310. Minimum Height Trees

```python
class Solution:
    def findMinHeightTrees(self, n: int, edges: List[List[int]]) -> List[int]:
        if n <=1:
            return [0]
        
        graph = collections.defaultdict(list)
        for i, j in edges:
            graph[i].append(j)
            graph[j].append(i)
            
        leaves = []
        for i in range(n+1):
            if len(graph[i]) == 1:
                leaves.append(i)
                         
        while n > 2:
            n -= len(leaves)
            new_leaves = []
            for leaf in leaves:
                neighbor = graph[leaf].pop()
                graph[neighbor].remove(leaf)
            
                if len(graph[neighbor]) == 1:
                    new_leaves.append(neighbor)
        
            leaves = new_leaves
        
        return leaves
```


* BST (Binary Search Tree): Search Tree means an arranged tree. The values of left and right are arranged by each size. Time complexity is O(log n)

* Self-Balancing Binary Search Tree): keeping the short height on the basis of nodes in inserting and deleting

* AVL tree, Red-Black tree, Hash Table (Seperate Chaining)

2022-01-06

108. Convert Sorted Array to Binary Search Tree

* Asc -> height-balanced binary search tree (the depth of the two substrees of every node never differs by more than one)
* Binary Tree (finding log(n) value in any arranged array)
* BST is also based on an arranged array.
* Using Python Slicing
    - //: Divides the number on its left by the number on its right, rounds down the answer, and returns a whole number.

```python
class Solution:
    def sortedArrayToBST(self, nums: List[int]) -> Optional[TreeNode]:
        if not nums:
            return None
        
        mid = len(nums) // 2
        
        node = TreeNode(nums[mid])
        node.left = self.sortedArrayToBST(nums[:mid])
        node.right = self.sortedArrayToBST(nums[mid + 1:])
        
        return node
```
2022-01-10

938. Range Sum of BST (Easy)

* In Binary Tree, left values are lower than the root but right values are greater than 
* Iterative DFS

```python
class Solution:
    def rangeSumBST(self, root: Optional[TreeNode], low: int, high: int) -> int:
        stack, sum = [root], 0
        while stack:
            node = stack.pop()
            if node:
                if node.val > low:
                    stack.append(node.left)
                if node.val < high:
                    stack.append(node.right)
                if low <= node.val <= high:
                    sum += node.val
        return sum
```

* O(n) - Java
```java
class Solution {
    int sum = 0;
    
    public int rangeSumBST(TreeNode root, int low, int high) {
      
        if(root == null)
            return sum;
        
        calculateSum(root, low, high);
            
        return sum;
    }
    private void calculateSum(TreeNode root, int low, int high) {
        
        if(root == null)
            return;
        
        if(root.val > low)
            calculateSum(root.left, low, high);
        
        if(root.val >= low && root.val <= high) {
            sum = sum + root.val;
            
        }
                
        if(high > root.val)
            calculateSum(root.right, low, high);  
    }
}
```