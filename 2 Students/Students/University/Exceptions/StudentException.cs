using System;

namespace Students.University.Exceptions
{
    class StudentException : Exception
    {
        public StudentException(string msg) : base(msg)
        {
        }
    }
}
