using System;
namespace Contravariant
{
    // Contravariant interface.
    interface IContravariant<in A> { }

    // Extending contravariant interface.
    interface IExtContravariant<in A> : IContravariant<A> { }

    // Implementing Contravariant interface.
    class SampleContravariant<A> : IContravariant<A> { }

    interface ICovariant<out A> { }

    // Extending Covariant interface.
    interface IExtCovariant<out A> : ICovariant<A> { }

    // Implementing Covariant interface.
    class SampleICovariant<A> : ICovariant<A> { }

    class Program
    {
        static void Main()
        {
            IContravariant<Object> iobj = new SampleContravariant<Object>();
            IContravariant<String> istr = new SampleContravariant<String>();

            // You can assign iobj to istr because
            // the IContravariant interface is contravariant.
            // Allow implicit casting IContravariant<object> --> IContravariant<string>
            istr = iobj;

            ICovariant<Object> iobjtest = new SampleICovariant<object>();
            ICovariant<String> istrtest = new SampleICovariant<string>();

            //Allow implicit casting ICovariant<string> --> ICovariant<object>
            iobjtest = istrtest;
        }
    }
}
