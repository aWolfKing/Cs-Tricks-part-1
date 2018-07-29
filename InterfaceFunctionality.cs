using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*

    C# unlike C++ does not allow classes to derrive from multiple base classes, 
    this combined with the fact that interfaces cannot have implemented functions does not allow a class to 'inherit' functions from
    multiple sources.
    For me that was a problem, because adding functionality to a class by just inheriting from an interface can be really usefull.

    So instead of implementing a method the normal way and having all classes have the exact same function defined,
    instead of just defining the funtion once, I asked my teacher if what I wanted to achieve was possible.
    He said it was not possible, so I started experimenting and found this trick.
    My teacher seemed surprised when I informed him about my findings 
    and as a result he explained it to the class in the following lesson.

    I found out about this trick around two weeks after learning what interfaces are.

*/


namespace CsTricksPart1 {


    /// <summary>
    /// An Interface that holds two float values which will be multiplied by calling Multiply().
    /// </summary>
    interface IMultiply{
        float Value0{ get; }
        float Value1{ get; }
    }

    /// To add a method (that does not need to be implemented before you can call it) to an Interface, you can use 'extendion methods'.
    /// Extension methods need to be declared in a static class.
    static class IMultiply_static{

        /// Extension method declaration.
        public static float Multiply(this IMultiply m){
            return m.Value0 * m.Value1;
        }
    }


    class InterfaceFunctionality {       
        public static void Example(){

            Console.WriteLine("---Interface functionality example---");

            IMultiply m = new MultiplyImplementation0();
            Console.WriteLine(m.Multiply());

            m = new MultiplyImplementation1();
            Console.WriteLine(m.Multiply());

        }
    }


    /// Implementations
    class MultiplyImplementation0 : IMultiply {
        float IMultiply.Value0 {
            get {
                return 42f;
            }
        }
        float IMultiply.Value1 {
            get {
                return 1.2f;
            }
        }
    }
    class MultiplyImplementation1 : IMultiply {
        float IMultiply.Value0 {
            get {
                return 5f;
            }
        }
        float IMultiply.Value1 {
            get {
                return 99f;
            }
        }
    }

}
