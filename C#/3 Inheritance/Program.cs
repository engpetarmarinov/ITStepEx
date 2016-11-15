using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Parent
    {
        public void Test()
        {
            Console.WriteLine("Test Parent");
            //Late binding (Child.Test2)
            this.Test2();
            //invoke self method (Parent.Test3)
            this.Test3();
        }

        public virtual void Test2()
        {
            Console.WriteLine("Test 2 parent");
        }

        public void Test3()
        {
            Console.WriteLine("Test 3 parent");
        }
    }


    class Child : Parent
    {

        public override void Test2()
        {
            Console.WriteLine("Test 2 child");
        }

        public new void Test3()
        {
            Console.WriteLine("Test 3 child");
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            var a = new Child();
            a.Test();
        }
    }
}
