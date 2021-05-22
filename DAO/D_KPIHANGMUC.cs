using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_KPIHANGMUC : DataProcess
    {

        public List<O_KPIHANGMUC> DuLieu()
        {//, string.Format("WHERE Muc {0} M'Mục'", Muc ? "=" : "<>"
            return LayDuLieu<O_KPIHANGMUC>(true);
        }

        public List<O_KPIHANGMUC> DuLieu1()
        {//, 
            return LayDuLieu<O_KPIHANGMUC>(true, "WHERE Nhom <> N'Mục'");
        }
    }
}
