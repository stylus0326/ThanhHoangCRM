using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class KhoaNgayD : DataProcess
    {
        public KhoaNgayD()
        {
            TableName = "KHOANGAY";
        }

        #region dùng
        public List<KhoaNgayO> DuLieu(string WHERE = "")
        {
            return LayDuLieu<KhoaNgayO>(true, string.Format("WHERE MANGAY<>0 {0} order by TuNgay", WHERE));
        }

        public KhoaNgayO KiemTraNgayKhoa(DateTime Day)
        {
            return LayMotDongDonGian<KhoaNgayO>(string.Format("WHERE hoatdong = 1 and convert(date,TuNgay) = convert(date,'{0}') ", Day.ToString("yyyy/MM/dd")));
        }
        #endregion

    }

}
