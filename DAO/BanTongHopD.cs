using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class BanTongHopD : DataProcess
    {
        public List<BanTongHopO> DuLieu1(DateTime dateTime)
        {
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("@Tungay", dateTime.ToString("yyyyMMdd"));
            return EXECSE<BanTongHopO>("BaoCao", dc);
        }

    }

    public class CTBanTongHopD : DataProcess
    {
		public List<CTBanTongHopO> DuLieu1(DateTime dateTime)
		{
			Dictionary<string, string> dc = new Dictionary<string, string>();
			dc.Add("@Tungay", dateTime.ToString("yyyyMMdd"));
			return EXECSE<CTBanTongHopO>("NgayBaoCao",dc);
		}
	}
}
