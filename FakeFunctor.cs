using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*

    C# unlike C++ does not allow the '()' (/function call) operator to be overloaded and thus does not allow for functors.
    (Functors are objects that can also be called as if they were functions.)

    I thought this was a shame and tried to recreate a functor in C# and I succeeded.



    I do not really use this trick that much, because it is a 'trick' and not really intended as far as I know.
    But having said that, I have had some moments where it was a really usefull trick.
    My best example is when I recreated a kind of event/callback.

*/


namespace CsTricksPart1 {


    /// <summary>
    /// A class that has a (fake) functor.
    /// </summary>
    class ClassThatHasAFunctor{

        /// <summary>
        /// The functor class, this functor only counts the amount of times it was called.
        /// </summary>
        public class Functor{
            internal int m_timesCalled = 0;
            public int TimesCalled {
                get{
                    return this.m_timesCalled;
                }
            }
        }

        internal Functor m_functor = new Functor();

        /// To make the 'fuctor' function like it should, you need to make a property that has at least a 'get' accessor.
        /// You cannot use a field instead of a property.
        public Functor FunctorObject {
            get{
                return this.m_functor;
            }
        }

    }

    /// To enable calling the functor like you call a method, you need an extension method.
    static class ClassThatHasAFunctor_static{

        /// The extension method has to have the same name as the property that acts like the functor.
        /// Usually you cannot have multiple members with the same name in a class, 
        /// but technically an extension method is no really a member of the class.
        /// Because of this reason this trick works.
        public static void FunctorObject(this ClassThatHasAFunctor c){
            c.m_functor.m_timesCalled++;
        }
    }


    class FakeFunctor {

        public static void Example(){

            ClassThatHasAFunctor c = new ClassThatHasAFunctor();

            Console.WriteLine("---Fake functor example---");

            Console.WriteLine("Times called: " +
                /// Treats c.FunctorObject as an actual object
                c.FunctorObject.TimesCalled
            );  //0
            /// Treats c.FunctorObject as a function.
            c.FunctorObject();  //calls for the first time.
            Console.WriteLine("Times called: " + 
                c.FunctorObject.TimesCalled
            );  //1
            c.FunctorObject();  //calls a second time.
            Console.WriteLine("Times called: " + 
                c.FunctorObject.TimesCalled
            );  //2
            c.FunctorObject();  //calls a third time.
            Console.WriteLine("Times called: " + 
                c.FunctorObject.TimesCalled
            );  //3

        }

    }

}
