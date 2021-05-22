using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class SignInD : DataProcess
    {
        public SignInD()
        {
            TableName = "SIGNIN";
        }

        public List<SignInO> DuLieu()
        {
            return LayDuLieu<SignInO>(true, " ORDER BY DaiLy, HangBay");
        }

        public List<SignInO> TimSignIn(long IDDoiTac)
        {
            return LayDuLieu<SignInO>(true, "WHERE Daily = " + IDDoiTac);
        }
    }
}
