using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ql_nhanvien
{
    public class Nhanvien
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string manv { get; set; }
        [DataMember]
        public string tennv { get; set; }
        [DataMember]
        public string phongban { get; set; }
        [DataMember]
        public string gioitinh { get; set; }
        [DataMember]
        public string luong { get; set; }
        [DataMember]
        public string thuong { get; set; }
        [DataMember]
        public string sdt { get; set; }
    }
}