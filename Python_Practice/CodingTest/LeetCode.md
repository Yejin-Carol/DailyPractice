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
2021-11-29
641. Design Circular Deque (실제 난이도는 높지 않다고 함;;)
```python
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



2021-11-30

Hash Table
* Hash: 임의 크기 데이터를 고정 크기 값으로 매핑하는 데 사용할 수 있는 함수. 연산 분할 상환 분석에 따른 시간 복잡도 O(1) (데이터 양에 관계 없이 빠른 성능 기대할 수 있다는 장점이 있음.) 
    - 생일문제, 비둘기집 원리: 충돌 최소화 필요
    - Load Factor: n/k 해시테이블에 저장된 데이터 개수 n을 버킷의 개수 k로 나눈 것.
* Hashing: 해시 테이블을 인덱싱하기 위해 해시 함수 사용. 
* 개별 체이닝(Seperate Chaining): 해시 테이블의 원조로 충돌 시 연결 리스트로 연결하는 방식
* Open Addressing 

706 Design HashMap
* Python
```python
#ListNode 클래스 정의!
class ListNode:
    def __init__(self, key=None, value=None):
        self.key = key
        self.value = value
        self.next = None

class MyHashMap:
    #초기화
    def __init__(self):
        self.size = 1000 #기본 사이즈 1000개 정도 설정
        self.table = collections.defaultdict(ListNode)
    #삽입    
    def put(self, key: int, value: int) -> None:
        index = key % self.size
        #index 노드 없다면 삽입 후 종료
        if self.table[index].value is None: 
            self.table[index] = ListNode(key, value) #index는 해싱한 결과로 해시 테이블의 인덱스가 됨
            return
        
        #index 노드 있다면 연결 리스트 처리
        p = self.table[index]
        while p:
            if p.key == key:
                p.value = value
                return
            if p.next is None:
                break
                p = p.next
            p.next = ListNode(key, value)
    
    #조회        
    def get(self, key: int) -> int:
        index = key % self.size
        if self.table[index].value is None:
            return -1
        
        #노드 있을시 일치하는 키 탐색
        p = self.table[index]
        while p:
            if p.key == key:
                return p.value
            p = p.next
        return -1
    #삭제
    def remove(self, key: int) -> None:
        index = key % self.size
        if self.table[index].value is None:
            self.table[index] = ListNode(key, value)
            return
        #인덱스의 첫 번째 노드시 삭제 처리 
        p = self.table[index]
        if p.key == key:
            self.table[index] = ListNode() if p.next is None else p.next
            return
        #연결 리스트 노드 삭제
        prev = p
        while p:
            if p.key == key:
                prev.next = p.next
                return
            pre, p = p, p.next
```
2021-12-01

771. Jewels and Stones (Easy))
> J = "aA", S= "aAAbbbb"

* Python 다양한 풀이 1. Hash Table 사용
```python
class Solution:
    def numJewelsInStones(self, jewels: str, stones: str) -> int:
        freqs = {}
        count = 0

        #Stone = S
        for char in S:
            if char not in freqs:
                freqs[char] = 1
            else:
                freqs[char] += 1
        #Jewels = J
        for char in J:
            if char in freqs:
                count += freqs[char]
        
        return count
```
2. defaultdict 이용
```pyton
class Solution:
    def numJewelsInStones(self, jewels: str, stones: str) -> int:
        freqs = collections.defaultdict(int)
        count = 0
        
        for char in stones:
            freqs[char] += 1
        
        for char in jewels:
            count += freqs[char]
        
        return count
```
3. Counter로 계산
```python
freqs = collections.Counter(stones)
        count = 0
        
        for char in jewels:
            count += freqs[char]
            
        return count
```
4. 파이썬다운 방식 
```python
class Solution:
    def numJewelsInStones(self, jewels: str, stones: str) -> int:
        return sum(s in jewels for s in stones)
