using DataAccessLayer;
using DataTransferObject;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CRM
{
    class DuLieuTaoSan
    {
        #region Instance
        private static DuLieuTaoSan instance;

        public static DuLieuTaoSan Instance
        {
            get
            {
                if (instance == null) instance = new DuLieuTaoSan(); return instance;
            }
            set
            {
                instance = value;
            }
        }

        private DuLieuTaoSan() { }
        #endregion

        public static Dictionary<string, object> Adic = new Dictionary<string, object>();
        public static QuyenNhanVienO Q;
        public static DaiLyO NV = new DaiLyO();

        public string PhienBan = Assembly.GetExecutingAssembly().GetName().Version.ToString() + " - 21/09/2020";

        public static string[] MocThoiGian(string TenCot = "NgayGD")
        {
            return new string[] { "AND DATEDIFF(day, "+TenCot+" , GETDATE()) = 0", //Hôm nay
                                  "AND DATEDIFF(day, "+TenCot+" , GETDATE()) = 1", //Hôm qua
                                  "AND CONVERT(DATE,"+TenCot+")= CONVERT(DATE,DATEADD(DAY , 2-DATEPART(WEEKDAY,GETDATE()),GETDATE()))",//Thứ 2
                                  "AND CONVERT(DATE,"+TenCot+")= CONVERT(DATE,DATEADD(DAY , 7-DATEPART(WEEKDAY,GETDATE()-7),GETDATE()-7))",//Thứ 7 tuần trước
                                  "AND CONVERT(DATE,"+TenCot+")= CONVERT(DATE,DATEADD(DAY , 8-DATEPART(WEEKDAY,GETDATE()-7),GETDATE()-7))",//Chủ nhật tuần trước
                                  "AND ("+TenCot+" BETWEEN DATEADD(week, DATEDIFF(day, 0, GETDATE())/7, 0) AND GETDATE())", //Tuần này
                                  "AND ("+TenCot+" BETWEEN DATEADD(week, DATEDIFF(day, 0, GETDATE())/7-1, 0) AND DATEADD(week, DATEDIFF(day, 0, getdate())/7-1, 6))", //Tuần trước
                                  "AND MONTH("+TenCot+") = MONTH(GETDATE()) AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng này
                                  "AND CONVERT(date,"+TenCot+") BETWEEN DATEADD(DAY,1,EOMONTH(GETDATE(),-2)) and convert(date,EOMONTH (GETDATE(), -1 ))",//Tháng trước
                                  "AND DATEPART(quarter , "+TenCot+") = DATEPART(quarter , GETDATE()) AND YEAR("+TenCot+") = YEAR(GETDATE())", //Qúy này
                                  "AND CONVERT(date,"+TenCot+") BETWEEN DATEADD(QQ, DATEDIFF(QQ,0, Dateadd(ms,-6,Dateadd(qq, Datediff(qq,0,GetDate()), 0))),0) AND Dateadd(ms,-6,Dateadd(qq, Datediff(qq,0,GetDate()), 0))" , //Qúy trước
                                  "AND YEAR("+TenCot+") = YEAR( GETDATE())", //Năm này
                                  "AND YEAR("+TenCot+") = YEAR(GETDATE()) - 1", //Năm trước
                                  "AND MONTH("+TenCot+") = 1 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 1
                                  "AND MONTH("+TenCot+") = 2 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 2
                                  "AND MONTH("+TenCot+") = 3 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 3
                                  "AND MONTH("+TenCot+") = 4 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 4
                                  "AND MONTH("+TenCot+") = 5 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 5
                                  "AND MONTH("+TenCot+") = 6 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 6
                                  "AND MONTH("+TenCot+") = 7 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 7
                                  "AND MONTH("+TenCot+") = 8 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 8
                                  "AND MONTH("+TenCot+") = 9 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 9
                                  "AND MONTH("+TenCot+") = 10 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 10
                                  "AND MONTH("+TenCot+") = 11 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 11
                                  "AND MONTH("+TenCot+") = 12 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng 12
                                  "AND DATEPART(quarter , "+TenCot+") = 1 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Qúy I
                                  "AND DATEPART(quarter , "+TenCot+") = 2 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Qúy II
                                  "AND DATEPART(quarter , "+TenCot+") = 3 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Qúy III
                                  "AND DATEPART(quarter , "+TenCot+") = 4 AND YEAR("+TenCot+") = YEAR(GETDATE())", //Qúy IV

        };
        }

        public static string[] ThoiGianRutGon(string TenCot = "NgayThucHien")
        {
            return new string[] { "AND (CONVERT(date,"+TenCot+") BETWEEN DATEADD(week, DATEDIFF(day, 0, GETDATE())/7, 0) AND GETDATE())", //Tuần này
                                  "AND (CONVERT(date,"+TenCot+") BETWEEN DATEADD(week, DATEDIFF(day, 0, GETDATE())/7-1, 0) AND DATEADD(week, DATEDIFF(day, 0, getdate())/7-1, 6))", //Tuần trước
                                  "AND MONTH("+TenCot+") = MONTH(GETDATE()) AND YEAR("+TenCot+") = YEAR(GETDATE())", //Tháng này
                                  "AND CONVERT(date,"+TenCot+") BETWEEN DATEADD(DAY,1,EOMONTH(GETDATE(),-2)) and convert(date,EOMONTH (GETDATE(), -1 ))",//Tháng trước
                                  "AND DATEPART(quarter , "+TenCot+") = DATEPART(quarter , GETDATE()) AND YEAR("+TenCot+") = YEAR(GETDATE())", //Qúy này
                                  "AND CONVERT(date,"+TenCot+") BETWEEN DATEADD(QQ, DATEDIFF(QQ,0, Dateadd(ms,-6,Dateadd(qq, Datediff(qq,0,GetDate()), 0))),0) AND Dateadd(ms,-6,Dateadd(qq, Datediff(qq,0,GetDate()), 0))" , //Qúy trước
                                  "AND YEAR("+TenCot+") = YEAR( GETDATE())", //Năm này
                                  "AND YEAR("+TenCot+") = YEAR(GETDATE()) - 1", //Năm trước
        };
        }

        #region không chỉnh sửa
        public static List<IntString> GioiTinh()
        {
            List<IntString> _lst = new List<IntString>();
            _lst.Add(new IntString() { ID = 0, Name = "Nam" });
            _lst.Add(new IntString() { ID = 1, Name = "Nữ" });
            return _lst;
        }

        public static List<IntString> LoaiPhi(bool CS = true)
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 0, Name = "Phí Thu" });
            lst.Add(new IntString() { ID = 1, Name = "Chiết Khấu Thường" });
            if (CS)
            {
                lst.Add(new IntString() { ID = 2, Name = "Chiết Khấu %" });
                lst.Add(new IntString() { ID = 3, Name = "Khuyến Mãi" });
            }
            return lst;
        }

        //public static List<IntString> TrangThai_GiaoDich(int LoaiKhachHang)
        //{
        //    List<IntString> lst = new List<IntString>();
        //    switch (LoaiKhachHang)
        //    {
        //        case 0:
        //        case 1:
        //        case 2:
        //            lst.Add(new IntString() { ID = 8, Name = "TT Đại lý" });
        //            break;
        //        case 3:
        //            lst.Add(new IntString() { ID = 1, Name = "Đã TT" });
        //            lst.Add(new IntString() { ID = 2, Name = "Nợ" });
        //            break;
        //        case 4:
        //            lst.Add(new IntString() { ID = 1, Name = "Đã TT" });
        //            lst.Add(new IntString() { ID = 2, Name = "Nợ" });
        //            lst.Add(new IntString() { ID = 4, Name = "Vé Hoàn" });
        //            lst.Add(new IntString() { ID = 8, Name = "TT Đại lý" });
        //            break;
        //    }
        //    lst.Add(new IntString() { ID = 3, Name = "Đổi vé" });
        //    return lst;
        //}
        #endregion
        public static List<IntString> LoaiGiaoDich_Ve_All(int LoaiKhachHang)
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 4, Name = "Vé" });//
            lst.Add(new IntString() { ID = 13, Name = "Đổi" });//
            lst.Add(new IntString() { ID = 14, Name = "Hành lí" });//
            lst.Add(new IntString() { ID = 0, Name = "Gọi tổng đài" });//
            lst.Add(new IntString() { ID = 1, Name = "Phí đặt chỗ" });//
            lst.Add(new IntString() { ID = 5, Name = "Phí hóa đơn" });//
            lst.Add(new IntString() { ID = 6, Name = "Thu hồi" });//
            lst.Add(new IntString() { ID = 10, Name = "Phạt nợ" });//

            lst.Add(new IntString() { ID = 9, Name = "Hoàn" });//
            lst.Add(new IntString() { ID = 7, Name = "Hoàn trả" });//
            lst.Add(new IntString() { ID = 11, Name = "Hỗ trợ phí" });//
            lst.Add(new IntString() { ID = 12, Name = "Chiết khấu" });//

            lst.Add(new IntString() { ID = 8, Name = "Phí hoàn" });//

            switch (LoaiKhachHang)
            {
                case 0:
                    lst.Add(new IntString() { ID = 3, Name = "Tạm ứng" });
                    lst.Add(new IntString() { ID = 2, Name = "Trả Tạm ứng" });
                    break;
                case 1:
                    lst.Add(new IntString() { ID = 2, Name = "Nộp quỹ" });
                    lst.Add(new IntString() { ID = 3, Name = "Rút quỹ" });
                    break;
                case 2:
                    lst.Add(new IntString() { ID = 2, Name = "Nộp tiền" });
                    lst.Add(new IntString() { ID = 3, Name = "Rút tiền" });
                    break;
            }
            return lst;
        }

        public static List<IntString> LoaiKhachHang_Ve()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 0, Name = "Cty" });
            lst.Add(new IntString() { ID = 1, Name = "Đại lý" });
            lst.Add(new IntString() { ID = 2, Name = "CTV" });
            lst.Add(new IntString() { ID = 3, Name = "Khách lẻ" });
            return lst;
        }

        public static List<IntString> LoaiGiaoDich_Ve(bool Ve)
        {
            List<IntString> lst = new List<IntString>();
            if (Ve)
            {
                lst.Add(new IntString() { ID = 4, Name = "Vé" });//
                lst.Add(new IntString() { ID = 9, Name = "Hoàn" });//
                lst.Add(new IntString() { ID = 8, Name = "Phí hoàn" });//
                lst.Add(new IntString() { ID = 13, Name = "Đổi" });//
                lst.Add(new IntString() { ID = 14, Name = "Hành lí" });//
                lst.Add(new IntString() { ID = 15, Name = "Khác" });//
            }
            else
            {
                lst.Add(new IntString() { ID = 0, Name = "Gọi tổng đài" });//
                lst.Add(new IntString() { ID = 1, Name = "Phí đặt chỗ" });//
                lst.Add(new IntString() { ID = 5, Name = "Phí hóa đơn" });//
                lst.Add(new IntString() { ID = 6, Name = "Thu hồi" });//

                lst.Add(new IntString() { ID = 7, Name = "Hoàn trả" });//
                lst.Add(new IntString() { ID = 11, Name = "Hỗ trợ phí" });//
                lst.Add(new IntString() { ID = 12, Name = "Chiết khấu" });//
            }
            return lst;
        }

        public static List<IntString> LoaiKhachHang_frmNganHangKL()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 3, Name = "Khách lẻ" });
            lst.Add(new IntString() { ID = 6, Name = "Khác" });
            return lst;
        }

        public static List<IntString> LoaiKhachHang_NganHang()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 1, Name = "Đại lý" });
            lst.Add(new IntString() { ID = 0, Name = "Nhân Viên" });
            lst.Add(new IntString() { ID = 2, Name = "Cộng tác viên" });
            lst.Add(new IntString() { ID = 3, Name = "Khách lẻ" });
            lst.Add(new IntString() { ID = 5, Name = "Ngân hàng" });
            lst.Add(new IntString() { ID = 7, Name = "Trung gian" });
            lst.Add(new IntString() { ID = 8, Name = "Nhà cung cấp" });
            lst.Add(new IntString() { ID = 9, Name = "Công ty" });
            lst.Add(new IntString() { ID = 6, Name = "Khác" });
            return lst;
        }

        public static List<IntString> LoaiKhachHang_GiaoDich(bool An = true)
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 0, Name = "Cty" });
            lst.Add(new IntString() { ID = 1, Name = "Đại lý" });
            lst.Add(new IntString() { ID = 2, Name = "CTV" });
            lst.Add(new IntString() { ID = 3, Name = "Khách lẻ" });
            if (An)
                lst.Add(new IntString() { ID = 4, Name = "Đã Ẩn" });
            return lst;
        }

        public static List<IntString> HinhThucHoaDon()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 0, Name = "Không" });
            lst.Add(new IntString() { ID = 1, Name = "Xuất HD" });
            lst.Add(new IntString() { ID = 2, Name = "Đã Xuất HD" });
            return lst;
        }

        public static List<GiaTriBoolString> TrangThai_NganHang()
        {
            List<GiaTriBoolString> lst = new List<GiaTriBoolString>();
            lst.Add(new GiaTriBoolString() { BoolValue = false, Name = "Chờ" });
            lst.Add(new GiaTriBoolString() { BoolValue = true, Name = "Xong" });
            return lst;
        }

        public static List<IntString> HinhThuc_Ve_TatCa()
        {
            List<IntString> lst = new List<IntString>();

            lst.Add(new IntString() { ID = 1, Name = "Trừ quỹ" });
            lst.Add(new IntString() { ID = 2, Name = "Giao vé TT" });
            lst.Add(new IntString() { ID = 3, Name = "Tiền mặt" });
            lst.Add(new IntString() { ID = 4, Name = "Chuyển khoản" });
            lst.Add(new IntString() { ID = 7, Name = "Nợ" });

            return lst;
        }

        public static List<IntString> HinhThuc_Ve(int LoaiKhachHang)
        {
            List<IntString> lst = new List<IntString>();
            switch (LoaiKhachHang)
            {
                case 0:
                case 1:
                case 2:
                    lst.Add(new IntString() { ID = 1, Name = "Trừ quỹ" });
                    break;
                case 3:
                    lst.Add(new IntString() { ID = 2, Name = "Giao vé TT" });
                    lst.Add(new IntString() { ID = 3, Name = "Tiền mặt" });
                    lst.Add(new IntString() { ID = 4, Name = "Chuyển khoản" });
                    lst.Add(new IntString() { ID = 7, Name = "Nợ" });
                    break;
            }
            return lst;
        }


        public static List<IntString> LoaiGiaoDich_NganHang_TatCa()
        {
            List<IntString> lst = new List<IntString>();
            lst.Add(new IntString() { ID = 0, Name = "Hãng chiết khấu" });
            lst.Add(new IntString() { ID = 1, Name = "Nộp hãng" });
            lst.Add(new IntString() { ID = 2, Name = "Nộp quỹ" });
            lst.Add(new IntString() { ID = 3, Name = "Rút quỹ" });
            lst.Add(new IntString() { ID = 4, Name = "Khách thanh toán" });
            lst.Add(new IntString() { ID = 5, Name = "Chuyển khoản" });
            lst.Add(new IntString() { ID = 6, Name = "Nộp tiền" });
            lst.Add(new IntString() { ID = 7, Name = "Rút tiền" });
            lst.Add(new IntString() { ID = 8, Name = "Treo" });
            lst.Add(new IntString() { ID = 9, Name = "Lãi" });//
            lst.Add(new IntString() { ID = 10, Name = "Phí" });//
            lst.Add(new IntString() { ID = 11, Name = "Trung gian" });
            lst.Add(new IntString() { ID = 12, Name = "Excel" });
            lst.Add(new IntString() { ID = 13, Name = "Khác" });
            lst.Add(new IntString() { ID = 14, Name = "Nộp quỹ chết" });
            lst.Add(new IntString() { ID = 15, Name = "Rút quỹ chết" });
            lst.Add(new IntString() { ID = 17, Name = "Khách Nợ" });
            lst.Add(new IntString() { ID = 18, Name = "Khách Có" });
            lst.Add(new IntString() { ID = 19, Name = "Hãng trừ tiền" });
            lst.Add(new IntString() { ID = 20, Name = "Chi phí" });//
            lst.Add(new IntString() { ID = 21, Name = "C.khoản|Nhận" });
            lst.Add(new IntString() { ID = 22, Name = "C.khoản|Chuyển" });
            lst.Add(new IntString() { ID = 23, Name = "T.Gian|Nhận" });
            lst.Add(new IntString() { ID = 24, Name = "T.Gian|Chuyển" });
            lst.Add(new IntString() { ID = 25, Name = "Thanh toán PNR" });
            lst.Add(new IntString() { ID = 26, Name = "Lương" });//
            lst.Add(new IntString() { ID = 27, Name = "BHXH" });//
            lst.Add(new IntString() { ID = 28, Name = "Điện" });//
            lst.Add(new IntString() { ID = 29, Name = "Nước" });//
            lst.Add(new IntString() { ID = 30, Name = "Hoàn vé" });
            lst.Add(new IntString() { ID = 31, Name = "Cước điện thoại" });//
            lst.Add(new IntString() { ID = 32, Name = "Tạm ứng" });
            lst.Add(new IntString() { ID = 33, Name = "Rút tiền" });
            return lst;
        }

        public static List<IntString> HinhThuc_NganHang(int LoaiKhachHang_NganHang)
        {
            List<IntString> lst = new List<IntString>();
            switch (LoaiKhachHang_NganHang)
            {
                case 0:
                    lst.Add(new IntString() { ID = 3, Name = "Tạm ứng" });
                    lst.Add(new IntString() { ID = 2, Name = "Trả Tạm ứng" });
                    break;
                case 1:
                    lst.Add(new IntString() { ID = 2, Name = "Nộp quỹ" });
                    lst.Add(new IntString() { ID = 3, Name = "Rút quỹ" });
                    lst.Add(new IntString() { ID = 14, Name = "Nộp quỹ chết" });
                    lst.Add(new IntString() { ID = 15, Name = "Rút quỹ chết" });
                    break;
                case 2:
                    lst.Add(new IntString() { ID = 2, Name = "Nộp tiền" });
                    lst.Add(new IntString() { ID = 3, Name = "Rút tiền" });
                    break;
                case 3:
                    lst.Add(new IntString() { ID = 4, Name = "Thanh toán vé" });
                    lst.Add(new IntString() { ID = 30, Name = "Hoàn vé" });
                    lst.Add(new IntString() { ID = 17, Name = "Khách Nợ" });
                    lst.Add(new IntString() { ID = 18, Name = "Khách Có" });
                    break;
                case 5:
                    lst.Add(new IntString() { ID = 21, Name = "C.khoản|Nhận" });
                    lst.Add(new IntString() { ID = 22, Name = "C.khoản|Chuyển" });
                    break;
                case 6:
                    lst.Add(new IntString() { ID = 6, Name = "Nộp tiền" });
                    lst.Add(new IntString() { ID = 7, Name = "Rút tiền" });
                    lst.Add(new IntString() { ID = 8, Name = "Treo" });
                    lst.Add(new IntString() { ID = 9, Name = "Lãi" });
                    lst.Add(new IntString() { ID = 10, Name = "Phí" });
                    lst.Add(new IntString() { ID = 20, Name = "Chi phí" });
                    break;
                case 7:
                    lst.Add(new IntString() { ID = 23, Name = "T.Gian|Nhận" });
                    lst.Add(new IntString() { ID = 24, Name = "T.Gian|Chuyển" });
                    break;
                case 8:
                    lst.Add(new IntString() { ID = 1, Name = "Nộp Tiền" });
                    lst.Add(new IntString() { ID = 33, Name = "Rút Tiền" });
                    break;
                case 9:
                    lst.Add(new IntString() { ID = 26, Name = "Lương" });
                    lst.Add(new IntString() { ID = 27, Name = "BHXH" });
                    lst.Add(new IntString() { ID = 28, Name = "Điện" });
                    lst.Add(new IntString() { ID = 29, Name = "Nước" });
                    lst.Add(new IntString() { ID = 31, Name = "Cước điện thoại" });
                    break;
            }
            return lst;
        }


        public static List<IntString> NganHangLoaiKhachHang(int LoaiKhachHang_NganHang, int NganHang = 0)
        {
            List<IntString> G = new List<IntString>();
            switch (LoaiKhachHang_NganHang)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    List<DaiLyO> khachHangOs = new DaiLyD().All().Where(w => w.LoaiKhachHang.Equals(LoaiKhachHang_NganHang)).ToList();
                    foreach (DaiLyO kh in khachHangOs)
                    {
                        if (kh.ID > 0)
                            G.Add(new IntString() { ID = kh.ID, Name = kh.Ten, Name2 = kh.MaDL, Loai = LoaiKhachHang_NganHang });
                    }
                    break;
                case 5:
                case 7:
                    List<NganHangO> nganHangOs = new NganHangD().All().Where(w => !w.ID.Equals(NganHang)).ToList();
                    foreach (NganHangO kh in nganHangOs)
                    {
                        G.Add(new IntString() { ID = kh.ID, Name = kh.Ten, Name2 = kh.TenTK });
                    }
                    break;
                case 8:
                    List<NCCO> nCCOs = new NCCD().DuLieu();
                    foreach (NCCO kh in nCCOs)
                    {
                        G.Add(new IntString() { ID = kh.ID, Name = kh.TenDayDu });
                    }
                    break;
                case 6:
                case 9:
                    G.Add(new IntString() { ID = -1, Name = "Khác", Name2 = "#" });
                    break;
            }
            return G;
        }
    }
    public class IntString
    {
        public int ID { set; get; }
        public int Loai { set; get; }
        public string Name { set; get; }
        public string Name2 { set; get; }
    }

    public class GiaTriBoolString
    {
        public bool BoolValue { set; get; }
        public string Name { set; get; }
    }
}
