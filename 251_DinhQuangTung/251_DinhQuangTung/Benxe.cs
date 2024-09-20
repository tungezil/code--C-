using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _251_DinhQuangTung
{
    public class Benxe
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string maxe { get; set; }
        [DataMember]
        public string tenxe { get; set; }
        [DataMember]
        public string soluong { get; set; }
        [DataMember]
        public string loaixe { get; set; }
    }
}