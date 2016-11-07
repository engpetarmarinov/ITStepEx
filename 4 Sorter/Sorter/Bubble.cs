using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class Bubble : Basic
    {
        public override int[] Order(int[] nums)
        {
            var swapped = false;
            do
            {
                swapped = false;
                for (var i = 0; i < nums.Length - 1; i++)
                {
                    var cur = nums[i];
                    var next = nums[i + 1];
                    if (cur <= next) continue;
                    nums[i] = next;
                    nums[i + 1] = cur;
                    swapped = true;
                }
            } while (swapped != false);            
            return nums;
        }
    }
}
