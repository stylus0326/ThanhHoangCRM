using DataTransferObject;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class CTBanTongHopD : DataProcess
    {
		public List<O_CTBanTongHop> DuLieu1(DateTime dateTime)
		{
			Dictionary<string, string> dc = new Dictionary<string, string>();
			dc.Add("@Tungay", dateTime.ToString("yyyyMMdd"));
			return EXECSE<O_CTBanTongHop>("NgayBaoCao",dc);
		}
	}
}
