using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_NGANHANGSUDUNG : DataProcess
    {
        public List<O_NGANHANGSUDUNG> DuLieu()
        {
            return LayDuLieu<O_NGANHANGSUDUNG>(true);
        }

    }
}
