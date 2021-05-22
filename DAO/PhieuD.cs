using DataTransferObject;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class PhieuD : DataProcess
    {
        public List<PhieuO> LayDanhSach()
        {
            return LayDuLieu<PhieuO>(false, @"SELECT [ID], [NgayLap], [HoTen], [DiaChi], [LyDoNop], [SoTien], [KemTheo], [NguoiLapPhieu] FROM (
SELECT [ID], [NgayLap], [HoTen], [DiaChi], [LyDoNop], [SoTien], [KemTheo], [NguoiLapPhieu],1 [ThuChi] FROM [PHIEUCHI] 
union all
SELECT [ID], [NgayLap], [HoTen], [DiaChi], [LyDoNop], [SoTien], [KemTheo], [NguoiLapPhieu],0 [ThuChi] FROM [PHIEUTHU]) PhieuThuChi
ORDER BY [NgayLap] DESC");
        }

        public PhieuO LayPhieuThu(int ID)
        {
            return LayMotDongTuTao<PhieuO>(@"SELECT [ID], [NgayLap], [HoTen], [DiaChi], [LyDoNop], [SoTien], [KemTheo], [NguoiLapPhieu],0 [ThuChi] FROM [PHIEUTHU] WHERE ID = " + ID);
        }

        public PhieuO LayPhieuChi(int ID)
        {
            return LayMotDongTuTao<PhieuO>(@"SELECT [ID], [NgayLap], [HoTen], [DiaChi], [LyDoNop], [SoTien], [KemTheo], [NguoiLapPhieu],1 [ThuChi] FROM [PHIEUCHI] WHERE ID = " + ID);
        }
    }
}
