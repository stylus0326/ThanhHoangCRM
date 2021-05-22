using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_HANGBAY : DataProcess
    {
        public List<O_HANGBAY> DuLieu()
        {
            return LayDuLieu<O_HANGBAY>(true, " ORDER BY SapXep DESC");
        }

        public O_HANGBAY LayHangBay(string tentat)
        {
            return LayMotDongDonGian<O_HANGBAY>(string.Format(@"WHERE TenTat = '{0}' AND Xoa = '0'", tentat));
        }
    }
}
