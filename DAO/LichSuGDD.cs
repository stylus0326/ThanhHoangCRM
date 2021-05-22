using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class LichSuD : DataProcess
    {
        public LichSuD()
        {
            TableName = "LS_GIAODICH";
        }

        public List<LichSuO> LayDanhSach(string where, bool HeThong)
        {
            string CauTruyVan = "SELECT ct.* ,(case when ct.LoaiKhachHang = 4 then(select 'Hãng ' + TenHang from HANGBAY hb where hb.id = ct.Ma) when ct.LoaiKhachHang = 5 then(select Ten from NGANHANG nh where nh.id = ct.Ma) else (select ten from DAILY dl where dl.id = ct.Ma) end ) as Ten FROM LS_GIAODICH ct Where ID is not null ";
            CauTruyVan += where;
            CauTruyVan += HeThong ? "" : "and FormName <> N'Hệ Thống'";
            CauTruyVan += "ORDER BY NgayThucHien DESC, ID DESC";
            return LayDuLieu<LichSuO>(false, CauTruyVan);
        }

        public List<LichSuO> LayDanhSachTheoCode(string MaCho)
        {
            string CauTruyVan = "SELECT ct.* ,(case when ct.LoaiKhachHang = 4 then(select 'Hãng ' + TenHang from HANGBAY hb where hb.id = ct.Ma) when ct.LoaiKhachHang = 5 then(select Ten from NGANHANG nh where nh.id = ct.Ma) else (select ten from DAILY dl where dl.id = ct.Ma) end ) as Ten FROM LS_GIAODICH ct Where Macho = '" + MaCho;
            CauTruyVan += "' ORDER BY NgayThucHien DESC, ID DESC";
            return LayDuLieu<LichSuO>(false, CauTruyVan);
        }
    }
}
