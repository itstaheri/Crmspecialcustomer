using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Frameworkes.Message.Sms
{
    public class SmsMessage : IMessage<SmsDetail>
    {
        public async Task SendMassege(SmsDetail model)
        {

            var request = (HttpWebRequest)WebRequest.Create("http://sms321.ir/webservice/rest/sms_send?");

            var postData = $"login_username=USERNAME&login_password=PASSWORD&receiver_number={model.Number}&note_arr[]={model.Message}&sender_number=10007666";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEndAsync();
        }
    }
}
