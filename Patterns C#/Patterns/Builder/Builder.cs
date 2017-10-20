using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
     abstract class Builder
    {
        public abstract void BuildPartOne();
        public abstract void BuildPartTwo();
        public abstract void BuildPartTree();
        public abstract House GetResult();
    }
}
