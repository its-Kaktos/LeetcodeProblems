namespace ArrayProblems.Easy.MergeSortedArrayProblem;

/// <summary>
/// https://leetcode.com/problems/plus-one/?envType=problem-list-v2&envId=array&difficulty=EASY
/// </summary>
public class Problem
{
    /// <summary>
    /// https://www.youtube.com/watch?v=P1Ic85RarKY
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="m"></param>
    /// <param name="nums2"></param>
    /// <param name="n"></param>
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var last = nums1.Length - 1;
        m--;
        n--;

        while (m >= 0 && n >= 0)
        {
            if (nums1[m] > nums2[n])
            {
                nums1[last--] = nums1[m--];
                continue;
            }

            nums1[last--] = nums2[n--];
        }

        while (n >= 0)
        {
            nums1[last--] = nums2[n--];
        }
    }

    public void MergeOrg(int[] nums1, int m, int[] nums2, int n)
    {
        nums2.CopyTo(nums1.AsSpan(m));

        var low = 0;
        var high = m;
        while (low < m && high < nums1.Length - 1)
        {
            if (nums1[low].CompareTo(nums1[high]) is -1 or 0)
            {
                low++;
                continue;
            }

            (nums1[low], nums1[high]) = (nums1[high], nums1[low]);
            high++;
        }

        // if (low != m) low = 0;

        while (low < m)
        {
            if (nums1[low] > nums1[^1])
            {
                (nums1[low], nums1[^1]) = (nums1[^1], nums1[low]);
                // break;
            }

            low++;
        }

        // low = Math.Max(low - 1, 0);
        // if (high != nums1.Length - 1) high = m;

        while (high < nums1.Length - 1)
        {
            if (nums1[high] < nums1[low])
            {
                (nums1[low], nums1[high]) = (nums1[high], nums1[low]);
            }

            high++;
        }
    }
}