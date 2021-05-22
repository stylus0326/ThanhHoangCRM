using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_MAUEMAIL : DataProcess
    {
        public List<O_MAUEMAIL> DuLieu()
        {
            return LayDuLieu<O_MAUEMAIL>(true);
        }
    }
}
