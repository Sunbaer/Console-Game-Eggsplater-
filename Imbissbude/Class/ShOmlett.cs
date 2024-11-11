using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imbissbude.Class
{
    public class ShOmlett: Omlett
    {
        public int Shroom;
        public ShOmlett(int shroom, int eggs):base (eggs)
        {
            this.Eggs = eggs;
            this.Shroom = shroom;
        }
    }
}
