# LeetCode Top 100 Liked Questions
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

2. Palindrome Number (대칭수, string/int 변환 없이 풀어야함!)
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
 
 
