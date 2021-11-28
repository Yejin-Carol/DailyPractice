# LeetCode (하루 한 문제!)
## 난이도 Easy 

- 선형(Linear) 자료구조: array, stack, queue, linked list
    - 동적 배열 원리: 미리 초깃값 작게 잡아 배열 생성, 데이터 추가되면서 꽉 채워지면, 늘려주고 모두 복사하는 식
   
1. Two Sum 
* 내가 제출한 답 (python3)
```python
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        for i in range(len(nums)):
            for j in range(i + 1, len(nums)):
                if nums[i] + nums[j] == target:
                    return [i, j]
```
* 모범 답 (python3)
```python
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        hashmap = {}
        for i in range(len(nums)):
            complement = target - nums[i]
            if complement in hashmap:
                return [i, hashmap[complement]]
            hashmap[nums[i]] = i
```
* 모범 답 (Java)
```Java
class Solution {
    public int[] twoSum(int[] nums, int target) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < nums.length; i++) {
            int complement = target - nums[i];
            if (map.containsKey(complement)) {
                return new int[] { map.get(complement), i };
            }
            map.put(nums[i], i);
        }
        // In case there is no solution, we'll just return null
        return null;
    }
}
```
2021-11-15 추가

15. 3Sum (풀이 교재 참고)
* Python 풀이 1) Brute-Force: 배열을 2번 반복하면서 모든 조합을 더해서 일일히 확인해보는 무차별 대입 방식 (타임아웃)
* Python 풀이 2) Two Pointers로 합 계산, sum=0이면 정답
```python
class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        results = []
        nums.sort() # 작은수부터 큰수로 정렬
        
        for i in range(len(nums) -2):
            if i > 0 and nums[i] == nums[i -1]: # 중복된 값 건너뛰기
                continue
            left, right = i + 1, len(nums) -1 # 범위 좁혀가기
            while left < right:
                sum = nums[i] + nums[left] + nums[right] 
                if sum < 0:
                    left += 1
                elif sum > 0:
                    right -= 1
                else: #sum = 0이면 정답
                    results.append([nums[i], nums[left], nums[right]])
                    
                    while left < right and nums[left] == nums[left + 1]:
                        left += 1
                    while left < right and nums[right] == nums[right -1]:
                        right -= 1
                    left += 1
                    right -= 1
        
        return results
```


42. Trapping Rain Water, 빗물 트래핑 (Hard, 교재 참고)
* Two Pointers나 Stack을 가능 
```Python
class Solution:
    def trap(self, height: List[int]) -> int:
        stack = []
        volume = 0
        
        for i in range(len(height)):
            while stack and height[i] > height[stack[-1]]:
                top = stack.pop()
                
                if not len(stack):
                    break
                
                distance = i - stack[-1] -1
                waters = min(height[i], height[stack[-1]]) - height[top]
                
                volumne += distance * waters
                
            stack.append(i)
        return volume
```
스택 풀이법 참고. (투포인터) 어려움!


---
### Palindrome 관련 문제 
21-11-14 추가
5. Longest Palindrome (Medium)
최장 공통 부분 문자열 (Longest Common String), Dynamic Programming Algorithm (문제를 각각의 작은 문제로 나누어 해결한 결과를 저장해뒀다가 나중에 큰 문제의 결과와 합하여 풀이하는 알고리즘, 예)피보나치 수열)의 일종
* Python (교재 내용)
```python
class Solution:
    def longestPalindrome(self, s: str) -> str:
        # 투 포인터 확장
        def expand(left: int, right: int) -> str:
            while left >= 0 and right < len(s) and s[left] == s[right]:
                left -= 1
                right += 1
            return s[left + 1:right]
        
        # 해당 사항이 없을 때 빠르게 리턴
        if len(s) < 2 or s == s[::-1]:
            return s
        result = ''
        # 슬라이딩 윈도우 우측으로 이동
        for i in range(len(s) - 1):
            result = max(result,
                            expand(i, i + 1),
                            expand(i, i + 2),
                            key = len)
        return result
```

