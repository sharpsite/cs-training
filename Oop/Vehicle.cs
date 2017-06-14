using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Oop {
    // dynamicObject - nutné extendovat pro přiřazování/získávání přes těčku
    public class Vehicle: DynamicObject, IDisposable {
        // indexer je spec. property - pro přiřazování/získávání přes hranaté závorky
        // v hranatých závorkách může být nekonečně mnoho parametrů tak jako v metodách
        public object this[string key, bool asInitial = false] {
            get {
                object r = null;
                this._store.TryGetValue(key, out r);
                return r;
            }
            set {
                this._store[key] = value;
                if (this._store.ContainsKey(key)) {
                    this._store[key] = value;
                } else {
                    this._store.Add(key, value);
                }
            }
        }
        [Desharp.Hidden]
        private Dictionary<string, object> _store = new Dictionary<string, object>();

        public override bool TryGetMember (GetMemberBinder binder, out object result) {
            return this._store.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember (SetMemberBinder binder, object value) {
            this[binder.Name] = value;
            return true; // true aby neskončilo setování přes těčku chybou
        }

        public override bool TryInvokeMember (InvokeMemberBinder binder, object[] args, out object result) {
            result = null;
            Desharp.Debug.Log(new {
                binder = binder,
                args = args
            }, Desharp.Level.DEBUG);
            return true;
            //return base.TryInvokeMember(binder, args, out result);
        }

        public string FullName {
            get {
                //var b = this.GetType().GetField("Brand", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(this);

                return $"{this.Brand.ToString()} {this.ModelName}";
            }
        }

        public virtual Brand Brand { get; set; }
        public string ModelName = "";

        public static int Count = 0;

        public Vehicle () {
            Vehicle.Count++;
        }

        public void Dispose () {
            Vehicle.Count--;
        }
    }
}
