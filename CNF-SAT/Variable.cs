using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNF_SAT
{
    internal class Variable
    {
        // tells if this variable represents positive values or negative values
        private bool pos_neg;
        // constructs a new variable
        public Variable(bool pos_neg)
        {
            this.pos_neg = pos_neg;
        }
        // assigned the value b into the variable and returns the answer.
        public bool assignValue(bool b)
        {
            // represents positive values
            if (this.pos_neg)
                return b;
            // represents negative values
            else
                return !b;
        }
        public void set_pos_neg(bool pos_neg)
        {
            this.pos_neg = pos_neg;
        }
    }
}