9. Palindrome Number (대칭수, string/int 변환 없이 풀어야함!)
* Python: 원래 간단한게 reverse = int(str(x)[::-1])로 할 수 있지만 문제에서 Follow up: Could you solve it without converting the integer to a string?
였으므로 없이 풀어야함. 
```python
	# 음수인 경우 False
        if x < 0:
            return False
  # number 변수에 x 저장 (예를 들어 x가 121인 경우)
        number = x
  # 10으로 나눈 나머지 값들 
        reverse = 0
        while number: (10나눈 나머지들 1, 2, 1)
            reverse = reverse * 10 + number % 10 
            number //= 10 
        return x == reverse 
 ```
 * Java [출처](https://redquark.org/leetcode/0009-palindrome-number/)
 ```Java
 public class PalindromeNumber {

    public boolean isPalindrome(int x) {
        // Base condition
        if (x < 0) {
            return false;
        }
        // Store the number in a variable
        int number = x;
        // This will store the reverse of the number
        int reverse = 0;
        while (number > 0) {
            reverse = reverse * 10 + number % 10;
            number /= 10;
        }
        return x == reverse;
    }
}
```
125. Valid Palindrome (회문)
* python: 소문자 & 정규식, 슬라이싱 사용하면 Deque보다 더 빠른 파이썬 최적화된 성능
```python
class Solution:
    def isPalindrome(self, s: str) -> bool:
        s= s.lower()
        s= re.sub('[^a-z0-9]', '', s)
        
        return s == s[::-1]
```
* Java 참고(https://sowon-dev.github.io/2021/01/09/210110replacevsreplaceall/)
   - char 포인터가 더 좋다고 한다.
```java
public static boolean isPalindrome(String s) {
    String s1 = s.toLowerCase().replaceAll("[^a-zA-Z0-9]", "");
    System.out.println(s1);

    //반으로 나눈뒤 글자 일치 여부 확인
    for(int i=0; i<s1.length()/2; i++){
      if(s1.charAt(i) != s1.charAt(s1.length()-i-1)){
        return false;
      }
    }
    return true;
}
```
234. Palindrome Linked List
* Python: Deque, Runner (다중 할당)
1) Deque (816ms)
```python
class Solution:
    def isPalindrome(self, head: Optional[ListNode]) -> bool:
        q: Deque = collections.deque()
        if not head:
            return True
        
        node = head
        
        while node is not None:
            q.append(node.val)
            node = node.next
            
        
        while len(q) > 1:
            if q.popleft() != q.pop():
                return False
        
        return True
```
2) Runner (변수 참조 하는것!, 620ms)
```python
        rev = None
        slow = fast = head
        
        while fast and fast.next:
            fast = fast.next.next
            rev, rev.next, slow = slow, rev, slow.next
        if fast:
            slow = slow.next
        
        while rev and rev.val == slow.val:
            slow, rev = slow.next, rev.next
        return not rev
```

* Java (참고:https://bcp0109.tistory.com/270) 깔끔한 풀이 (4ms!)
```java
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public boolean isPalindrome(ListNode head) {
         ListNode fast = head, slow = head;

        // slow 를 중간 지점까지 이동
        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }

        // 전체 길이가 홀수면 한칸 더 이동 (가운데 값은 비교할 필요 없음)
        if (fast != null) slow = slow.next;

        // 중간부터 마지막까지 노드 순서 뒤집기
        ListNode tail = reverse(slow);

        while (tail != null) {
            if (head.val != tail.val) {
                return false;
            }

            head = head.next;
            tail = tail.next;
        }

        return true;
    }

    private ListNode reverse(ListNode node) {
        ListNode tail = null;

        while (node != null) {
            ListNode next = node.next;
            node.next = tail;
            tail = node;
            node = next;
        }

        return tail;
    }
}
```
2021-11-18
* Linked List: ADT (Abstract Data Type) 구현의 기반. 배열과는 달리 특정 인덱스 접근 위해 전체 순서대로 읽어야 하므로 상수 시간 접근 안됨. 탐색 O(n), 시작/끝 아이템 추가, 삭제, 추출 작업 O(1) 가능함. 
206. Reverse Linked List
1) Python 재귀 (recursive)
```python
class Solution:
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if not node:
            return prev #뒤집힌 연결 리스트 첫 번째 노드
        next, node.next = node.next, prev
        return reverse(next, node) #백트래킹 
    
    return reverse(head)
```
2) Python 반복 (iterative)
```python
node, prev = head, None
        
        while node:
            next, node.next = node.next, prev
            prev, node = node, next
        
        return prev
```
* 자바 참고(https://bcp0109.tistory.com/142)
3) Java 재귀 
```java
public ListNode reverseList(ListNode head) {
        if(head == null || head.next == null)
            return head;
        
        ListNode node = reverseList(head.next);
        
        head.next.next = head;
        head.next = null;
        
        return node;
    }
```
4) Java 반복
```java
public ListNode reverseList(ListNode head) {
        ListNode node = null;

        while (head != null) {
            ListNode temp = head;
            head = head.next;
            temp.next = node;
            node = temp;
        }

        return node;
    }
```
2021-11-19

24. Swap Nodes in Pairs

