using System;

namespace Sorter
{
    public abstract class Basic 
    {
        /// <summary>
        /// Sorts an array of integers by a specific algorith
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>Sorted array with integers</returns>
        public abstract T[] Order<T>(T[] nums) where T: IComparable;
    }
}
