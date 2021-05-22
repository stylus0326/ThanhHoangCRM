using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_SIGNINTRONG : DataProcess
    {
        public List<O_SIGNINTRONG> DuLieu()
        {
            return LayDuLieu<O_SIGNINTRONG>(true);
        }

        public List<O_SIGNINTRONG> TimSignIn(long IDDoiTac)
        {
            return LayDuLieu<O_SIGNINTRONG>(true, "WHERE Daily = " + IDDoiTac);
        }
    }
}
