using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNF_SAT
{
    internal class Formula
    {
        private Clause[] clauses;
        // constructs a new Formula built of size clauses.
        // example: (x_1 || !x_2 || x_3) && (!x_1 || x_4)
        public Formula(Clause[] clauses)
        {
            if (clauses.Length == 0)
            {
                throw new ArgumentException("formula must be with clauses inside it.");
            }
            this.clauses = clauses;
        }
        // receives a matrix of boolean values to enter to the variables inside the formula
        // and returns the result.
        public bool assign_values(Dictionary<int, bool> index_value)
        {
            HashSet<int> indexes = new HashSet<int>();
            int[] current_arr;
            // go through all the clauses and add to the set all the unique variable indexes
            for(int i=0; i< clauses.Length; i++)
            {
                current_arr = clauses[i].getIndexes();
                for (int j=0; j< current_arr.Length; j++)
                {
                    if (!indexes.Contains(current_arr[j]))
                    {
                        indexes.Add(current_arr[j]);
                    }
                }
            }
            if (indexes.Count != index_value.Count) 
            {
                throw (new ArgumentException("The amount of variables doesn't match"));
            }
            bool ret_value = true;
            // temporary dict that assignes the relevant variables into a smaller dict
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            int[] arr;
            for (int i=0; i< this.clauses.Length; i++)
            {
                // get the relevant indexes for the clause
                arr = this.clauses[i].getIndexes();
                // assign the variables into the dict
                foreach (int j in arr)
                {
                    dict[j] = index_value[i];
                }
                // operator and between clauses
                ret_value = ret_value && this.clauses[i].assign_values(dict);
                dict.Clear();
            }
            return ret_value;
        }
        public bool IS_K_CNF_SAT()
        {

            return false;
        }
    }
}
