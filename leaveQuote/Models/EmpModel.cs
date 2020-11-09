using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace leaveQuote.Models
{
    public class EmpModel
    {
        [DataMember(Name = "empId")]
        public int empId { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Casual")]
        public int Casual { get; set; }

        [DataMember(Name = "Annual")]
        public int Annual { get; set; }

        [DataMember(Name = "Medical")]
        public int Medical { get; set; }

        [DataMember(Name = "Home")]
        public int Home { get; set; }

        [DataMember(Name = "Special")]
        public int Special { get; set; }

        [DataMember(Name = "Type")]
        public string Type { get; set; }





    }
}
