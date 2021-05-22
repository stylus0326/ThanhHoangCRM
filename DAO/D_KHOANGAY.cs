using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_KHOANGAY : DataProcess
    {

        #region dùng
        public List<O_KHOANGAY> DuLieu(string WHERE = "")
        {
            return LayDuLieu<O_KHOANGAY>(true, string.Format("WHERE MANGAY<>0 {0} order by TuNgay", WHERE));
        }

        public O_KHOANGAY KiemTraNgayKhoa(DateTime Day)
        {
            return LayMotDongDonGian<O_KHOANGAY>(string.Format("WHERE hoatdong = 1 and convert(date,TuNgay) = convert(date,'{0}') ", Day.ToString("yyyy/MM/dd")));
        }
        #endregion

    }

}
