using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_SANBAY : DataProcess
    {
        public List<O_SANBAY> DuLieu(int a = 0)
        {
            return LayDuLieu<O_SANBAY>(true, string.Format(@"WHERE KhuVuc = {0}", a));
        }

        public O_SANBAY SanBay(string ID)
        {
            return LayMotDongDonGian<O_SANBAY>(string.Format(@"WHERE KyHieu = '{0}'  and KhuVuc = 0", ID));
        }
    }
}
