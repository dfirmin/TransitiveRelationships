using System;
using System.Collections.Generic;
using System.Text;

namespace TestTransitiveRelationship
{
    public class Interchange
    {
        public string value1 { get; set; }
        public string value2 { get; set; }


        public Interchange(string v1, string v2)
        {
            this.value1 = v1;
            this.value2 = v2;
        }
        
    }
}
