using DataTransferObject;
using System.Collections.Generic;
using System.Reflection;

namespace DataAccessLayer
{
    public class D_NHOMQUYEN : DataProcess
    {
        public List<O_NHOMQUYEN> DuLieu()
        {
            return LayDuLieu<O_NHOMQUYEN>();
        }

        public O_NHOMQUYEN QuyenNhanVien(int id)
        {
            return LayMotDongDonGian<O_NHOMQUYEN>("WHERE ID = " + id);
        }

        public bool KiemTraTonTai(string Ten, int id)
        {
            return KiemTraDaTonTai(string.Format(@"WHERE Ten = N'{0}' and ID <> {1}", Ten, id));
        }

        public O_NHOMQUYEN QuyenAdmin()
        {
            O_NHOMQUYEN ob = new O_NHOMQUYEN();
            foreach (PropertyInfo propertyInfo in ob.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(bool))
                    propertyInfo.SetValue(ob, true, null);
            }
            return ob;
        }
    }
}
