using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_KPI : DataProcess
    {

        public List<O_KPI> DuLieu(int ID, DateTime tu, DateTime den)
        {
            return LayDuLieu<O_KPI>(true, string.Format("WHERE NhanVien = {0} AND (convert(date, ThoiGian) BETWEEN '{1}' AND '{2}')", ID, tu.ToString("yyyyMMdd"), den.ToString("yyyyMMdd")));
        }

        public int DiemTinh(int ID, DateTime den)
        {
            return (int)GetOneVale(string.Format("SELECT 91 + COALESCE(sum(Diem),0) FROM KPI WHERE NhanVien = {0} AND (convert(date, ThoiGian) <= '{1}')", ID, den.ToString("yyyyMMdd")));
        }

        public int DiemTinh(int ID)
        {
            return (int)GetOneVale(string.Format("SELECT 91 + COALESCE(sum(Diem),0) FROM KPI WHERE NhanVien = {0} ", ID));
        }
    }
}
