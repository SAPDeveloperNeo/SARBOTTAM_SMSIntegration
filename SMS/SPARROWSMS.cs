using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace SMS
{
    public class SPARROWSMS
    {
        /// <summary>
        /// Sends the Post request to send SMS
        /// </summary>
        /// <param name="from">Identity Provided By SparrowSMS</param>
        /// <param name="token">Token Provided By SparrowSMS</param>
        /// <param name="to">To Phone Number </param>
        /// <param name="text">Text Message to be sent</param>
        /// <returns>sms send response object in  json string format</returns>
        public string SendSMS(string from, string token, string to, string text)
        {
            var response = SparrowSmsIntegration.PostSendSMS(from, token, to, text);
            return response;
        }


        /// <summary>
        /// Sends the Post request to send SMS
        /// Method overloaded for SendSMS when no Identity From and Token is provided
        /// </summary>
        /// <param name="to">To Phone Number </param>
        /// <param name="text">Text Message to be sent</param>
        /// <returns>true when sms sent successfully and false when fails</returns>
        public bool SendSMS(string to, string text)
        {
            var response = SparrowSmsIntegration.PostSendSMS(SparrowSmsCredential.FromIdentity, SparrowSmsCredential.Token, to, text);

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var responseList = (IDictionary<string, object>)json_serializer.DeserializeObject(response);

            if (responseList != null)
            {
                var responseCode = (int)responseList["response_code"];
                if (responseCode == 200)
                    return true;
            }

            return false;
        }


        public string GetCredits(string token)
        {
            var response = SparrowSmsIntegration.GetCredits(token);
            return response;
        }


    }
}
