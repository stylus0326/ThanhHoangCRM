using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_HOADON : DataProcess
    {
        #region dùng
        public List<O_HOADON> DuLieu(string a)
        {
            return LayDuLieu<O_HOADON>(true, "WHERE " + a + (a.Contains("ORDER") ? "" : "ORDER BY SoChungTu"), ",GiaYeuCau - GiaHeThong 'CL1', (GiaYeuCau - GiaHeThong) * PhanTram / 100 'CL2', (GiaYeuCau - GiaHeThong) * 10 / 11 'CL5', (case when GiaHeThong2 > 0 then GiaYeuCau - GiaHeThong2 else 0 end) 'CL3', (case when GiaHeThong2 > 0 then (GiaYeuCau - GiaHeThong2) * PhanTram2 / 100 else 0 end) 'CL4', (case when GiaHeThong2 > 0 then (GiaYeuCau - GiaHeThong2) * 10 / 11 else 0 end) 'CL6'");
        }

        public List<O_HOADON> LayThongTinMST()
        {
            return LayDuLieu<O_HOADON>(false, "SELECT MaSoThue, CongTy, DiaChi, Mail, IDKhachHang FROM HOADON GROUP BY MaSoThue, CongTy, DiaChi, Mail, IDKhachHang");
        }

        public bool KiemTraGiaoDich(string SoVe, bool isVNA)
        {
            return KiemTraDaTonTai(string.Format(@"WHERE {0} = '{1}' ", isVNA ? "SoVe" : "MaCho", SoVe));
        }

        public bool KiemTraGiaoDich2(string SoVe, bool isVNA)
        {
            return KiemTraDaTonTai(string.Format(@"WHERE ({0} = '{2}') or ({1} = '{2}')", isVNA ? "SoVe2" : "MaCho2", isVNA ? "SoVe" : "MaCho", SoVe));
        }

        public long CapNhatTrangThai(string TenTrangThai, string SoChungTu)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(TenTrangThai, 1);
            return CapNhat(dic, SoChungTu, "WHERE SoChungTu = {0}");
        }
        #endregion
    }
}
