using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ql_nhanvien
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iql_nhanvien_service" in both code and config file together.
    [ServiceContract]
    public interface Iql_nhanvien_service
    {
        [OperationContract]
        List<Nhanvien> getAll();
        [OperationContract]
        List<Nhanvien> search(int manv);

        [OperationContract]
        void create(int manv, string tennv, string phongban, string gioitinh, int luong, int thuong, int sdt);

        [OperationContract]
        void update(int manv, string tennv, string phongban, string gioitinh, int luong, int thuong, int sdt);

        [OperationContract]
        void delete(int manv);
    }
}
