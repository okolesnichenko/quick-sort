using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortThread
{
    class MassWithPar
    {
        public int left;
        public int right;
        public int[] mass;
        public MassWithPar(int left, int right, int[] mass)
        {
            this.left = left;
            this.right = right;
            this.mass = mass;
        }
    }
}
