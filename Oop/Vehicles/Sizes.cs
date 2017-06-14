using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oop.Vehicles {
    public struct Sizes {
        public int Width;
        public int Height;
        public int Depth;
        public Sizes (int? w, int? h, int? d) {
            this.Width = w ?? 0;
            this.Height = h ?? 0;
            this.Depth = d ?? 0;
        }
    }

    public struct FunctionCallingInfo {
        public string ClassName;
        public string MethodName;
        public object[] Params;
        public object Result;
    }
}
