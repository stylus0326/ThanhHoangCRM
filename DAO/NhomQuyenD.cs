using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataAccessLayer
{
    public class QuyenNhanVienD : DataProcess
    {
        public QuyenNhanVienD()
        {
            TableName = "NHOMQUYEN";
        }

        public List<QuyenNhanVienO> DuLieu()
        {
            return LayDuLieu<QuyenNhanVienO>();
        }

        public QuyenNhanVienO LayQuyenNhanVien(int id)
        {
            return LayMotDongDonGian<QuyenNhanVienO>("WHERE ID = " + id);
        }

        public bool KiemTraTonTai(string Ten, int id)
        {
            return KiemTraDaTonTai(string.Format(@"WHERE Ten = N'{0}' and ID <> {1}", Ten, id));
        }

        public QuyenNhanVienO QuyenAdmin()
        {
            QuyenNhanVienO ob = new QuyenNhanVienO();
            foreach (PropertyInfo propertyInfo in ob.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(bool))
                    propertyInfo.SetValue(ob, true, null);
            }
            return ob;
        }
    }
}
