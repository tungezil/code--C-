using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _251_DinhQuangTung
{
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember] 
        public string tenuser { get; set; }
    }
}