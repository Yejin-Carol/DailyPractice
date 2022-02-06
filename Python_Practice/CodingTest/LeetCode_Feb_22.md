2022-02-07

p. 479~488

* Merge Sort (Stable Sort)
* Quick sort (unstable Sort)
```python
def quicksort(A, lo, hi):
    def partition(lo, hi):
        pivot = A[hi]
        left = lo
        for right in range(lo, hi):
            if A[right] < pivot:
                A[left], A[right] = A[right], A[left]
                left += 1
        A[left], A[hi] = A[hi], A[left]
        return left

     if lo < hi:
         pivot = partition(lo, hi)
         quicksort(A, lo, pivot - 1)
         quicksort(A, pivot + 1, hi)
