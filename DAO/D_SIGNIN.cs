using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_SIGNIN : DataProcess
    {
        public List<O_SIGNIN> DuLieu()
        {
            return LayDuLieu<O_SIGNIN>(false, @"SELECT SI.*,coalesce(Ngay,'20100101') NgayGanNhat FROM SIGNIN SI
LEFT JOIN(SELECT MAX(NGAYGD) Ngay, Agent FROM GIAODICH GROUP BY Agent) G ON G.Agent = SI.SignIn");
        }

        public List<O_SIGNIN> TimSignIn(long IDDoiTac)
        {
            return LayDuLieu<O_SIGNIN>(true, "WHERE Daily = " + IDDoiTac);
        }
    }
}