```

* Java: Time/Space complexity O(n)
```java
class Solution {
    public int numJewelsInStones(String jewels, String stones) {
        
        Set<Character> jewelSet = new HashSet<>();
        for(char j : jewels.toCharArray()){
            jewelSet.add(j);
        }
        
        int count = 0;
        for(char s: stones.toCharArray()){
            if(jewelSet.contains(s)) count++;
        }
        return count;
    }
}
```

2021-12-02

3. Longest Substring Without Repeating Characters (Medium)

- 점점 내 답은 줄어들고 교재 참고한 답은 늘어나는 중;;
- Sliding Window와 Two Pointers로 사이즈 조절.

```python
class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        used = {}
        max_length = start = 0
        for index, char in enumerate(s):
            if char in used and start <= used[char]:
                start = used[char] + 1
            else:
                max_length = max(max_length, index - start + 1)

            used[char] = index

        return max_length
```

- Java (참고: https://redquark.org/leetcode/0003-longest-substring-without-repeating-characters/)

```java
class Solution {
    public int lengthOfLongestSubstring(String s) {
        if (s == null || s.equals("")) {
            return 0;
        }
        //Starting window index
        int start = 0;
        //Ending window index
        int end = 0;
        int maxLength = 0;
        //This set will store the unique characters
        Set<Character> uniqueCharacters = new HashSet<>();

        while (end < s.length()) {
            if (uniqueCharacters.add(s.charAt(end))) {
                end++;
                maxLength = Math.max(maxLength, uniqueCharacters.size());
            } else {
                uniqueCharacters.remove(s.charAt(start));
                start++;
            }
        }
        return maxLength;
        }
}
```

- Python도 똑같이 set()으로 사용

```python
def lengthOfLongestSubstring(s: str) -> int:
    # Base condition
    if s == "":
        return 0
    # Starting index of window
    start = 0
    # Ending index of window
    end = 0
    # Maximum length of substring without repeating characters
    maxLength = 0
    # Set to store unique characters
    unique_characters = set()
    # Loop for each character in the string
    while end < len(s):
        if s[end] not in unique_characters:
            unique_characters.add(s[end])
            end += 1
            maxLength = max(maxLength, len(unique_characters))
        else:
            unique_characters.remove(s[start])
            start += 1
    return maxLength
```

2021-12-02

347. Top K Frequent Elements (Medium)
* Python
1. Counter와 heapq 사용 (Q23 Merge k Sorted Lists에서 이미 언급. Priority Queue와 달리 Thread-Safe 보장 안되나 큰 의미 없음. 실무에서도 heapq 사용)

1) 교재 코드의 경우 음수로 삽입해서 출력하는 거 이해가 가지 않는다. 
```python
class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        
        freqs = collections.Counter(nums)
        freqs_heap = []
        
        #힙에 음수로 삽입
        for f in freqs:
            heapq.heappush(freqs_heap, (-freqs[f], f))
        
        topk = list()
        
        #최소 힙(Min Heap)이므로 가장 적은 음수 순으로 추출
        for _ in range(k):
            topk.append(heapq.heappop(freqs_heap)[1])
            
        return topk
```
2) heapify() 방식이 더 쉽게 이해됐다. 참고 (https://tsoo1014.tistory.com/13)


```python
        d = dict()
        result = []
        heapq.heapify(result)
        for i in range(len(nums)):
            if nums[i] not in d:
                d[nums[i]] = 1
            else:
                d[nums[i]] += 1
        return heapq.nlargest(k, d, key = d.get)
```
3) Python씩 한줄 코드
```python
def topKFrequent(self, nums, k):
        return list(zip(*collections.Counter(nums).most_common(k)))[0]
