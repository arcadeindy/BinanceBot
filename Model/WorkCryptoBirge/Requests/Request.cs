using Model.Requests.interfaces;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.Requests
{
    public class Request : IRequest
    {
        public string getSignature(string SecretKey, string query)
        {
            Encoding encoding = Encoding.UTF8;
            var keyByte = encoding.GetBytes(SecretKey);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(query));
                return encoding.GetString(hmacsha256.Hash);
            }
        }

        public async Task<string> webRequestAsync(string requestUrl, string method, string ApiKey)
        {
            return await Task.Run(() => webRequest(requestUrl, method, ApiKey));
        }
        public string webRequest(string requestUrl, string method, string ApiKey)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.Method = method;
                request.Timeout = 5000;
                if (ApiKey != null)
                {
                    request.Headers.Add("X-MBX-APIKEY", ApiKey);
                }

                var webResponse = request.GetResponse();
                var encoding = ASCIIEncoding.ASCII;

                string responseText = null;

                using (var reader = new System.IO.StreamReader(webResponse.GetResponseStream(), encoding))
                {
                    responseText = reader.ReadToEnd();
                }

                return responseText;
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    Encoding encoding = ASCIIEncoding.ASCII;
                    using (var reader = new System.IO.StreamReader(webEx.Response.GetResponseStream(), encoding))
                    {
                        string responseText = reader.ReadToEnd();
                        throw new Exception(responseText);
                    }
                }
                throw;
            }
            catch
            {
                return "Error";
            }
        }
    }
}
