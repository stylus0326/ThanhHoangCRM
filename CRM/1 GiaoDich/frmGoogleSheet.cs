using DataAccessLayer;
using DataTransferObject;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CRM
{
    public partial class frmGoogleSheet : DevExpress.XtraEditors.XtraForm
    {
        static readonly string[] ScopesS = { SheetsService.Scope.Spreadsheets };
        static readonly string[] ScopesD = { SheetsService.Scope.Drive };
        static readonly string ApplicationName = "Google SpeadSheet API";
        static readonly string SpreadsheetId = "1t8x2TVkPszbOk4h5Lkvc-ZPFT8naNB2w3ZuRHpY4YIM";
        static DriveService DService = new DriveService();
        static SheetsService SService = new SheetsService();
        static List<O_DAILY> lstDaiLy = new List<O_DAILY>();
        static List<O_DAILY> lstCTV = new List<O_DAILY>();
        static List<O_DAILY> lstALL = new List<O_DAILY>();
        static List<O_DAILY> lstNV = new List<O_DAILY>();

        public frmGoogleSheet()
        {
            InitializeComponent();
        }

        private UserCredential Drive()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, "credentials.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    ScopesD,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;
        }

        private UserCredential Sheet()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials-Sheet.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, "credentials-Sheet.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    ScopesS,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            return credential;
        }

        void GetService()
        {
            UserCredential _Drive;
            _Drive = Drive();

            UserCredential _Sheet;
            _Sheet = Sheet();

            DService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _Drive,
                ApplicationName = ApplicationName
            });

            SService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _Sheet,
                ApplicationName = ApplicationName,
            });
        }

        void CopyFiles()
        {
            Google.Apis.Drive.v3.Data.File file1 = new Google.Apis.Drive.v3.Data.File();
            file1.Name = $"{DateTime.Now.ToString("yyyy-MM-dd HH-mm")} - Sao Lưu";
            FilesResource.CopyRequest updateRequest1 = DService.Files.Copy(file1, SpreadsheetId);
            updateRequest1.Fields = "id, parents, name";
            file1 = updateRequest1.Execute();

            FilesResource.UpdateRequest updateRequest = DService.Files.Update(new Google.Apis.Drive.v3.Data.File(), file1.Id);
            updateRequest.Fields = "id, parents";
            updateRequest.AddParents = "1i05huRMast4E7XPi3twLeAcWvTkdakJO";

            file1 = updateRequest.Execute();
        }

        void DaiLy()
        {
            string range1 = $"Đại lý!A:B";
            var valueRange = new ValueRange();
            var requestbody = new ClearValuesRequest();
            var request1 = SService.Spreadsheets.Values.Clear(requestbody, SpreadsheetId, range1);
            request1.Execute();

            List<IList<object>> lstList = new List<IList<object>>();

            for (int i = 0; i < lstDaiLy.Count; i++)
            {
                var objectList = new List<object>() { lstDaiLy[i].Ten, (i < lstCTV.Count - 1) ? lstCTV[i].Ten : string.Empty };
                lstList.Add(objectList);
            }
            valueRange.Values = lstList;

            var appendRequest = SService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range1);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            appendRequest.Execute();
        }

        List<string> NhanVienName = new List<string>();

        List<int> NhanVienID = new List<int>();

        void NhanVien()
        {
            string range1 = $"Đại lý!C:C";
            var request = SService.Spreadsheets.Values.Get(SpreadsheetId, range1);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            foreach (var row in values)
            {
                if (row.Count < 1)
                    continue;
                if (lstNV.Where(w => (w.TenDangNhapCty ?? "").TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Contains(row[0].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                {
                    NhanVienName.Add(row[0].ToString());
                    NhanVienID.Add(lstNV.Where(w => (w.TenDangNhapCty ?? "").TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Contains(row[0].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID);
                }
            }
        }

        void XulyVeThuong()
        {
            D_GIAODICH giaoDichD = new D_GIAODICH();

            for (int i = 0; i < NhanVienName.Count; i++)
            {
                List<O_GIAODICH> lstGiaoDich = giaoDichD.DuLieu($"TinhCongNo = 1 and LoaiGiaoDich in (4,13,14)  and LoaiKhachHang <> 3 and convert(date,NgayGD) > convert(date,getdate()-10) and IDKhachHang <> 87451 and NVGiaoDich in (0,{NhanVienID[i]})", false);
                String range = $"{NhanVienName[i]}!A3:E";
                var request = SService.Spreadsheets.Values.Get(SpreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                List<APISheet> lstAPI = new List<APISheet>();
                if (values != null)
                {
                    #region Cập nhật khách
                    foreach (var row in values)
                    {
                        #region Điều kiện
                        if (row.Count < 2)//có ít nhất 2 cột có dữ liệu
                            continue;
                        else if (row.Count > 1)
                        {
                            if (row[0].ToString() == string.Empty)//không mã chỗ số vé
                                continue;

                            if (row.Count == 5)
                                if (row[4].ToString() != string.Empty)//Xóa Giao dịch quá hạn
                                {
                                    if (DateTime.ParseExact(row[4].ToString().Split(':')[0].Replace("-", "/"), "dd/MM/yyyy", null).Subtract(DateTime.Now.AddDays(-7)).Days < 0)
                                        continue;
                                }

                            if (row.Count == 2)
                            {
                                if (row[1].ToString() == string.Empty)// Đại lý và CTV trống
                                {
                                    lstAPI.Add(aPI("Thiếu thông tin khách", row[0].ToString(), row[1].ToString(), string.Empty, string.Empty, string.Empty));
                                    continue;
                                }
                            }
                            else
                            {
                                if (row[1].ToString() == string.Empty && row[2].ToString() == string.Empty)// Đại lý và CTV trống
                                {
                                    lstAPI.Add(aPI("Thiếu thông tin khách", row[0].ToString(), row[1].ToString(), row[2].ToString(), (row.Count == 4) ? row[3].ToString() : string.Empty, string.Empty));
                                    continue;
                                }
                            }
                        }
                        #endregion

                        List<O_GIAODICH> GiaoDinhTamLuu = lstGiaoDich.Where(w => w.MaCho.Replace(" ", string.Empty).Equals(row[0].ToString().ToUpper().Replace(" ", string.Empty)) || (w.SoVeVN ?? string.Empty).Replace(" ", string.Empty).Equals(row[0].ToString().Replace(" ", string.Empty))).ToList();

                        if (GiaoDinhTamLuu.Count > 0)// Mã chỗ có tồn tại theo điều kiện
                        {
                            O_GIAODICH ac = new O_GIAODICH();
                            ac.NVGiaoDich = NhanVienID[i];
                            ac.GhiChu = row.Count > 3 ? row[3].ToString() : string.Empty;

                            if (row[1].ToString() != string.Empty)// tìm DL theo sheet
                            {
                                if (lstDaiLy.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[1].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                                {
                                    ac.IDKhachHang = lstDaiLy.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[1].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID;
                                    ac.LoaiKhachHang = 1;
                                }
                            }
                            else// tìm CTV theo sheet
                            {
                                if (lstCTV.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[2].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                                {
                                    ac.IDKhachHang = lstCTV.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[2].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID;
                                    ac.LoaiKhachHang = 2;
                                }
                            }

                            if (ac.NVGiaoDich == GiaoDinhTamLuu[0].NVGiaoDich && ac.IDKhachHang == GiaoDinhTamLuu[0].IDKhachHang)
                                continue;

                            if (ac.LoaiKhachHang > 0 && ac.IDKhachHang > 0)//Thay đổi dữ liệu trên hệ thống
                            {
                                string GhiChuTam = string.Format("GExcel : [{1}] {0} - ", row[0].ToString(), NhanVienName[i]);
                                if (ac.IDKhachHang != GiaoDinhTamLuu[0].IDKhachHang)
                                    GhiChuTam += string.Format("[{0} => {1}] ", lstALL.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].IDKhachHang)).Count() > 0 ? lstALL.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].IDKhachHang)).ToList()[0].Ten : string.Empty, lstALL.Where(w => w.ID.Equals(ac.IDKhachHang)).ToList()[0].Ten);

                                GhiChuTam += "[";

                                if (GhiChuTam == string.Format("GExcel : [{1}] {0} - [", row[0].ToString(), NhanVienName[i]) && ac.NVGiaoDich == GiaoDinhTamLuu[0].NVGiaoDich)
                                    continue;

                                for (int u = 0; u < GiaoDinhTamLuu.Count; u++)
                                {
                                    GiaoDinhTamLuu[u].GhiChu = ac.GhiChu;
                                    GiaoDinhTamLuu[u].NVGiaoDich = ac.NVGiaoDich;
                                    GiaoDinhTamLuu[u].LoaiKhachHang = ac.LoaiKhachHang;
                                    GiaoDinhTamLuu[u].IDKhachHang = ac.IDKhachHang;
                                    GhiChuTam += GiaoDinhTamLuu[u].ID;
                                    GhiChuTam += (u != GiaoDinhTamLuu.Count - 1) ? ", " : "]";
                                }

                                if (giaoDichD.ThucThiSua(GiaoDinhTamLuu) > 0)
                                {
                                    Dictionary<string, object> dic1 = new Dictionary<string, object>();
                                    dic1.Add("FormName", "Hệ thống");
                                    dic1.Add("MaCho", row[0].ToString());
                                    dic1.Add("NoiDung", GhiChuTam);
                                    dic1.Add("LoaiKhachHang", 0);
                                    dic1.Add("Ma", 0);
                                    new D_LS_GIAODICH().ThemMoi(dic1);
                                }
                            }
                            else
                                lstAPI.Add(aPI("Không tìm thấy khách", row[0].ToString(), row[1].ToString(), row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 3 ? row[3].ToString() : string.Empty, row.Count > 4 ? row[4].ToString() : string.Empty));
                        }
                        else
                            lstAPI.Add(aPI("Không tìm thấy vé", row[0].ToString(), row[1].ToString(), row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 3 ? row[3].ToString() : string.Empty, row.Count > 4 ? row[4].ToString() : string.Empty));
                    }
                    #endregion

                    #region Xóa 
                    var requestbody = new ClearValuesRequest();
                    var request1 = SService.Spreadsheets.Values.Clear(requestbody, SpreadsheetId, range);
                    var Drequest1 = request1.Execute();
                    #endregion

                    #region Thêm lại các dòng lỗi
                    if (lstAPI.Count > 0)
                    {
                        var valueRange = new ValueRange();

                        List<IList<object>> lstList = new List<IList<object>>();
                        foreach (APISheet aPI in lstAPI)
                        {
                            var objectList = new List<object>() { aPI.MaCho, aPI.DaiLy, aPI.CTV, aPI.GhiChu, aPI.GhiChuHeThong };
                            lstList.Add(objectList);
                        }
                        valueRange.Values = lstList;

                        var appendRequest = SService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                        var appendResponse = appendRequest.Execute();
                        lstAPI.Clear();
                    }
                    #endregion
                }
            }
        }

        void XuLyVeHoanBk()
        {
            D_GIAODICH giaoDichD = new D_GIAODICH();

            for (int i = 0; i < NhanVienName.Count; i++)
            {
                String range = $"{NhanVienName[i]}!F3:L";
                var request = SService.Spreadsheets.Values.Get(SpreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                List<APISheet> lstAPI = new List<APISheet>();
                if (values != null)
                {
                    List<string> str = new List<string>();
                    foreach (var row in values)
                    {
                        if (row.Count < 1)//có ít nhất 2 cột có dữ liệu
                            continue;
                        if (row[0].ToString() == string.Empty)//không mã chỗ số vé
                            continue;
                        str.Add(row[0].ToString());
                    }

                    if (str.Count < 0)
                        return;

                    List<O_GIAODICH> lstGiaoDich = giaoDichD.DuLieu($"LoaiGiaoDich = 9 and LoaiKhachHang <> 3 and SoVeVN in ('{String.Join("' ,'", str.ToArray())}')", false);

                    //List<GiaoDichO> lstGiaoDich = giaoDichD.DuLieu($"TinhCongNo = 0 and LoaiGiaoDich = 9 and LoaiKhachHang <> 3 and NVGiaoDich in (0,{NhanVienID[i]})", false);
                    //List<GiaoDichO> DaNhan2 = giaoDichD.DuLieu($"TinhCongNo = 1 and LoaiGiaoDich = 9 and LoaiKhachHang <> 3 and NVGiaoDich in (0,{NhanVienID[i]})", false);

                    foreach (var row in values)
                    {
                        if (row.Count < 1)//có ít nhất 2 cột có dữ liệu
                            continue;
                        if (row[0].ToString() == string.Empty)//không mã chỗ số vé
                            continue;
                        List<O_GIAODICH> GiaoDinhTamLuu = lstGiaoDich.Where(w => w.SoVeVN.Replace(" ", "").Equals(row[0].ToString().Replace(" ", "")) && !w.TinhCongNo).ToList();
                        List<O_GIAODICH> DaNhan = lstGiaoDich.Where(w => w.SoVeVN.Replace(" ", "").Equals(row[0].ToString().Replace(" ", "")) && w.TinhCongNo).ToList();

                        if (GiaoDinhTamLuu.Count == 1)// Mã chỗ có tồn tại theo điều kiện
                        {
                            O_GIAODICH ac = new O_GIAODICH();
                            ac.NVGiaoDich = NhanVienID[i];
                            ac.LoaiKhachHang = 0;
                            ac.GhiChu = row.Count > 5 ? row[5].ToString() : string.Empty;
                            ac.GiaHeThong = row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : -1;
                            ac.GiaHoan = row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : -1;

                            if (GiaoDinhTamLuu[0].NVGiaoDich != NhanVienID[i] && GiaoDinhTamLuu[0].NVGiaoDich != 0)
                            {
                                lstAPI.Add(aPI($"Vé của {lstNV.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].NVGiaoDich)).ToList()[0].TenDangNhapCty}", row[0].ToString(), row.Count > 1 ? row[1].ToString() : string.Empty, row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 5 ? row[5].ToString() : string.Empty, row.Count > 6 ? row[6].ToString() : string.Empty, row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : 0, row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : 0));
                                continue;
                            }// Vé đã có người nhận


                            if (row[1].ToString() != string.Empty)// tìm DL theo sheet
                            {
                                if (lstDaiLy.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[1].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                                {
                                    ac.IDKhachHang = lstDaiLy.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[1].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID;
                                    ac.LoaiKhachHang = 1;
                                }
                                if (ac.LoaiKhachHang == 0)
                                {
                                    lstAPI.Add(aPI("Không tìm thấy khách", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[5].ToString(), row[6].ToString(), ac.GiaHeThong, ac.GiaHoan));
                                    continue;
                                }
                            }
                            else if (row.Count > 3)
                                if (row[2].ToString() != string.Empty)// tìm CTV theo sheet
                                {
                                    if (lstCTV.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[2].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                                    {
                                        ac.IDKhachHang = lstCTV.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[2].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID;
                                        ac.LoaiKhachHang = 2;
                                    }

                                    if (ac.LoaiKhachHang == 0)
                                    {
                                        lstAPI.Add(aPI("Không tìm thấy khách", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[5].ToString(), row[6].ToString(), ac.GiaHeThong, ac.GiaHoan));
                                        continue;
                                    }
                                }

                            string GhiChuTam = string.Format("GExcel Hoàn : [{1}] {0} - ", row[0].ToString(), NhanVienName[i]);

                            if (ac.LoaiKhachHang > 0 && ac.IDKhachHang != GiaoDinhTamLuu[0].IDKhachHang)
                                GhiChuTam += string.Format("[{0} => {1}] ", lstALL.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].IDKhachHang)).Count() > 0 ? lstALL.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].IDKhachHang)).ToList()[0].Ten : string.Empty, lstALL.Where(w => w.ID.Equals(ac.IDKhachHang)).ToList()[0].Ten);
                            if (ac.GiaHeThong != -1 && ac.GiaHeThong != GiaoDinhTamLuu[0].GiaHeThong)
                                GhiChuTam += string.Format("[Phí hoàn {0} => {1}] ", GiaoDinhTamLuu[0].GiaHeThong.ToString("#,##0"), ac.GiaHeThong.ToString("#,##0"));
                            if (ac.GiaHoan != -1 && ac.GiaHoan != GiaoDinhTamLuu[0].GiaHoan)
                                GhiChuTam += string.Format("[Giá hoàn {0} => {1}] ", GiaoDinhTamLuu[0].GiaHoan.ToString("#,##0"), ac.GiaHoan.ToString("#,##0"));
                            GhiChuTam += "[";

                            if (GhiChuTam == string.Format("GExcel Hoàn : [{1}] {0} - [", row[0].ToString(), NhanVienName[i]) && ac.NVGiaoDich == GiaoDinhTamLuu[0].NVGiaoDich)
                                continue;

                            for (int u = 0; u < GiaoDinhTamLuu.Count; u++)
                            {
                                GiaoDinhTamLuu[u].NVGiaoDich = ac.NVGiaoDich;
                                GiaoDinhTamLuu[u].GhiChu = ac.GhiChu;
                                if (ac.LoaiKhachHang > 0)
                                {
                                    GiaoDinhTamLuu[u].LoaiKhachHang = ac.LoaiKhachHang;
                                    GiaoDinhTamLuu[u].IDKhachHang = ac.IDKhachHang;
                                }
                                if (ac.GiaHeThong > 10000)
                                    GiaoDinhTamLuu[u].GiaHeThong = ac.GiaHeThong;
                                if (ac.GiaHoan > 10000)
                                    GiaoDinhTamLuu[u].GiaHoan = ac.GiaHoan;

                                GhiChuTam += GiaoDinhTamLuu[u].ID;
                                GhiChuTam += (u != GiaoDinhTamLuu.Count - 1) ? ", " : "]";

                            }

                            if (giaoDichD.ThucThiSua(GiaoDinhTamLuu) > 0)
                            {
                                Dictionary<string, object> dic1 = new Dictionary<string, object>();
                                dic1.Add("FormName", "Hệ thống");
                                dic1.Add("MaCho", row[0].ToString());
                                dic1.Add("NoiDung", GhiChuTam);
                                dic1.Add("LoaiKhachHang", 0);
                                dic1.Add("Ma", 0);
                                new D_LS_GIAODICH().ThemMoi(dic1);
                            }
                        }
                        else if (GiaoDinhTamLuu.Count == 0)
                        {
                            if (DaNhan.Count > 0)
                            {
                                if (DaNhan[0].NVGiaoDich != NhanVienID[i] && DaNhan[0].NVGiaoDich != 0)
                                    lstAPI.Add(aPI($"Vé đã nhận cho {lstNV.Where(w => w.ID.Equals(DaNhan[0].NVGiaoDich)).ToList()[0].TenDangNhapCty}", row[0].ToString(), row.Count > 1 ? row[1].ToString() : string.Empty, row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 5 ? row[5].ToString() : string.Empty, row.Count > 6 ? row[6].ToString() : string.Empty, row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : 0, row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : 0));
                            }
                            else
                                lstAPI.Add(aPI("Không tìm thấy hoàn", row[0].ToString(), row.Count > 1 ? row[1].ToString() : string.Empty, row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 5 ? row[5].ToString() : string.Empty, row.Count > 6 ? row[6].ToString() : string.Empty, row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : 0, row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : 0));
                        }
                        else
                            lstAPI.Add(aPI("Trên 2 giao dịch", row[0].ToString(), row.Count > 1 ? row[1].ToString() : string.Empty, row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 5 ? row[5].ToString() : string.Empty, row.Count > 6 ? row[6].ToString() : string.Empty, row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : 0, row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : 0));
                    }

                    #region Xóa 
                    var requestbody = new ClearValuesRequest();
                    var request1 = SService.Spreadsheets.Values.Clear(requestbody, SpreadsheetId, range);
                    var Drequest1 = request1.Execute();
                    #endregion

                    #region Thêm lại các dòng lỗi
                    if (lstAPI.Count > 0)
                    {
                        var valueRange = new ValueRange();

                        List<IList<object>> lstList = new List<IList<object>>();
                        foreach (APISheet aPI in lstAPI)
                        {
                            var objectList = new List<object>() { aPI.MaCho, aPI.DaiLy, aPI.CTV, aPI.PhiHoanDaiLy, aPI.GiaHoanDaiLy, aPI.GhiChu, aPI.GhiChuHeThong };
                            lstList.Add(objectList);
                        }
                        valueRange.Values = lstList;

                        var appendRequest = SService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                        var appendResponse = appendRequest.Execute();
                        lstAPI.Clear();
                    }
                    #endregion
                }
            }
        }

        void XuLyVeHoanKt()
        {
            D_GIAODICH giaoDichD = new D_GIAODICH();

            List<O_GIAODICH> lstGiaoDich = giaoDichD.DuLieu($"TinhCongNo = 0 and LoaiGiaoDich = 9 and LoaiKhachHang <> 3", false);
            String range = $"Kế toán CN!A2:I";
            var request = SService.Spreadsheets.Values.Get(SpreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            List<APISheet> lstAPI = new List<APISheet>();
            if (values != null)
            {
                foreach (var row in values)
                {
                    if (row.Count < 1)//có ít nhất 2 cột có dữ liệu
                        continue;
                    if (row[0].ToString() == string.Empty)//không mã chỗ số vé
                        continue;
                    List<O_GIAODICH> GiaoDinhTamLuu = lstGiaoDich.Where(w => (w.SoVeVN ?? string.Empty).Replace(" ", string.Empty).Equals(row[0].ToString().Replace(" ", string.Empty))).ToList();

                    if (GiaoDinhTamLuu.Count == 1)// Mã chỗ có tồn tại theo điều kiện
                    {
                        O_GIAODICH ac = new O_GIAODICH();
                        ac.LoaiKhachHang = 0;

                        ac.GhiChu = row.Count > 7 ? row[7].ToString() : string.Empty;
                        ac.GiaHeThong = row.Count > 3 ? XuLyDuLieu.ConvertStringToLong(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : -1;
                        ac.GiaHoan = row.Count > 4 ? XuLyDuLieu.ConvertStringToLong(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : -1;
                        ac.GiaNet = row.Count > 5 ? XuLyDuLieu.ConvertStringToLong(row[5].ToString() == string.Empty ? "0" : row[5].ToString()) : -1;
                        ac.HangHoan = row.Count > 6 ? XuLyDuLieu.ConvertStringToLong(row[6].ToString() == string.Empty ? "0" : row[6].ToString()) : -1;

                        if (row.Count > 1)
                        {
                            if (row[1].ToString() != string.Empty)// tìm DL theo sheet
                            {
                                if (lstDaiLy.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[1].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                                {
                                    ac.IDKhachHang = lstDaiLy.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[1].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID;
                                    ac.LoaiKhachHang = 1;
                                }
                                if (ac.LoaiKhachHang == 0)
                                {
                                    lstAPI.Add(aPI("Không tìm thấy khách", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[5].ToString(), row[6].ToString(), ac.GiaHeThong, ac.GiaHoan));
                                    continue;
                                }
                            }
                            else if (row.Count > 3)
                                if (row[2].ToString() != string.Empty)// tìm CTV theo sheet
                                {
                                    if (lstCTV.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[2].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).Count() > 0)
                                    {
                                        ac.IDKhachHang = lstCTV.Where(w => w.Ten.TrimEnd().ToLower().Normalize(NormalizationForm.FormKD).Equals(row[2].ToString().TrimEnd().ToLower().Normalize(NormalizationForm.FormKD))).First().ID;
                                        ac.LoaiKhachHang = 2;
                                    }

                                    if (ac.LoaiKhachHang == 0)
                                    {
                                        lstAPI.Add(aPI("Không tìm thấy khách", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[5].ToString(), row[6].ToString(), ac.GiaHeThong, ac.GiaHoan));
                                        continue;
                                    }
                                }

                        }

                        string GhiChuTam = string.Format("GExcel Hoàn : Nhận hoàn [{0}] - ", row[0].ToString());

                        if (ac.LoaiKhachHang > 0 && ac.IDKhachHang != GiaoDinhTamLuu[0].IDKhachHang)
                            GhiChuTam += string.Format("[{0} => {1}] ", lstALL.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].IDKhachHang)).Count() > 0 ? lstALL.Where(w => w.ID.Equals(GiaoDinhTamLuu[0].IDKhachHang)).ToList()[0].Ten : string.Empty, lstALL.Where(w => w.ID.Equals(ac.IDKhachHang)).ToList()[0].Ten);
                        if (ac.GiaHeThong > 10 && ac.GiaHeThong != GiaoDinhTamLuu[0].GiaHeThong)
                            GhiChuTam += string.Format("[Phí hoàn {0} => {1}] ", GiaoDinhTamLuu[0].GiaHeThong.ToString("#,##0"), ac.GiaHeThong.ToString("#,##0"));
                        if (ac.GiaHoan > 10 && ac.GiaHoan != GiaoDinhTamLuu[0].GiaHoan)
                            GhiChuTam += string.Format("[Giá hoàn {0} => {1}] ", GiaoDinhTamLuu[0].GiaHoan.ToString("#,##0"), ac.GiaHoan.ToString("#,##0"));
                        if (ac.GiaNet > 10 && ac.GiaNet != GiaoDinhTamLuu[0].GiaNet)
                            GhiChuTam += string.Format("[Phí hãng {0} => {1}] ", GiaoDinhTamLuu[0].GiaNet.ToString("#,##0"), ac.GiaNet.ToString("#,##0"));
                        if (ac.HangHoan > 10 && ac.HangHoan != GiaoDinhTamLuu[0].HangHoan)
                            GhiChuTam += string.Format("[Hãng hoàn {0} => {1}] ", GiaoDinhTamLuu[0].HangHoan.ToString("#,##0"), ac.HangHoan.ToString("#,##0"));

                        GhiChuTam += "[";

                        for (int u = 0; u < GiaoDinhTamLuu.Count; u++)
                        {
                            GiaoDinhTamLuu[u].TinhCongNo = true;
                            if (ac.LoaiKhachHang > 0)
                            {
                                GiaoDinhTamLuu[u].LoaiKhachHang = ac.LoaiKhachHang;
                                GiaoDinhTamLuu[u].IDKhachHang = ac.IDKhachHang;
                            }
                            if (ac.GiaHeThong > 10)
                                GiaoDinhTamLuu[u].GiaHeThong = ac.GiaHeThong;
                            if (ac.GiaHoan > 10)
                                GiaoDinhTamLuu[u].GiaHoan = ac.GiaHoan;
                            if (ac.GiaNet > 10)
                                GiaoDinhTamLuu[u].GiaNet = ac.GiaNet;
                            if (ac.HangHoan > 100)
                                GiaoDinhTamLuu[u].HangHoan = ac.HangHoan;

                            GhiChuTam += GiaoDinhTamLuu[u].ID;
                            GhiChuTam += (u != GiaoDinhTamLuu.Count - 1) ? ", " : "]";
                        }

                        if (giaoDichD.ThucThiSua(GiaoDinhTamLuu) > 0)
                        {
                            Dictionary<string, object> dic1 = new Dictionary<string, object>();
                            dic1.Add("FormName", "Hệ thống");
                            dic1.Add("MaCho", row[0].ToString());
                            dic1.Add("NoiDung", GhiChuTam);
                            dic1.Add("LoaiKhachHang", 0);
                            dic1.Add("Ma", 0);
                            new D_LS_GIAODICH().ThemMoi(dic1);
                        }
                    }
                    else if (GiaoDinhTamLuu.Count == 0)
                        lstAPI.Add(aPI("Không tìm thấy hoàn", row[0].ToString(), row.Count > 1 ? row[1].ToString() : string.Empty, row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 7 ? row[7].ToString() : string.Empty, row.Count > 7 ? row[7].ToString() : string.Empty, row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : 0, row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : 0, row.Count > 5 ? long.Parse(row[5].ToString() == string.Empty ? "0" : row[5].ToString()) : 0, row.Count > 6 ? long.Parse(row[6].ToString() == string.Empty ? "0" : row[6].ToString()) : 0));
                    else
                        lstAPI.Add(aPI("Trên 2 giao dịch", row[0].ToString(), row.Count > 1 ? row[1].ToString() : string.Empty, row.Count > 2 ? row[2].ToString() : string.Empty, row.Count > 7 ? row[7].ToString() : string.Empty, row.Count > 7 ? row[7].ToString() : string.Empty, row.Count > 3 ? long.Parse(row[3].ToString() == string.Empty ? "0" : row[3].ToString()) : 0, row.Count > 4 ? long.Parse(row[4].ToString() == string.Empty ? "0" : row[4].ToString()) : 0, row.Count > 5 ? long.Parse(row[5].ToString() == string.Empty ? "0" : row[5].ToString()) : 0, row.Count > 6 ? long.Parse(row[6].ToString() == string.Empty ? "0" : row[6].ToString()) : 0));
                }

                #region Xóa 
                var requestbody = new ClearValuesRequest();
                var request1 = SService.Spreadsheets.Values.Clear(requestbody, SpreadsheetId, range);
                var Drequest1 = request1.Execute();
                #endregion

                #region Thêm lại các dòng lỗi
                if (lstAPI.Count > 0)
                {
                    var valueRange = new ValueRange();

                    List<IList<object>> lstList = new List<IList<object>>();
                    foreach (APISheet aPI in lstAPI)
                    {
                        var objectList = new List<object>() { aPI.MaCho, aPI.DaiLy, aPI.CTV, aPI.PhiHoanDaiLy, aPI.GiaHoanDaiLy, aPI.PhiHoan, aPI.GiaHoan, aPI.GhiChu, aPI.GhiChuHeThong };
                        lstList.Add(objectList);
                    }
                    valueRange.Values = lstList;

                    var appendRequest = SService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                    appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var appendResponse = appendRequest.Execute();
                    lstAPI.Clear();
                }
                #endregion
            }
        }

        private void frmGoogleSheet_Load(object sender, System.EventArgs e)
        {
            if (!ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.ShowWaitForm();
            lstALL = new D_DAILY().All();
            lstCTV = lstALL.Where(w => w.LoaiKhachHang.Equals(2)).OrderBy(w => w.Ten).ToList();
            lstDaiLy = lstALL.Where(w => w.LoaiKhachHang.Equals(1)).OrderBy(w => w.Ten).ToList();
            lstNV = lstALL.Where(w => w.LoaiKhachHang.Equals(0) && !w.Nghi).OrderBy(w => w.Ten).ToList();
            GetService();
            CopyFiles();
            NhanVien();
            DaiLy();
            XulyVeThuong();
            XuLyVeHoanBk();
            XuLyVeHoanKt();
            if (ClsChucNang.wait.IsSplashFormVisible)
                ClsChucNang.wait.CloseWaitForm();
            Close();
        }
        APISheet aPI(string GhiChuThem, string MaCho, string DaiLy, string CTV, string GhiChu, string GhiChuOLD, long PhiHoanDaiLy = 0, long GiaHoanDaiLy = 0, long PhiHoan = 0, long GiaHoan = 0)
        {
            APISheet ap = new APISheet();
            ap.MaCho = MaCho;
            ap.CTV = CTV;
            ap.DaiLy = DaiLy;
            ap.GhiChu = GhiChu;
            if (string.IsNullOrEmpty(GhiChuOLD) || GhiChuOLD == "Hệ thống tự thêm")
                ap.GhiChuHeThong = DateTime.Now.ToString("dd/MM/yyyy: ") + GhiChuThem;
            else
                ap.GhiChuHeThong = GhiChuOLD.Replace("; ", ";").Split(';')[0] + "; " + DateTime.Now.ToString("dd/MM/yyyy: ") + GhiChuThem;
            ap.PhiHoanDaiLy = PhiHoanDaiLy == 0 ? 0 : PhiHoanDaiLy;
            ap.GiaHoanDaiLy = GiaHoanDaiLy == 0 ? 0 : GiaHoanDaiLy;
            ap.PhiHoan = PhiHoan == 0 ? 0 : PhiHoan;
            ap.GiaHoan = GiaHoan == 0 ? 0 : GiaHoan;
            return ap;
        }
    }

    class APISheet
    {
        public string MaCho { set; get; } = string.Empty;
        public string DaiLy { set; get; } = string.Empty;
        public string CTV { set; get; } = string.Empty;
        public string GhiChu { set; get; } = string.Empty;
        public string GhiChuHeThong { set; get; } = string.Empty;
        public long PhiHoanDaiLy { set; get; } = 0;
        public long GiaHoanDaiLy { set; get; } = 0;
        public long PhiHoan { set; get; } = 0;
        public long GiaHoan { set; get; } = 0;
    }
}