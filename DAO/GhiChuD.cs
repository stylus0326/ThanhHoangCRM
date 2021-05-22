using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class GhiChuD : DataProcess
    {
        public GhiChuD()
        {
            TableName = "GHICHU";
        }

        public List<GhiChuO> LayDanhSach()
        {
            return LayDuLieu<GhiChuO>(true, string.Format(@"WHERE ID > 7094"));
        }
    }
}
