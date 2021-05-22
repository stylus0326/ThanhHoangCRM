using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_NHACUNGCAP_GIAODICHPHATSINH : DataProcess
    {
        public List<O_NHACUNGCAP_GIAODICHPHATSINH> DuLieu()
        {
            return LayDuLieu<O_NHACUNGCAP_GIAODICHPHATSINH>(true);
        }
    }
}
