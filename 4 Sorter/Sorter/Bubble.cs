using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class Bubble : Basic
    {
        public override T[] Order<T>(T[] nums)
        {
            var swapped = false;
            do
            {
                swapped = false;
                for (var i = 0; i < nums.Length - 1; i++)
                {
                    var cur = nums[i];
                    var next = nums[i + 1];
                    if (cur.CompareTo(next) <= 0) continue;
                    nums[i] = next;
                    nums[i + 1] = cur;
                    swapped = true;
                }
            } while (swapped != false);            
            return nums;
        }
    }
}
