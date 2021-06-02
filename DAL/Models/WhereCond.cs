using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class WhereCond
    {
        public WhereCond(string value, string compare, string op = "")
        {
            this.value = value;
            this.op = op;
            this.comparer = compare;
        }

        public string value;
        public string op;
        public string comparer;
        public Operator operators = new Operator();
        public Compare compare = new Compare();

        public class Operator
        {
            public string OR = "OR";
            public string AND = "AND";
        }

        public class Compare
        {
            public string EQUALS = "=";
            public string MORETHAN = ">";
            public string LESSTHAN = "<";
            public string MORETHANOREQUALS = ">=";
            public string LESSTHANOREQUALS = "<=";
            public string LIKE = "LIKE";
        }
    }
}