```


* Java 풀이 (참고: https://bcp0109.tistory.com/279)
1) Bucket Sort 감탄~
```java
class Solution {
    public int[] topKFrequent(int[] nums, int k) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int num: nums) {
            map.put(num, map.getOrDefault(num, 0) + 1);
        }
        
        List<Integer>[] bucket = new List[nums.length + 1];
        for (Integer key : map.keySet()) {
            int count = map.get(key);
            
            if(bucket[count] == null) {
                bucket[count] = new ArrayList<>();
            }
            
            bucket[count].add(key);
        }
        
        List<Integer> list = new ArrayList<>();
        for(int i = bucket.length -1; i >=0 && list.size() <k; i--) {
            if (bucket[i] == null) continue;
            list.addAll(bucket[i]);
        }
        
        //list to array
        int[] result = new int[k];
        for (int i = 0; i < k; i++) {
            result[i] = list.get(i);
        }
        
        return result;
        
        
    }
}
```
2) Use Priority Queue
* priorityQueue.poll();       // priorityQueue에 첫번째 값을 반환하고 제거 비어있다면 null
* priorityQueue.remove();     // priorityQueue에 첫번째 값 제거
* priorityQueue.clear();      // priorityQueue에 초기화

2021-12-05 & 6

- 비선형구조
  - 그래프: 객체의 일부 쌍들이 연관되어 있는 객체 집합 구조
  - Seven Bridges of Königsberg
    - Leonhard Euler-graph theory: 간선 기준 (모든 정점이 짝수 개의 차우를 갖는다면 모든 다리 한 번씩만 건너서 도달하는 것 성립), 한 붓 그리기 문제
    - Hamiltonian Path: 정점 기준. 최적 알고리즘이 없는 대표적인 NP-완전(NP 문제 중 NP-난해인 문제), TSP: The Traveling Salesperson Problem, 외판원. 팩토리얼 시간 복잡도: 지수시간 보다 더 나쁜 것.
  - 그래프 순회 (Graph Traversales)
    - 깊이 우선 탐색 (DFS: Depth First Search): 스택으로 구현, 코테에서는 재귀 구현 선호.
    - 너비 우선 탐색 (BFS: Breadth-First Search): 반복 구조로 구현할 떄 Queue 이용. 
  - 그래프 표현 방법
    - 인접 행렬(Adjacency Matrix)과 인접 리스트(Adjacency List)
  - Backtracking: 해결책에 대한 후보를 구축해 나아가다 가능성이 없다고 판단되는 즉시 후보를 포기(Backtrack)해 정답을 찾아가는 범용적인 알고리즘으로 제약 충족 문제에 특히 유용. 제약 충족 문제(CSP: Constraint Satisfaction Problems)

200. Number of islands (DFS 설명 참고  https://www.youtube.com/watch?v=__98uL6wst8) - Medium
* Python: 동서남북 (네 방향 각각 DFS 재귀를 이용해 탐색 끝나면 1이 증가하는 형태)
```python
    def numIslands(self, grid: List[List[str]]) -> int:
        def dfs(x, y):
            # if no longer a land, return 
            if x < 0 or x >= len(grid) or y < 0 or y >= len(grid[0]) or grid[x][y] != '1':
                    return
                        
            grid[x][y] = '0'
            
            dfs(x+1, y) #east
            dfs(x-1, y ) #west
            dfs(x, y+1) #north
            dfs(x, y-1) #south         
        
        count = 0
        for x in range(len(grid)):
            for y in range(len(grid[0])):
                if grid[x][y] == '1':
                    dfs(x, y)
                    count += 1 # after visiting all the lands, += 1
        return count
