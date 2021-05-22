using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace CRM
{
    public class ClsSMS
    {
        const string APIKey = "28A841519CC47537CC8EAC5E0CB310";//Login to eSMS.vn to get this";
        const string SecretKey = "15D9B7EA8A0D2024B57D76523075AF";//Login to eSMS.vn to get this";
        const string BrandName = "Thanh_Hoang";

        private string SendGetRequest(string RequestUrl)
        {
            Uri address = new Uri(RequestUrl);
            HttpWebRequest request;
            HttpWebResponse response = null;
            StreamReader reader;
            if (address == null) { throw new ArgumentNullException("address"); }
            try
            {
                request = WebRequest.Create(address) as HttpWebRequest;
                request.UserAgent = ".NET Sample";
                request.KeepAlive = false;
                request.Timeout = 15 * 1000;
                response = request.GetResponse() as HttpWebResponse;
                if (request.HaveResponse == true && response != null)
                {
                    reader = new StreamReader(response.GetResponseStream());
                    string result = reader.ReadToEnd();
                    result = result.Replace("</string>", string.Empty);
                    return result;
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        Console.WriteLine(
                            "The server returned '{0}' with the status code {1} ({2:d}).",
                            errorResponse.StatusDescription, errorResponse.StatusCode,
                            errorResponse.StatusCode);
                    }
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
            }
            return null;
        }

        public int Send(string phone, string message)
        {
            string URLz = "http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone=" + phone + "&Content=" + message + "&Brandname=" + BrandName + "&ApiKey=" + APIKey + "&SecretKey=" + SecretKey + "&IsUnicode=0&SmsType=2";
            string URLs = "http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone=" + phone + "&Content=" + message + "&ApiKey=" + APIKey + "&SecretKey=" + SecretKey + "&SmsType=2&Brandname=" + BrandName + string.Empty;
            string result = SendGetRequest(URLs);
            JObject ojb = JObject.Parse(result);
            int CodeResult = (int)ojb["CodeResult"];//trả về 100 là thành công
            //int CountRegenerate = (int)ojb["CountRegenerate"];
            //string SMSID = (string)ojb["SMSID"];//id của tin nhắn
            return CodeResult;
        }

        public long GetBalance()
        {
            string data = "http://rest.esms.vn/MainService.svc/json/GetBalance/" + APIKey + "/" + SecretKey + string.Empty;
            string result = SendGetRequest(data);
            JObject ojb = JObject.Parse(result);
            int CodeResult = (int)ojb["CodeResponse"];//trả về 100 là thành công
            int UserID = (int)ojb["UserID"];//id tài khoản
            long Balance = (long)ojb["Balance"];//tiền trong tài khoản
            return Balance;
        }
    }
}