* Python (그림 참고: https://velog.io/@eunseokim/17.-Add-Two-Numbers)
* 반복문
```Python
class Solution {
    public ListNode swapPairs(ListNode head) {
        root = prev = ListNode(None) # 0이라고 가정
        prev.next = head # head = 1
        while head and head.next: # 0, 1->2->3->4 라고 가정
            
            b = head.next # b= 2
            head.next = b.next # 1 -> 3 을 가르킨다?
            b.next = head # 2 다음이 1임. 즉 역순! 2 -> 1 -> 3
            
            prev.next = b # 0 -> 2
                
            head = head.next # 3
            prev = prev.next.next # 1, head.next 없을 때까지 반복 
        return root.next
    }
}
```
* 재귀 swap
```python
if head and head.next:
            p = head.next
            #스왑된 값 리턴
            head.next = self.swapPairs(p.next)
            p.next = head
            return p
        return head
```
* Java 재귀 swap (반복은 복잡 ㅠ)
```Java
 public ListNode swapPairs(ListNode head) {
        if(head == null || head.next == null) return head;
        
        ListNode second = head.next;
        ListNode third = head.next.next;
        
        second.next = head;
        head.next = swapPairs(third); 
        
        return second;
    }
```
2021-11-21

328. Odd Even Linked List
* Python (교재)
```python
class Solution:
    def oddEvenList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        if head is None:
            return None
        
        odd = head #the first node = odd
        even = head.next #the second node = even
        even_head = head.next
        
        while even and even.next:
            odd.next, even.next = odd.next.next, even.next.next
            odd, even = odd.next, even.next
            
        odd.next = even_head #last part of odd node is connected to even
        return head
```

* Java: 뭔가 길어졌지만 주석에 대한 설명이 명확한 코드.
나도 이렇게 작성하고 싶다 ㅠㅠ
 (참고: https://webrewrite.com/odd-even-linked-list/)
```java
 public ListNode oddEvenList(ListNode head) {
 
      //Temp pointer points to head
      ListNode temp = head;
 
      //Head pointer for a new list
      ListNode result = new ListNode();
 
      /*OddEvenNode pointer points to head initially
       * We use this pointer as an iterator.
       */
       ListNode oddEvenNode = result;
       int count = 1;
 
       //Put the odd nodes first
       while(temp != null) {
 
          if(count % 2 == 1) {
             oddEvenNode.next = new ListNode(temp.val);
             oddEvenNode = oddEvenNode.next;
           }            
 
           temp = temp.next;
           count++;
       }
 
        //Reintialize the values
        temp = head;
        count = 1;
 
       //put the even nodes
       while(temp != null) {
 
          if(count % 2 == 0) {
             oddEvenNode.next = new ListNode(temp.val);
             oddEvenNode = oddEvenNode.next;
           }
 
           temp = temp.next;
           count++;
        }
 
        oddEvenNode.next = null;
        return result.next;

    }
```
2021-11-22

92. Reverse Linked List II (Medium)
* Java (Discussion에 있는 답안)
```java
public ListNode reverseBetween(ListNode head, int left, int right) {
			int count = 1;
			ListNode curr = head;
			List<Integer> list = new ArrayList<>();
			while(curr != null){
				if(count >= left && count <= right){
					list.add(curr.val);
				}
				curr = curr.next;
				count++;
			}

			int size = list.size();
			int lastPos = size - 1;
			count = 1;
			curr = head;
			while(curr != null){
				if((count >= left && count <= right)){
					curr.val = list.get(lastPos);
					lastPos = lastPos - 1;
			}
				count++;
				curr = curr.next;
		}

		return head;
	}
```

* Python (교재..)
```python
     def reverseBetween(self, head: Optional[ListNode], left: int, right: int) -> Optional[ListNode]:
        #1) Exception
        if not head or left == right:
            return head
        
        root = start = ListNode(None)
        root.next = head
        
        # start, end 
        for _ in range (left - 1):
            start = start.next
        end = start.next
        
        # reverse
        for _ in range (right - left):
            tmp, start.next, end.next = start.next, end.next, end.next.next
            start.next.next = tmp
        return root.next
```




---

3. Roman to Integer 
* Python
```python
class Solution:
    def romanToInt(self, s: str) -> int:
        roman_table = {"I":   1,
		       "V":   5,
		       "X":  10,
		       "L":  50,
		       "C": 100,
		       "D": 500,
		       "M":1000	  
		                }
        num = 0
        last = "I" 

        for numeral in s[::-1]: #작은 수 -> 큰 수로 보기 위해 뒤집기 
            if roman_table[numeral] < roman_table[last]: #IV 인 경우, last가 크므로
                num -= roman_table[numeral] # num에 더해주기
            else: #그렇지 않은 경우
                num += roman_table[numeral] # num에 빼주기
            last = numeral
        
        return num
 ```
 * Java (Map으로 하는 방법도 있었음)
 	* [출처](https://github.com/cherryljr/LeetCode/blob/master/Roman%20to%20Integer.java)
```Java
class Solution {
	 public int romanToInt(String s) {
	    int nums[] = new int[s.length()];
	    for(int i = 0; i < s.length(); i++){
	        switch (s.charAt(i)) {
	            case 'M':
	                nums[i] = 1000;
	                break;
	            case 'D':
	                nums[i] = 500;
	                break;
	            case 'C':
	                nums[i] = 100;
	                break;
	            case 'L':
	                nums[i] = 50;
	                break;
	            case 'X' :
	                nums[i] = 10;
	                break;
	            case 'V':
	                nums[i] = 5;
	                break;
	            case 'I':
	                nums[i] = 1;
	                break;
	        }
	    } 
	    
	    int sum = 0;
	    for(int i=0; i<nums.length-1; i++){
	        if(nums[i] < nums[i+1])
	            sum -= nums[i];
	        else
	            sum += nums[i];
	    }
         
	    return sum + nums[nums.length-1];
	}
}
```
4. Longest Common Prefix
* Python
```python
class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
    
        if len(strs) == 0:
            return("")
        if len(strs) == 1:
            return(strs[0])
        
        pref = strs[0]
        plen = len(pref)
        
        for s in strs[1:]: #strs[1:]부터 loop
            
            while pref != s[0:plen]: 
                pref = pref[0:(plen-1)] #pref 줄이기
                plen -= 1 #len 줄이기
                
                if plen == 0:
                    return("") #공통된 pref 없을때 공백

        return(pref)
``` 
* Java (참고)
```java
class Solution {
    public String longestCommonPrefix(String[] strs) {
        String longestCommonPrefix = "";
        if(strs == null || strs.length ==0) {
            return longestCommonPrefix;
        }
        
        int index = 0; 
        for(char c: strs[0].toCharArray()) {
            for(int i = 1; i<strs.length; i++) {
                if(index >= strs[i].length() || c != strs[i].charAt(index)) {
                    return longestCommonPrefix;
                }
            }
            
            longestCommonPrefix += c;
            index++;
        }
        
        return longestCommonPrefix;
    }
}
```
5. Valid Parentheses
* 내가 제출한 답 (Python)
```python
class Solution:
    def isValid(self, s: str) -> bool:
        
        opens = []
        for symbol in s :
            if symbol == '(' or symbol == '[' or symbol == '{':
                opens.append(symbol)
            else : 
                if len(opens) == 0:
                    return False
                elif symbol == ')':
                    if opens.pop() != '(':
                        return False
                elif symbol == ']':
                    if opens.pop() != '[':
                        return False
                elif symbol == '}':
                    if opens.pop() != '{':
                        return False
        
        return len(opens) == 0
```
* DataDaft (Stack & Map 까지!)
```python
 # Close the last seen opening symbol w/ stack
        close_map = {"(":")", "{":"}", "[":"]"}
        opens = []
        
        for symbol in s:
            if symbol in close_map.keys():
                opens.append(symbol)
            elif opens == [] or symbol != close_map[opens.pop()]:
                return False
                
        return opens == []
```
2021-11-23
* Python (교재)
```python
def isValid(self, s: str) -> bool:
    table = {"(":")", "{":"}", "[":"]"}
    stack = []
           
    for char in s:
		if char not in table:
			stack.append(char)
		elif not stack or table[char] != stack.pop():
			return False
	return len(stack) == 0
```
316. Remove Duplicate Letters (Medium)
 * 재귀 & 분리 Python
Input: s = "cbacdcbc", 
Output: "acdb" 알파벳 순 ... 흠.. 어렵다.
```python
def removeDuplicateLetters(self, s: str) -> str:
	for char in sorted(set(s)):
		suffix = s[s.index(char):]
		if set(s) == set(suffix):
			return char + self.removeDuplicateLetter(suffix.replace(char, ''))
	return ''
```
* 스택 풀이
```python
def removeDuplicateLetters(self, s: str) -> str:
        counter = collections.Counter(s)
        seen = set()
        stack  = []

        for char in s:
            counter[char] -= 1
            if char in seen:
                continue

            while stack and char < stack[-1] and counter[stack[-1]] > 0:
                seen.remove(stack.pop())
            stack.append(char)
            seen.add(char)
       
        return ''.join(stack)
```
* Java
```java
public String removeDuplicateLetter(String s) {
	int[] lastIndex = new int[26]
	for(int i=0; i< s.length(); i++)
		lastIndex[s.charAt(i) - 'a'] = i;
	boolean[] seen = new boolean[26];
	Stack<Integer> st = new Stack();
	for(int i=0; i<s.length(); i++) {
		int c = s.charAt(i) - 'a';
		if(seen[c]) continue;
		while(!st.isEmpty() && st.peek() > c&&i<lastIndex[st.peek()])
			seen[st.pop()] = false;
		st.push(c);
		seen[c] = true;
	}
	StringBuilder sb = new StringBuilder();
	while(!st.isEmpty() sb.append((char)(st.pop() + 'a'));
	return sb.reverse().toString();
	}
}
```



* Java 모범 답안(https://all-dev-kang.tistory.com/entry/LeetCode-%EC%9E%90%EB%B0%94-20-Valid-Parentheses)
```java
class Solution {
    static Map<Character, Character> mappings = new HashMap<>();
    static {
        mappings.put('(', ')');
        mappings.put('[', ']');
        mappings.put('{', '}');
    }
    
    public boolean isValid(String s) {        
        Stack<Character> parenthesis = new Stack<>();
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (mappings.containsKey(c)) {
                parenthesis.push(mappings.get(c));
            } else if (mappings.containsValue(c)) {
                if (parenthesis.isEmpty() || parenthesis.pop() != c) {
                    return false;
                }
            }
        }
        return parenthesis.isEmpty();
    }
}
```
6. Merge Two Sorted Lists (가장 쉬웠음!)
* Java
```java
class Solution {
    public ListNode mergeTwoLists(ListNode l1, ListNode l2) {
        ListNode temp_node = new ListNode(0);
        ListNode current_node = temp_node;
        
        while(l1 !=null && l2 !=null) {
            if(l1.val < l2.val) {
                current_node.next = l1;
                l1 = l1.next;
            } else {
                current_node.next = l2;
                l2 = l2.next;
            }
            current_node = current_node.next;
        }
        
        if (l1 != null){ //null 관련 가독성 자바가 더 좋은듯
            current_node.next = l1;
                l1=l1.next;
        }
        if (l2 !=null){
            current_node.next = l2;
                l2=l2.next;
        }
        
        return temp_node.next;
        
    }
}
```
* Python
```python
class Solution:
    def mergeTwoLists(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        temp_node = ListNode()
        current_node = temp_node
        
        while l1 and l2:
            if l1.val < l2.val:
                current_node.next = l1
                l1 = l1.next
            else:
                current_node.next = l2
                l2 = l2.current_node
            current_node = current_node.next
        
        if l1:
            current_node.next = l1
        elif l2:
            current_node.next = l2
        
        return temp_node.next
```

7.  Remove Duplicates from Sorted Array (Easy!)
* Python
```python
class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        j = 1
	
	for i in range(1, len(nums)):
	    if nums[i] != nums[i - 1]:
	     	nums[j] = nums[i]
		j += 1
	return j
```
* Java
```java
class Solution {
    public int removeDuplicates(int[] nums) {
        int j = 1;
        
        for (int i = 0; i < nums.length-1; i ++) {
            if(nums[i] != nums[i+1]) {
                nums[j++] = nums[i+1];
            } 
        }
        return j;
    }
}
```
8. Remove Element
* Python
```python
class Solution:
    def removeElement(self, nums: List[int], val: int) -> int:
        j = 0
        for i in range(len(nums)):
            if nums[i] != val:
                nums[j] = nums[i]
                j +=1
        return j
```
* Java
```java
class Solution {
    public int removeElement(int[] nums, int val) {
        if(nums.length == 0) return 0;
        
        int j = 0;
        for (int i=0; i<nums.length; i++) {
            if(nums[i] !=val){
                nums[j] = nums[i];
                j++;
            }
        }
        return j;
    }
}
```
9. Implement strStr()
* Python (훨씬 간결하게!)
```python
if len(needle) == 0:
            return 0
        for i in range(len(haystack)):
            if haystack[i:i+len(needle)] == needle:
                return i
        return -1
```
* Java 참고(https://redquark.org/leetcode/0028-implement-strstr/)
```java
 public int strStr(String haystack, String needle) {
        // Base condition
        if (haystack == null || needle == null) {
            return -1;
        }
        // Special case
        if (haystack.equals(needle)) {
            return 0;
        }
        // length of the needle
        int needleLength = needle.length();
        // Loop through the haystack and slide the window
        for (int i = 0; i < haystack.length() - needleLength + 1; i++) {
            // Check if the substring equals to the needle
            if (haystack.substring(i, i + needleLength).equals(needle)) {
                return i;
            }
        }
        return -1;
    }

```
2021-11-14
49. Group Anagrams (언어유희) 
* Python: sorted(), join(), dictionry
```python
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        anagrams = collections.defaultdict(list)
        
        for word in strs:
            anagrams["".join(sorted(word))].append(word)
        return list(anagrams.values())
```
* Java (https://studyalgorithms.com/string/leetcode-group-anagrams-solution/) 자바 풀이 점점... 
```java
if (strs == null || strs.length == 0)
      return new ArrayList<>();

    Map<String, List<String>> stringAnagramsMap = new HashMap<>();
    for (String s : strs) {
      char[] arr = s.toCharArray();
      Arrays.sort(arr);
      String key = String.valueOf(arr);

      if (!stringAnagramsMap.containsKey(key))
        stringAnagramsMap.put(key, new ArrayList<>());

      stringAnagramsMap.get(key).add(s);
    }

    List<List<String>> resultList = new ArrayList<>();
    for (Map.Entry<String, List<String>> stringAnagrams : stringAnagramsMap.entrySet()) {
      resultList.add(stringAnagrams.getValue());
    }
    return resultList;
  }
```

344. Reverse String
* Python: [::-1] 슬라이싱 바로 적용 안됨 (플랫폼마다 상이) 
	- s[:] : [::-1] 적으면 해결됨
    - 리스트에만 제공되는 s.reverse()
    - 혹은 투 포인터 스왑
```python
    left, right = 0, len(s) -1
    while left < right:
        s[left], s[right] = s[right], s[left]
        left += 1
        right -= 1
```
* Java (출처:https://medium.com/@justcode/leetcode-344-reverse-string-a4de5957d622)
    - StringBuilder/StringBuffer 이용
    - 투 포인터 스왑
```java
public class Solution {
    public String reverseString(String s) {
        char[] c = s.toCharArray();
        int left = 0, right = c.length - 1;
        while (left < right) {
            char tmp = c[left];
            c[left++] = c[right];
            c[right--] = tmp;
        }
        return new String(chars);
    }
}
```
937. Reorder Data in Log Files 
* Python: 람다;; 다시 공부! (책 소스)
```python
class Solution:
    def reorderLogFiles(self, logs: List[str]) -> List[str]:
        letters, digits = [], []
        for log in logs:
            if log.split()[1].isdigit():
                digits.append(log)
            else:
                letters.append(log)
        
        letters.sort(key=lambda x: (x.split()[1:], x.split()[0]))
        return letters + digits
```
* Java 코드가 길어짐...(생략)

819. Most Common Word
* Java: 정규식 in regex, \W means word(alphanumeric and underscore) \s means whitespace(spaces tabs, line breaks). and the '+' means we match more than one of the pattern we have. 참고 (https://leetcode.com/problems/most-common-word/discuss/123854/)
```java
 // split paragraph 
        String[] words = paragraph.toLowerCase().split("\\W+");
        
        // add banned words to set
        Set<String> set = new HashSet<>();
        for(String word : banned){
            set.add(word);
        }
        
        // add paragraph words to hash map
        Map<String, Integer> map = new HashMap<>();
        for(String word : words){
            if(!set.contains(word)){
                map.put(word, map.getOrDefault(word, 0) + 1);
            }
        }
            
        // get the most frequent word
        int max = 0; // max frequency
        String res = "";
        for(String str : map.keySet()){
            if(map.get(str) > max){
                max = map.get(str);
                res = str;
            }
        }
        
        return res;
    }
```

* Python (책 참고)
    - 전처리(Preprocessing): [^\w] \w는 Word Character가  ^ (not)인 것 공백으로 치환
```python 
class Solution:
    def mostCommonWord(self, paragraph: str, banned: List[str]) -> str:
        words = [word for word in re.sub(r'[^\w]', ' ', paragraph)
                 .lower().split()
                        if word not in banned]
        
        #Returns a list of tuples => ('word',2)            
        counts = collections.Counter(words)
        #[('word', 2)] => ('word', 2) => 'word'
        return counts.most_common(1)[0][0]
```

2021-11-16

238. Product of Array Except Self (Medium)
* 문제 조건: You must write an algorithm that runs in O(n) time and without using the division operation. 나눗셈 없이 O(n)
* Python (교재 참고)
```python
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        out = []
        p = 1
        for i in range(0, len(nums)):
            out.append(p)
            p = p * nums[i]
        p = 1
        for i in range(len(nums) -1, 0 - 1, -1):
            out[i] = out[i] * p
            p = p * nums[i]
        return out
```

561. Array Partition I (Easy)
* Java로 쉽게 해결했지만 좋은 방법은 아님.
```java
class Solution {
    public int arrayPairSum(int[] nums) {
        
        int sum = 0;
        Arrays.sort(nums);
        for (int i=0; i <nums.length; i=i+2){
            sum += nums[i];
        }
        return sum;
    }
}
```
* Java2 better (https://sanghoo.tistory.com/23)
    - Arrays.sort 없이 풀이

* Python1
오름/내림 차순 상관없이 두개씩 pair 배열 생성한 뒤 min으로 구하기
```python
class Solution:
    def arrayPairSum(self, nums: List[int]) -> int:
        sum = 0
        pair = []
        nums.sort()
        
        for n in nums:
            pair.append(n)
            if len(pair) == 2:
                sum += min(pair)
                pair = []
                
        return sum
```
* Python2 간단하게 슬라이싱 활용
```python
return sum(sorted(nums)[::2])
```
2021-11-17
121. Best Time to Buy and Sell Stock (Easy)
* Python
1) Brute-Force (Timeout)
2) Kadane's Algorithm Max, Min (Descriptive Statistics): 
profit = -sys.maxsize 초깃값 = 최솟값 설정
min_price = sys.maxsize 초깃값 = 최대값 설정

```python
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        profit = 0
        min_price = sys.maxsize
        
        for price in prices:
            min_price = min(min_price, price)
            profit = max(profit, price - min_price)
        
        return profit
```

* Java: max, min, profit 변수 3개로 
```java
class Solution {
    public int maxProfit(int[] prices) {
        if(prices == null || prices.length == 0) {
            return 0;}
        
        int min = prices[0];
        int max = Integer.MIN_VALUE;
        
        for(int i = 0; i < prices.length; i++){
            int profit = prices[i] - min;
            if(profit > max) max = profit;
            if(prices[i] < min) min = prices[i];
        }
        
        return max;
        
    }
}
```
53. Maximum Subarray (Easy) - 교재 참고 ㅠ
* Python
1) Memoization: s an optimization technique used primarily to speed up computer programs by storing the results of expensive function calls and returning the cached result when the same inputs occur again. (wikipedia). 동적 프로그래밍 하향식 방법. 
```python
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
         for i in range(1, len(nums)):
            nums[i] += nums[i-1] if nums[i-1] > 0 else 0
         return max(nums)
``` 
2) Kadane's Algorithm (O(n))
``` python
         best_sum = -sys.maxsize
         current_sum = 0
         for num in nums:
             current_sum = max(num, current_sum + num)
             best_sum = max(best_sum, current_sum)
         
         return best_sum
```
2021-11-24

739. Daily Temperatures
스택을 이용한 문제 풀이

* Java

```java
class Solution {
    public int[] dailyTemperatures(int[] T) {
        int len = T.length;
		//int[] res에는 stack에 이미 담긴 숫자와 비교 구하는 값
        int[] res = new int[len], stack = new int[71];
        int index = -1;
        for (int i = len - 1; i >= 0; i--) {
            while (index >= 0 && T[stack[index]] <= T[i]) {
                index--;
            }
            if(index >= 0) res[i] = stack[index] - i;
            stack[++index] = i;
        }
        return res;
    }
}
```
* Python 더 간결함.
```Python
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        result = [0] * len(temperatures)
        stack = []
        for i, cur in enumerate(temperatures):
            # cur = current temperature
            while stack and cur > temperatures[stack[-1]]:
                last = stack.pop()
                result[last] = i - last
            stack.append(i)
        
        return result
```
2021-11-25

225. Implement Stack using Queues (Easy)
* Python: 문제의 친절한 설명 deque 사용!
```python
class MyStack:

    def __init__(self):
        self.q = collections.deque()

    def push(self, x: int) -> None:
        self.q.append(x)
        #Pushes element x to the top of the stack
        for _ in range(len(self.q) -1):
            self.q.append(self.q.popleft())

    def pop(self) -> int:
        #Removes the element on the top of the stack and returns it
        return self.q.popleft()

    def top(self) -> int:
        return self.q[0]

    def empty(self) -> bool:
        return len(self.q) == 0


# Your MyStack object will be instantiated and called as such:
# obj = MyStack()
# obj.push(x)
# param_2 = obj.pop()
# param_3 = obj.top()
# param_4 = obj.empty()
```
* Java (참고: https://www.baeldung.com/cs/stack-two-queues)

2021-11-26

232. Implement Queue using Stacks

* Python (225번과 비교 하기)

```python
class MyQueue:

    def __init__(self):
        self.input = []
        self.output = []

    def push(self, x: int) -> None:
        self.input.append(x)

    def pop(self) -> int:
        self.peek()
        return self.output.pop()

    def peek(self) -> int:
        if not self.output:
            while self.input:
                self.output.append(self.input.pop())
        return self.output[-1]
    def empty(self) -> bool:
        return self.input == [] and self.output == []

```
2021-11-27

622. Design Circular Queue
* 원형/환형 큐 (FIFO)

* Python: 문제 제약사항 따르기!
    * 참고 https://velog.io/@minjung-s/circular-queue

```python
class MyCircularQueue:

    def __init__(self, k: int):
        self.q = [None] * k
        self.maxlen = k
        self.p1 = 0
        self.p2 = 0

    def enQueue(self, value: int) -> bool:
        if self.q[self.p2] is None:
            self.q[self.p2] = value
            self.p2 = (self.p2 + 1) % self.maxlen
            return True
        else:
            return False

    def deQueue(self) -> bool:
        if self.q[self.p1] is None:
            return False
        else:
            self.q[self.p1] = None
            self.p1 = (self.p1 + 1) % self.maxlen
            return True
        
    def Front(self) -> int:
        return -1 if self.q[self.p2 - 1] is None else self.q[self.p1]

    def Rear(self) -> int:
        return -1 if self.q[self.p2 - 1] is None else self.q[self.p2 - 1]

    def isEmpty(self) -> bool:
        return self.p1 == self.p2 and self.q[self.p1] is None

    def isFull(self) -> bool:
        return self.p1 == self.p2 and self.q[self.p1] is not None
```

* Java
```java
class MyCircularQueue {
    
    private int[] data;
    private int head;
    private int tail;
    private int size;

    public MyCircularQueue(int k) {
        data = new int[k];
        head = -1;
        tail = -1;
        size = k;             
    }
    
    public boolean enQueue(int value) {
        if (isFull() == true) {
            return false;
        }
        if (isEmpty() == true) {
            head=0;
        }
        tail = (tail + 1) % size;
        data[tail] = value;
        return true;
    }
    
    public boolean deQueue() {
        if (isEmpty() == true) {
            return false;
        }
        if (head == tail) {
            head = -1;
            tail = -1;
            return true;
        }
        head = (head + 1) % size;
        return true;
    }
    
    public int Front() {
        if(isEmpty() ==true) {
            return -1;
        }
        return data[head];
    }
    
    public int Rear() {
        if(isEmpty() == true) {
            return -1;
        }
        return data[tail];
    }
    
    public boolean isEmpty() {
        return head == -1;        
    }
    
    public boolean isFull() {
        return ((tail + 1) % size) == head;
        
    }
}
```
2021-11-28

- 이중 연결 리스트를 이용해 Deque 자료형 직접 구현

641. Design Circular Deque (Medium)
     Deque: Double-ended queue와 비슷하지만 양쪽 모두 (head, tail)에서 삽입, 삭제 연산 가능.

- Python: 추가 \_add, \_del 함수 정의

```python
class MyCircularDeque:

    def __init__(self, k: int):
        self.head, self.tail = ListNode(None), ListNode(None)
        self.k, self.len = k, 0
        self.head.right, self.tail.left = self.tail, self.head

    # _add, _del 추가
    def _add(self, node: ListNode, new: ListNode):
        n = node.right
        node.right = new
        new.left, new.right = node, n
        n.left = new

    def _del(self, node: ListNode):
        n = node.right.right
        node.right = n
        n.left = node

    def insertFront(self, value: int) -> bool:
        if self.len == self.k:
            return False
        self.len += 1
        self._add(self.head, ListNode(value))
        return True

    def insertLast(self, value: int) -> bool:
        if self.len == self.k:
            return False
        self.len += 1
        self._add(self.tail.left, ListNode(value))
        return True

    def deleteFront(self) -> bool:
        if self.len == 0:
            return False
        self.len -= 1
        self._del(self.head)
        return True

    def deleteLast(self) -> bool:
        if self.len == 0:
            return False
        self.len -= 1
        self._del(self.tail.left.left)
        return True

    def getFront(self) -> int:
        return self.head.right.val if self.len else -1

    def getRear(self) -> int:
        return self.tail.left.val if self.len else -1

    def isEmpty(self) -> bool:
        return self.len == 0

    def isFull(self) -> bool:
        return self.len == self.k

```

- Java (https://haruhiism.tistory.com/206)

```java
class MyCircularDeque {
    
    private int[] deque;
    private int head = -1;
    private int tail = -1;
    private int size;
    
    public MyCircularDeque(int k) {
        size = k;
        deque = new int[k];
    }
    
    public boolean insertFront(int value) {
        if(isFull()){
            return false;
        }
        if(isEmpty()){
            head = 0;
            tail = size-1;
        }
        
        head = (head -1 + size) % size;
        deque[head] = value;
        return true;
        
    }
    
    public boolean insertLast(int value) {
        if(isFull()){
            return false;
        }
        if(isEmpty()){
            head = 0;
            tail = size-1;
        }
        
        tail = (tail + 1 + size) % size;
        deque[tail] = value;
        return true;
    }
    
    public boolean deleteFront() {
        if(isEmpty()){
            return false;
        }
        if(head == tail){
            head = -1;
            tail = -1;
        } else {
            head = (head + 1 + size) % size;
        }
        return true;
        
    }
    
    public boolean deleteLast() {
        if(isEmpty()){
            return false;
        }
        if(head == tail){
            head = -1;
            tail = -1;
        } else {
            tail = (tail - 1 + size) % size;
        }
        return true;
    }
    
    public int getFront() {
        if(isEmpty()) return -1;
        return deque[head];
    }
    
    public int getRear() {
        if(isEmpty()) return -1;
        return deque[tail];
        
    }
    
    public boolean isEmpty() {
        return head == -1 && tail == -1;
        
    }
    
    public boolean isFull() {
        return (tail + 1 + size) % size == head;
        
    }
}
```


* References: 파이썬 알고리즘 인터뷰, 각종 유튜브, 블로그