```
* Java (O(n*m))
```java
    public int numIslands(char[][] grid) {
    
        int count = 0;
        
        for(int i = 0; i < grid.length; i++) {
            for(int j = 0; j <grid[0].length; j++) {
                
                if(grid[i][j] == '1') {
                    //Search all connected lands='1'
                    countIslandHelper(grid, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    public static void countIslandHelper(char[][]grid, int i, int j) {
        
        if(i < 0 || j < 0 || i >=grid.length || j >=grid[0].length || grid[i][j] != '1') {
            return;
        }
        //Mark '2' if visited
        grid[i][j] = '2';
        
        //Move 4 directions
        countIslandHelper(grid, i+1, j);//east
        countIslandHelper(grid, i-1, j);//west
        countIslandHelper(grid, i, j+1);//north
        countIslandHelper(grid, i, j-1);//south
        
    }
}
```

2021-12-07

17. Letter Combination of a Phone Number (Medium)
Backtracking, DFS search, 
* Python
```python
class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        def dfs(index, path):
            
            #Backtracking
            if len(path) == len(digits):
                result.append(path)
                return
            
            for i in range(index, len(digits)):
                for j in dic[digits[i]]:
                    dfs(i + 1, path + j)
        
        #Exception
        if not digits:
            return []
        
        dic = {"2": "abc", "3": "def", "4": "ghi", "5": "jkl",
              "6": "mno", "7": "pqrs", "8": "tuv", "9": "wxyz"}
        result = []
        dfs(0, "")
        
        return result
```
* Java: 친숙한 HashMap 이용한 풀이. 확실히 자바로 문제 푸는것은... 코드가 길다.
```java
class Solution {
    public List<String> letterCombinations(String digits) {
        HashMap<Character, char[]> dict = new HashMap<Character, char[]>();
        dict.put('2', new char[] {'a', 'b', 'c'});
        dict.put('3', new char[] {'d', 'e', 'f'});
        dict.put('4', new char[] {'g', 'h', 'i'});
        dict.put('5', new char[] {'j', 'k', 'l'});
        dict.put('6', new char[] {'m', 'n', 'o'});
        dict.put('7', new char[] {'p', 'q', 'r', 's'});
        dict.put('8', new char[] {'t', 'u', 'v'});
        dict.put('9', new char[] {'w', 'x', 'y', 'z'});
        
        List<String> result = new ArrayList<String>();
        if(digits == null || digits.length() == 0) {
            return result;
        }
        
        char[] arr = new char[digits.length()];
        helper(digits, 0, dict, result, arr);
        
        return result;
    }
    
    private void helper(String digits, int index, HashMap<Character, char[]> dict, 
                        List<String> result, char[] arr) {
        
        if(index == digits.length()) {
            result.add(new String(arr));
            return;
        }
        
        char number = digits.charAt(index);
        char [] candidates = dict.get(number);
        for(int i=0; i < candidates.length; i++) {
            arr[index] = candidates[i];
            helper(digits, index+1, dict, result, arr);
        }
    }
}
```
2021-12-08
46. Permutations
* Python: 순열 계산법은 알지만 직접 계산하려면; 백지상태...교재
1. DFS
```python
  def permute(self, nums: List[int]) -> List[List[int]]:
        results = []
        prev_elements = []
        
        def dfs(elements):
            #리프 노드일 때 결과 추가
            if len(elements) == 0:
                results.append(prev_elements[:])
                
            #순열 생성 재귀 호출
            for e in elements:
                next_elements = elements[:]
                next_elements.remove(e)
                
                prev_elements.append(e)
                dfs(next_elements)
                prev_elements.pop()
        
        dfs(nums)
        return results
```
2. itertools 강조 (구현의 효율성, 성능 위해 사용). permutations() 함수로 한줄로 끝.
```python
   def permute(self, nums: List[int]) -> List[List[int]]:
        return list(itertools.permutations(nums))
```
* Java 참고 https://bcp0109.tistory.com/236
    - Swap 참고

2021-12-18

77. Combinations

- 순열: n!/(n-r)!
- 조합: n!/r!(n-r)!: 순열과 달리 순서에 상관하지 않는 경우
  (순열에서는 자기 자신을 제외한 모든 요소 next_elements로 처리, 조합은 자신뿐만 아니라 앞의 모든 요소 배제후 next_elements 구성. 문제에서 elements 해당.)

```python
def combine(self, n: int, k: int) -> List[List[int]]:
        results = []

        def dfs(elements, start: int, k: int):
            if k == 0:
                results.append(elements[:])
                return

            # 자신 이전의 모든 값을 고정하여 재귀 호출
            for i in range(start, n+1):
                elements.append(i)
                dfs(elements, i+1, k-1)
                elements.pop()

        dfs([], 1, k)
        return results
```

- 한줄 풀이

```python
class Solution:
    def combine(self, n: int, k: int) -> List[List[int]]:
        return list(itertools.combinations(range(1, n+1), k))
```

2021-12-19

39. Combination Sum
* Python 

```python
class Solution:
    def combinationSum(self, candidates: List[int], target: int) -> List[List[int]]:
        result = []
        # csum = candidates_sum 
        def dfs(csum, index, path):
            # 종료 조건 
            if csum < 0: # 목표값을 초과한 경우 탐색 종료
                return
            if csum == 0: # csum 초기값 target이며 target과 일치하는 값
                result.append(path)
                return
            
            # 하위 원소까지 나열 재귀 호출
            for i in range(index, len(candidates)):
                dfs(csum - candidates[i], i, path + [candidates[i]])
                
        dfs(target, 0, [])
        return result
```
* Java (https://bcp0109.tistory.com/127)
```java
class Solution {
    List<List<Integer>> result = new ArrayList<List<Integer>>();   
    
    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        for (int i = 0; i < candidates.length;  i++) {
            List<Integer> temp = new ArrayList<Integer>();
            temp.add(candidates[i]);
            backtracking(candidates, i, 1, target - candidates[i], temp);
        }
        return result;
    }
     
    public void backtracking(int[] candidates, int index, int tempSize, int target, List<Integer> temp) {
    if(target == 0) {
        result.add(new ArrayList(temp));
        return;
    }        
        
    for (int i = index; i < candidates.length; i++) {
        if (candidates[i] <= target) {
            temp.add(candidates[i]);
            backtracking(candidates, i, tempSize + 1, target - candidates[i], temp);
            temp.remove(tempSize);
        }
    }
        
    }
    }
```
2021-12-20

39. Subsets (Medium)
* Python: 트리의 모든 DFS 결과. 즉 path를 만들어 나가면서 index를 1씩 증가하는 형태로 깊이 탐색. 별도의 종료 조건 없이 탐색이 끝나면 저절로 함수가 종료되게 함. 

```python
class Solution:
    def subsets(self, nums: List[int]) -> List[List[int]]:
        result = []
        
        def dfs(index, path):
            result.append(path)
            
            for i in range(index, len(nums)):
                dfs(i + 1, path + [nums[i]])
        
        dfs(0, [])        
        return result
```
* Java (https://www.youtube.com/watch?v=LdtQAYdYLcE)
```java
class Solution {
    public List<List<Integer>> subsets(int[] nums) {
        List<List<Integer>> subsets = new ArrayList<>();
        dfs(0, nums, new ArrayList<Integer>(), subsets);
        
        return subsets;
    }
    
    public void dfs(int index, int[] nums, List<Integer> list, List<List<Integer>> subsets) {
        subsets.add(new ArrayList<>(list));
        
        for (int i = index; i < nums.length; i++) {
            list.add(nums[i]);
            dfs(i + 1, nums, list, subsets);
            list.remove(list.size() - 1);
        }
    }
}
```
        
    for (int i = index; i < candidates.length; i++) {
        if (candidates[i] <= target) {
            temp.add(candidates[i]);
            backtracking(candidates, i, tempSize + 1, target - candidates[i], temp);
            temp.remove(tempSize);
        }
    }
        
    }
    }
```
2021-12-21

332 Reconstruct Itinerary (Hard...스스로 아직 못풉니다 ㅠ) 
- better follow in lexical order.
- 1. DFS (근데 LeetCode에 Wrong Answer;;; 2.Stack으로..)
```python
class Solution:
    def findItinerary(self, tickets: List[List[str]]) -> List[str]:
        graph = collections.defaultdict(list)
        
        #그래프 순서대로 구성
        for a, b in sorted(tickets):
            graph[a].append(b)
       
        route = []
        def dfs(a):
            while graph[a]:
                dfs(graph[a].pop(0))             
            route.append(a)
        
        dfs('JFK')
        # 뒤집어 
        return route[::-1]
```

- 2. Stack: pop(0)은 O(n), pop()은 O(1)
```python
class Solution:
    def findItinerary(self, tickets: List[List[str]]) -> List[str]:
        graph = collections.defaultdict(list)
        
        #그래프 뒤집어서 구성
        for a, b in sorted(tickets, reverse=True):
            graph[a].append(b)
            
        route = []
        def dfs(a):
            # 마지막 값을 읽어 어휘 순 방문
            while graph[a]:
                dfs(graph[a].pop())
            route.append(a)
        
    
        dfs('JFK')
        # 다시 뒤집어 어휘 순 결과로
        return route[::-1]
```
- 3. 일정 그래프 반복 (재귀 아닌 동일한 구조 반복)
```python
def findItinerary(self, tickets: List[List[str]]) -> List[str]:
        graph = collections.defaultdict(list)
        
        #그래프 순서대로 구성
        for a, b in sorted(tickets):
            graph[a].append(b)
       
        #경로가 끊어지는 경우 스택 값을 다시 pop()하여 거꾸로 푸러낼 변수 필요
        route, stack = [], ['JFK']
        while stack:
            while graph[stack[-1]]:
                stack.append(graph[stack[-1]].pop(0)) #한번 방문한 곳 다시 방문하지 않게 pop()으로 값 제거
            route.append(stack.pop())
        
        # 뒤집어 어휘 순 결과
        return route[::-1]
```

2021-12-22

207. Course Schedule (Medium)

1. DFS 순환 구조 판결 (Time Limit Exceeded)
*  순환 구조 판별 for a in list(graph): list()로 감싼것은 RuntimeError 예방책
       
2. 가지치기를 이용한 최적화 (visted 활용!)

```python
    def canFinish(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        graph = collections.defaultdict(list)
        for a, b in prerequisites:
            graph[a].append(b)
            
        traced = set()
        visited = set() # 방문한 노드 저장    
        
        def dfs(i):
            # 순환 구조-False
            if i in traced:
                return False
            
            if i in visited:
                return True
        
            traced.add(i)
            for b in graph[i]:
                if not dfs(b):
                    return False
            # 탐색 종료 후 순환 노드 삭제
            traced.remove(i)
            visited.add(i)
            
            return True
        
        # 순환 구조 판별
        for a in list(graph):
            if not dfs(a):
                return False
                
        return True
```

4. Java (https://cheonhyangzhang.gitbooks.io/leetcode-solutions/content/332-reconstruct-itinerary.html) 코드가 길다..

2021-12-23

경로 탐색 
- 최단 경로 문제
- Diijkstra Algorithm: 항상 노드 주변의 최단 거리 택하는 Greedy Algorithm 중 하나로 BFS 
- 참고 Occam's Razor (단순한 알고리즘 가장 훌륭!)

743. Network Delay Time (Medium)
- 우선순위 큐를 최소 힙 (Min Heap)으로 구현한 모듈인 heapq 사용하는 형태로 구현. pseudo code 이해
- 참고: https://www.youtube.com/watch?v=EaphyqKU4PQ

```python
class Solution:
    def networkDelayTime(self, times: List[List[int]], n: int, k: int) -> int:
    
        edges = collections.defaultdict(list)
        for u, v, w in times:
            edges[u].append((v, w))
            
        minHeap = [(0, k)]
        visited = set()
        result = 0 
        while minHeap:
            w1, n1 = heapq.heappop(minHeap)
            if n1 in visited:
                continue
            visited.add(n1)
            result = max(result, w1)
            
            for n2, w2 in edges[n1]:
                if n2 not in visited:
                    heapq.heappush(minHeap, (w1 + w2, n2))
        
        return result if len(visited) == n else -1
```
2021-12-25
* Q. 787. Cheapest Flights Within Stops
경로 탐색 (최단 경로 문제)
- Diijkstra Algorithm
1. 출발 노드 설정
2. 최단 거리 테이블 초기화
3. 방문하지 않은 노드 중 최단 거리가 가장 짧은 노드 선택
4. 해당 노드를 거쳐 다른 노드로 가는 비용 계산해 최단 거리 테이블 갱신
5. 3, 4번 반복

    - 교재 풀이 Time Limit Exeeded....

```python
class Solution:
    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, K: int) -> int:
        graph = collections.defaultdict(list)
        #그래프 인전 리스트 구정
        for u, v, w in flights:
            graph[u].append((v, w))
        
        # Q 변수: [(가격, 정점, 남은 가능 경유지 수)]
        Q = [(0, src, K)]
        
        # 우선순위 큐 최솟값 기준으로 도착점까지 최소 비용 판별
        while Q:
            price, node, k = heapq.heappop(Q)
            if node == dst:
                return price
            if k >= 0:
                for v, w in graph[node]:
                    alt = price + w
                    heapq.heappush(Q, (alt, v, k - 1))        
        return -1
```

- Bellman-Ford로 풀기 (참고: https://www.youtube.com/watch?v=5eIK3zUdYmE): with at most k stops 이라는 조건 때문에 다익스타라 추천하지 않았음;;
tmpPrices 만들어서 코딩.

```python

    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:
        prices = [float("inf")] * n #infinity
        prices[src] = 0
        
        for i in range(k + 1):
            tmpPrices = prices.copy()
            
            for s, d, p in flights: # s=source, d=destination, p=price
                if prices[s] == float("inf"):
                    continue
                # src + price < dst로 직항보다 가격이 적으면 tmp 업데이트    
                if prices[s] + p  < tmpPrices[d]:
                    tmpPrices[d] = prices[s] + p 
                    
            prices = tmpPrices
        
        return -1 if prices[dst] == float("inf") else prices[dst]
```
2021-12-26

Tree : 계층형 트리 구조를 시뮬레이션 하는 추상 자료형(ADT), root에서 시작. Parent-Child 관계가지고, Edge(간선)으로 연결, 차수(Degree = Node의 개수), Size는 자신을 포함한! 모든 자식 노드의 개수. Height (현재 위치에서부터 Leaf까지의 거리) , Depth는 root에서부터 현재 노드까지의 거리.

* Graph vs Tree
    - Tree는 순환 구조(Cyclic)를 갖지 않는 그래프
    - Tree는 특수한 형태의 그래프의 일종, 크게 그래프의 범주에 포함됨.
    - 그래프와 달리 한번 연결된 노드가 다시 연결되는 법 없음. 
    - 단방향(Uni-Directional), 양방향(Bi-Directional) 모두 가리킬 수 있는 그래프와 달리, 트리는 부모 노드에서 자식 노드를 가리키는 단방향뿐임.
    - Tree는 하나의 부모 노드를 가짐 
* 이진 트리 vs 이진 탐색 트리BST (Binary Search Tree)
    - 각 노드가 m개 이하의 자식을 갖고 있으면, m-ary트리(다항 트리, 다진 트리)라고 함.
    - m = 2, 모든 노드의 차수가 2이하일 때 특별히 이진 트리(Binary Tree)라고 구분해서 부름. 
    - 이진 트리는 왼쪽, 오른쪽 최대 2개의 자식을 갖는 매우 단순한 형태.
    - 이진 트리 대표적인 유형 3가지 (그림이 이해 더 쉬움)
        - 정 이진 트리(Full Binary Tree): 모든 노드가 0개 또는 2개의 자식 노드를 가짐
        - 완전 이진 트리(Complete Binary Tree): 마지막 레벨 제외하고 모든 레벨 완전히 채워져 있으며, 마지막 레벨 모든 노드는 가장 왼쪽부터 채워져 있음.
        - 포화 이진 트리(Perfect Binary Tree): 모든 노드가 2개의 자식 노드를 갖고 있으며, 모든 리프 노드가 동일한 깊이 또는 레벨 가짐. 

* 104. Maximum Depth of Binary Tree (Easy)
    - 깊이 측정은 BFS (Breadth First Search, 너비 우선 탐색, Queue), 참고: DFS (Stack)

```python
# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        if root is None:
            return 0        
        queue = collections.deque([root])
        depth = 0
        
        while queue: 
            depth += 1
            #큐 연산 추출 노드의 자식 노드 삽입
            for _ in range(len(queue)):
                cur_root = queue.popleft()
                if cur_root.left:
                    queue.append(cur_root.left)
                if cur_root.right:
                    queue.append(cur_root.right)
        # BFS 반복 횟수 == 깊이            
        return depth
```

* 간단한 Java 풀이 (else의 1+를 뒤에 붙이면 fail 주의!)
참고: https://www.tutorialcup.com/leetcode-solutions/maximum-depth-of-binary-tree-leetcode-solution.htm
```java
class Solution {
    public int maxDepth(TreeNode root) {
        if(root==null)
            return 0;
        else return 1+Math.max(maxDepth(root.left), maxDepth(root.right));        
    }
}
```

2021-12-27

* 543. Diameter of Binary Tree (Easy)
    - 상태값 누적 트리 DFS (Stack)
    - python: 중첩 합수에서 클래스 변수 사용하는 이유는 self.longest를 사용해 longest 변수에 값을 재할당 했기 때문이며 변수 값이 숫자나 문자가 아닌 리스트나 딕셔너리 자료형이라면 append() 등의 메소드 이용해 재할당 없이 조작 가능. longest처럼 숫자나 문자인 경우 불변 객체이므로 함수 내 값 변경 불가능하므로 클래스 변수 사용.
```python
class Solution:
    longest: int = 0
    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        def dfs(node: TreeNode) -> int:
            if not node:
                return -1 #Full Binary 아닌 경우 패널티처럼 부여
            # left, right 각 leaf node까지 탐색
            left = dfs(node.left)
            right = dfs(node.right)
            self.longest = max(self.longest, left + right + 2) # 거리
            return max(left, right) + 1 #상태값
        
        dfs(root)
        return self.longest 
```

* Java 풀이 
참고: https://escapefromcoding.tistory.com/162
```java
class Solution {
    int longest = 0;
    public int diameterOfBinaryTree(TreeNode root) {
        if(root==null) return -1;
        DFS(root);
        return longest;
    }
    public int DFS(TreeNode root) {
        if(root==null) return -1;
        int left = DFS(root.left);
        int right = DFS(root.right);
        longest = Math.max(longest, left+right+2);
        return Math.max(left, right) + 1;
    }
}
```

687. Longest Univalue Path
* Python
```python
class Solution:
    result: int = 0
    
    def longestUnivaluePath(self, root: Optional[TreeNode]) -> int:    
        def dfs(node: TreeNode):
            if node is None:
                return 0 
            
            # 존재하지 않는 노드까지 DFS 재귀 탐색
            left = dfs(node.left)
            right = dfs(node.right)
            
            if node.left and node.left.val == node.val:
                left += 1
            else:
                left = 0
            if node.right and node.right.val == node.val:
                right += 1
            else:
                right = 0
            
            
            self.result = max(self.result, left + right)
            
            return max(left, right)
            
        dfs(root)
        return self.result
            
```
* Java
```java
class Solution {
        int result;
    public int longestUnivaluePath(TreeNode root) {
        result = 0;
        arrowLength(root);
        return result;
    }
    public int arrowLength(TreeNode node) {
        if(node == null) {
            return 0;
        }
        
        int left = arrowLength(node.left);
        int right = arrowLength(node.right);
        
        int arrowLeft = 0, arrowRight = 0;
        
        if (node.left != null && node.left.val == node.val) {
            arrowLeft += left + 1;
        }
        if (node.right != null && node.right.val == node.val) {
            arrowRight += right + 1;
        }
        
        result = Math.max(result, arrowLeft + arrowRight);
        return Math.max(arrowLeft, arrowRight);
    }
    
}
```


* References: 파이썬 알고리즘 인터뷰, 각종 유튜브, 블로그

