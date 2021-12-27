using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class DataProcess
    {
        string TableName { set; get; }
        string CauTruyVan { set; get; }
        public DataProcess()
        {
            TableName = GetType().Name.Substring(2);
        }

        #region Thêm sửa xóa nhiều dòng
        public long ThemNhieu1Ban(List<Dictionary<string, object>> lstDuLieu, string TenBan = "")
        {
            if (TenBan.Length == 0)
                TenBan = TableName;
            if (lstDuLieu.Count < 30)
                return DataProvider.Create_Data_OneTable(lstDuLieu, TenBan);
            else
            {
                long b = 0;
                List<Dictionary<string, object>> G = new List<Dictionary<string, object>>();

                for (int i = 1; i < lstDuLieu.Count + 1; i++)
                {
                    G.Add(lstDuLieu[i - 1]);
                    if (i % 30 == 0 || i == lstDuLieu.Count)
                    {
                        b += DataProvider.Create_Data_OneTable(G, TenBan);
                        G.Clear();
                    }
                }
                return b;
            }
        }

        public long TaoChungTu()
        {
            return DataProvider.TaoChungTu();
        }

        public long SuaNhieu1Ban(List<Dictionary<string, object>> lstDuLieu, List<string> LstCauDieuKien, string TenBan = "")
        {
            if (TenBan.Length == 0)
                TenBan = TableName;
            if (lstDuLieu.Count < 30)
                return DataProvider.Update_Data_OneTable(lstDuLieu, LstCauDieuKien, TenBan);
            else
            {
                long b = 0;
                List<Dictionary<string, object>> G = new List<Dictionary<string, object>>();
                List<string> LstCauDieuKien1 = new List<string>();

                for (int i = 1; i < lstDuLieu.Count + 1; i++)
                {
                    G.Add(lstDuLieu[i - 1]);
                    LstCauDieuKien1.Add(LstCauDieuKien[i - 1]);
                    if (i % 30 == 0 || i == lstDuLieu.Count)
                    {
                        b += DataProvider.Update_Data_OneTable(G, LstCauDieuKien1, TenBan);
                        G.Clear();
                        LstCauDieuKien1.Clear();
                    }
                }
                return b;
            }
        }

        public long XoaNhieu1Ban(List<object> LstCauDieuKien, string TenBan = "")
        {
            if (TenBan.Length > 0)
                return DataProvider.Delete_Data_OneTable(LstCauDieuKien, TenBan);
            else
                return DataProvider.Delete_Data_OneTable(LstCauDieuKien, TableName);
        }

        public long XoaNhieu(List<string> LstTenBan, List<string> LstCauDieuKien)
        {
            return DataProvider.Delete_MultiTable(LstTenBan, LstCauDieuKien);
        }
        #endregion


        public bool DaTonTai(string CauDieuKien)
        {
            string CauTruyVan = string.Format("SELECT COUNT(*) FROM {0} {1}", TableName, CauDieuKien);
            return (int)DataProvider.Get_Value(CauTruyVan) > 0;
        }


        public bool KiemTraTonTai(int ID, string CotCanTim, object GiaTri, string DieuKienThem = "")
        {
            if (DieuKienThem.Length > 5)
                DieuKienThem = " AND " + DieuKienThem;
            string CauTruyVan = string.Format("SELECT COUNT(*) FROM {0} WHERE ID <> {1} and {2} = '@Value'{3}", TableName, ID, CotCanTim, DieuKienThem);
            return (int)DataProvider.Get_Value(CauTruyVan, GiaTri) > 0;
        }

        public List<T> LayDuLieu<T>(bool TuTaoCauTruyVan = true, string CauDieuKien = "", string CauTimKiemThem = "") where T : new()
        {
            T t = new T();
            if (TuTaoCauTruyVan)
            {
                string TenCot = string.Empty;
                foreach (System.Reflection.PropertyInfo propertyInfo in t.GetType().GetProperties())
                {
                    if (propertyInfo.Name == "End")
                        break;
                    TenCot += propertyInfo.Name + " ,";
                }
                CauTruyVan = string.Format("SELECT {0}{2} FROM {1} ", TenCot.Substring(0, TenCot.Length - 1), TableName, CauTimKiemThem) + CauDieuKien;

            }
            else
                CauTruyVan = CauDieuKien;
            return DataProvider.DataTable_To_ListOfObject<T>(DataProvider.Get_DataTable(CauTruyVan));
        }

        public long EXECUP(string name, Dictionary<string, string> Dc = null)
        {
            return DataProvider.RunUpStored_Procedure(name, Dc);
        }

        public List<T> EXECSE<T>(string name, Dictionary<string, string> Dc = null) where T : new()
        {
            return DataProvider.DataTable_To_ListOfObject<T>(DataProvider.RunSeStored_Procedure(name, Dc));
        }

        public T LayMotDongDonGian<T>(string CauDieuKien = "") where T : new()
        {
            string TenCot = string.Empty;
            T t = new T();
            foreach (System.Reflection.PropertyInfo propertyInfo in t.GetType().GetProperties())
            {
                if (propertyInfo.Name == "End")
                    break;
                TenCot += propertyInfo.Name + " ,";
            }
            CauTruyVan = string.Format("SELECT TOP 1 {0} FROM {1} ", TenCot.Substring(0, TenCot.Length - 1), TableName) + CauDieuKien;
            DataTable data = DataProvider.Get_DataTable(CauTruyVan);
            if (data.Rows.Count > 0)
                return DataProvider.DataTable_To_ListOfObject<T>(data)[0];
            else
                return new T();
        }

        public DateTime LayGioServer()
        {
            return (DateTime)DataProvider.Get_Value("SELECT GETDATE()");
        }

        //Dùng cho Công nợ
        public List<T> LayBanCongNo<T>(DataTable data, List<int> lstDaiLyID, List<long> lstDaiLyLuyKe, List<long> lstDaiLyLuyKeTong) where T : new()
        {
            return DataProvider.DataTable_To_ListOfObject_CN<T>(data, lstDaiLyID, lstDaiLyLuyKe, lstDaiLyLuyKeTong);
        }

        public List<T> LayBanCongNoKS<T>(DataTable data, List<int> lstDaiLyID, List<long> lstDaiLyLuyKe) where T : new()
        {
            return DataProvider.DataTable_To_ListOfObject_KS<T>(data, lstDaiLyID, lstDaiLyLuyKe);
        }

        public bool KiemTraDaTonTai(string CauDieuKien)
        {
            string CauTruyVan = string.Format("SELECT COUNT(*) FROM {0} {1}", TableName, CauDieuKien);
            return (int)DataProvider.Get_Value(CauTruyVan) > 0;
        }

        public int ChayCauTruyVan(string query)
        {
            return (int)DataProvider.RunOrderQuery(query);
        }

        public DataTable LayDataTable(string Query)
        {
            return DataProvider.Get_DataTable(Query);
        }

        public object GetOneVale(string Query)
        {
            return DataProvider.Get_Value(Query);
        }

        public long ThemMoi(Dictionary<string, object> data, bool insIdentity = false)
        {
            return DataProvider.Create_Data(data, TableName, insIdentity);
        }

        public long CapNhat(Dictionary<string, object> data, object id, string ChuoiGhep = " WHERE ID = {0}")
        {
            return DataProvider.Update_Data(data, TableName, string.Format(ChuoiGhep, id));
        }

        public long Xoa(object GiaTri, string CauDieuKien = "WHERE ID = {0}")
        {
            return DataProvider.Delete_Data(TableName, string.Format(CauDieuKien, GiaTri));
        }

        public long ThemMoiTuExcel<T>(List<T> lstDuLieu, string TbName) where T : new()
        {
            return DataProvider.CreateData_Procedure(lstDuLieu, TbName);
        }

        public long CapNhat_ThemNhieu(List<Dictionary<string, object>> lstDuLieu, List<string> LstTenBan, List<string> LstCauDieuKien, List<string> lstThem)
        {
            return DataProvider.Modify_MultiTable(lstDuLieu, LstTenBan, LstCauDieuKien, lstThem);
        }
    }
}
