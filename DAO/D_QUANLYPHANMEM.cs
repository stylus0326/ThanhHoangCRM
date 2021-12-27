using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_QUANLYPHANMEM : DataProcess
    {
        public List<O_QUANLYPHANMEM> DuLieu()
        {
            return LayDuLieu<O_QUANLYPHANMEM>();
        }
    }
}
