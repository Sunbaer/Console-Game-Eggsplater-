using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imbissbude.Class
{
    public class TOmlett : Omlett
    {
        public int Tomato;

        public TOmlett(int eggs, int tomato):base(eggs)
        {
            this.Eggs = eggs;
            this.Tomato = tomato;

        }
    }
}
