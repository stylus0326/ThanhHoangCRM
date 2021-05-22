using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_TUYENBAY : DataProcess
    {
        public List<O_TUYENBAY> DuLieu()
        {
            return LayDuLieu<O_TUYENBAY>();
        }

        public O_TUYENBAY LayTuyenBay(int id)
        {
            return LayMotDongDonGian<O_TUYENBAY>(string.Format(@"WHERE ID = {0}", id));
        }

        public O_TUYENBAY TuyenBay(int Di, int Den)
        {
            return LayMotDongDonGian<O_TUYENBAY>(string.Format(@"WHERE KyHieuDi = {0} AND KyHieuDen = {1}", Di, Den));
        }
    }
}
