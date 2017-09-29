using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    struct KeyAndValue<Tkey, Tvalue>
    {
        public Tkey Key { get; set; }
        public Tvalue Value { get; set; }

        public KeyAndValue(Tkey key, Tvalue value)
        {
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return "[" + Key + ", " + Value + "]";
        }

    }
}
