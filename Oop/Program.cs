using Oop.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Oop {
    internal class Program {
        static void Main (string[] args) {

            // musím inicializovat jako 'dynamic',
            // jinak do toho nikdy dynamicky nic nesetnu nebo negetnu
            dynamic car = new Sedan {
                ModelName = "Golf"
            };
            car["color"] = "red";
            car.color = "blue";
            var currentcolor = car.color;
            car.SetColor("black");

            Desharp.Debug.Dump(car);
            Desharp.Debug.Log(new List<Vehicle>() { car }, Desharp.Level.DEBUG);

            var sedan2 = Activator.CreateInstance(typeof(Sedan));

            // procházení anonymních objektů
            // var obj = new {
            dynamic obj = new {
                name = "Donald",
                surname = "Trump",
                function = "Dushbag"
            };
            PropertyDescriptorCollection objProps = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor prop in objProps) {
                // prop.Name
                // prop.GetValue(obj)
            }


            Console.ReadLine();
        }
    }
}
