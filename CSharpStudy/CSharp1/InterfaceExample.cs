using System;

namespace CSharpStudy.CSharp1
{
    public class InterfaceExample
    {
        public static void ExecuteExample(){

        }
    }

    //interface: contains definitions for a group or related functionalities that class or a struct can implement
    //can contain methods, properties, events, indexers
    //can't contain constants, fields, operators, instance constructors, finalizers, types
    //no access modifiers
    //to implement an interface member, the corresponding member of the implementing class must be public, non-static, and have the same name and signature as the interface member.
    interface IEquatable<T>{
        bool Equals(T obj);
    }

    public class CarExample : IEquatable<CarExample>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public bool Equals(CarExample car) => 
                    this.Make == car.Make &&
                    this.Model == car.Model &&
                    this.Year == car.Year;
    }
}    