using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _251_DinhQuangTung
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "I251_DinhQuangTung_Service" in both code and config file together.
    [ServiceContract]
    public interface I251_DinhQuangTung_Service
    {
        [OperationContract]
        List<Benxe> getAll();
        [OperationContract]
        List<Benxe> search(int maxe);

        [OperationContract]
        void create(int maxe, string tenxe, int soluong, string loaixe);

        [OperationContract]
        void update(int maxe, string tenxe, int soluong, string loaixe);

        [OperationContract]
        void delete(int maxe);


        [OperationContract]
        void user(string tenuser);
    }
}
