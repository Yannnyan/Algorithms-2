using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNF_SAT
{
    internal class Clause
    {
        // represents all the possible variables in this clause
        private Variable[] variables;
        // represents the actual clause, with the values inside the array representing each variable index.
        private int[] clause;
        // represents the user - index to variable - index dictionary
        private Dictionary<int, int> dict;
        // constructs a new clause with size Variables.
        // note that size must be a positive value.
        // the index array represents the indexes of the variables, meaning which varaibles should be asserted the same value.
        // The index inside indexes is negative iff the variable is negative variable.
        public Clause(int size, int[] indexes)
        {
            if (indexes.Length == 0 || indexes == null)
            {
                throw (new ArgumentException("Size of a clause must be positive."));
            }
            // set that contains only unique indexes of variables
            HashSet<int> set = new HashSet<int>();
            for(int i=0; i< indexes.Length; i++)
            {
                if (set.Contains(indexes[i]))
                {
                    set.Add(indexes[i]);
                }
            }
            // number of unique indexes - size is wrong
            if (set.Count != size)
            {
                throw (new ArgumentException("size is different from the number of unique indexes."));
            }
            this.variables = new Variable[size];
            for(long i=0; i< size; i++)
            {
                this.variables[i] = new Variable(true);
            }
            this.dict = new Dictionary<int, int>();
            int varindex = 0;
            // assign unique index to index inside the variable array
            foreach (int index in set)
            {
                this.dict[Math.Abs(index)] = varindex++;
            }
            this.clause = indexes; 
        }
        // returns the size of the clause
        public long getSize()
        {
            return clause.Length;
        }
        // receives two arrays with the same size. the size must equal to the amount of variables.
        // for each variable assign it's variable-id in indexes at the same index of the value in values.
        public bool assign_values(Dictionary<int,bool> index_value)
        {
            if (index_value.Count != this.variables.Length)
            {
                throw (new ArgumentException("values length is not equal to the clause length."));
            }
            bool return_value = false;
            Variable current;
            int current_index;
            for(int i=0; i< clause.Length; i++)
            {
                // get the current index from the dictionary
                current_index = this.dict[Math.Abs(clause[i])];
                // get the current variable from the array
                current = this.variables[current_index];
                // set the positive or negative property of the variable.
                if (clause[i] < 0)
                {
                    current.set_pos_neg(false);
                }
                // operation or on the return value and the value represented by the current variable in the clause.
                return_value = return_value || current.assignValue(index_value[current_index]);
            }
            return return_value;
        }
        public int[] getIndexes()
        {
            return this.dict.Keys.ToArray();
        }
    }
}
