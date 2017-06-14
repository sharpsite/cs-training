using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Oop.Vehicles {
    public class Sedan: Vehicle {


        public override Brand Brand {
            get {
                return Brand.VolksWagen;
            }
            set {
                this._brand = value;
            }
        }
        private Brand _brand;
    }
}
