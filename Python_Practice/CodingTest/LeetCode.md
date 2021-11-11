# LeetCode 
## 난이도 Easy 

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
---
### Palindrome 관련 문제 
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

* References: 파이썬 알고리즘 인터뷰, 각종 유튜브, 블로그
