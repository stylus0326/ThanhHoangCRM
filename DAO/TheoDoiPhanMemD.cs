using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class TheoDoiPhanMemD : DataProcess
    {
        public List<TheoDoiPhanMemO> LayDanhSach()
        {
            List<TheoDoiPhanMemO> lst = LayDuLieu<TheoDoiPhanMemO>(false, string.Format(string.Empty));
            return lst.Where(w => w.Ngay.ToString("ddMMyyyy") != DateTime.Now.ToString("ddMMyyyy")).ToList();
        }
    }
}
