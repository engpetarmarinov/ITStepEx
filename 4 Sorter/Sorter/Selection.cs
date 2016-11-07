using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class Selection : Basic
    {
        public override int[] Order(int[] nums)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                // assume the min is the first element
                var iMin = i;
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[iMin] > nums[j])
                    {
                        //a new min index found
                        iMin = j;
                    }
                }
                if (iMin != i)
                {
                    //swap
                    var temp = nums[i];
                    nums[i] = nums[iMin];
                    nums[iMin] = temp;
                }
            }
            return nums;
        }
    }
}
