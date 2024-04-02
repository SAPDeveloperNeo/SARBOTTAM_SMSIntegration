using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;

namespace SMS
{
    public class SparrowSmsIntegration
    {
        /// <summary>
        /// Sends the Post request to send SMS
        /// </summary>
        /// <param name="from">Identity Provided By SparrowSMS</param>
        /// <param name="token">Token Provided By SparrowSMS</param>
        /// <param name="to">To Phone Number </param>
        /// <param name="text">Text Message to be sent</param>
        /// <returns>sms send response object in  json string format</returns>

        public static string PostSendSMS(string from, string token, string to, string text)
        {
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["from"] = from;
                values["token"] = token;
                values["to"] = to;
                values["text"] = text;
                var response = client.UploadValues("http://api.sparrowsms.com/v2/sms/", "Post", values);
                return Encoding.Default.GetString(response);
            }

        }

        public static string GetCredits(string token)
        {
            using (var client = new WebClient())
            {
                string parameters = "?";
                parameters += "token=" + token;
                var responseString = client.DownloadString("http://api.sparrowsms.com/v2/credit/" + parameters);
                return responseString;
            }
        }
       
    }
}
