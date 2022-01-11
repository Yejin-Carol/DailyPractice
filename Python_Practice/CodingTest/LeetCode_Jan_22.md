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
2022-01-11

783. Minimum Distance Between BST Nodes

* Tree Traversals (트리 순회): 1. Pre-Order (전위 순회, NLR), 2. In-Order (중위 순회, LNR), 3. Post-Order (후위 순회, LRN) (L: Left, R: Right, N: 8Node itself)

* Recursive Inorder Traversal
```python
class Solution:
    prev = -sys.maxsize
    result = sys.maxsize
        
    
    def minDiffInBST(self, root: Optional[TreeNode]) -> int:
        if root.left:
            self.minDiffInBST(root.left)
            
        self.result = min(self.result, root.val - self.prev)
        self.prev = root.val
            
        if root.right:
            self.minDiffInBST(root.right)
        
        return self.result
```       
* Iterative Inorder Traversal
```python
class Solution:
    def minDiffInBST(self, root: Optional[TreeNode]) -> int:
        prev = -sys.maxsize
        result = sys.maxsize
            
        stack = []
        node = root
            
        while stack or node:
            while node:
                stack.append(node)
                node = node.left
            
            node = stack.pop()
            
            result = min(result, node.val - prev)
            prev = node.val
            
            node = node.right
        
        return result      
```
2022-01-12

105. Construct Binary Tree from Preorder and Inorder Traversal (Medium..)

* Pre-order
* In-order: Confusing... Divide and Conquer

* Python
```python
class Solution:
    def buildTree(self, preorder: List[int], inorder: List[int]) -> Optional[TreeNode]:
        if inorder:
            #preorder: pop(0) -> O(n):Time Complexity
            index = inorder.index(preorder.pop(0))
            
            #inorder: divde and conquer
            node = TreeNode(inorder[index])
            node.left = self.buildTree(preorder, inorder[0:index])
            node.right = self.buildTree(preorder, inorder[index + 1:])
            
            return node
```            

* Java
```java
class Solution {
    public TreeNode buildTree(int[] preorder, int[] inorder) {
        Map<Integer, Integer> inMap = new HashMap<Integer, Integer>();
        
        for(int i=0; i<inorder.length; i++) {
            inMap.put(inorder[i], i);
        }
        
        TreeNode root = buildTree(preorder, 0, preorder.length -1, 
                                  inorder, 0, inorder.length -1, inMap);
        return root;
    }
    public TreeNode buildTree(int[] preorder, int preStart, int preEnd, 
                             int[] inorder, int inStart, int inEnd,
                             Map<Integer, Integer> inMap) {
        
        if(preStart > preEnd || inStart > inEnd) return null;
        
        TreeNode root = new TreeNode(preorder[preStart]);
        
        int inRoot = inMap.get(root.val);
        int numsLeft = inRoot - inStart;
        
        root.left = buildTree(preorder, preStart + 1, preStart + numsLeft,
                             inorder, inStart, inRoot - 1, inMap);
        
        root.right = buildTree(preorder, preStart + numsLeft + 1, preEnd, 
                              inorder, inRoot + 1, inEnd, inMap);
        
        return root;
    }
        
}
```

* referece: 
    -Data Structure: https://yoongrammer.tistory.com/70#:~:text=Output%3A%20A%20B%20D%20E%20C%20F%20G-,%EC%A4%91%EC%9C%84%20%EC%88%9C%ED%9A%8C%20(Inorder%20Traversal),%EC%9D%84%20%EA%B0%80%EC%A0%B8%EC%98%AC%20%EB%95%8C%20%EC%82%AC%EC%9A%A9%EB%90%A9%EB%8B%88%EB%8B%A4.

    -Java: https://www.youtube.com/watch?time_continue=946&v=aZNaLrVebKQ&feature=emb_logo

