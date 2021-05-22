using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class D_GHICHU : DataProcess
    {
        public List<O_GHICHU> LayDanhSach()
        {
            return LayDuLieu<O_GHICHU>(true, string.Format(@"WHERE ID > 7094"));
        }
    }
}
