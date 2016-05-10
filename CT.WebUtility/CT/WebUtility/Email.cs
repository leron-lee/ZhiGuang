namespace CT.WebUtility
{
    using System;
    using System.Net.Mail;
    using System.Text;
    using System.Configuration;
    using System.Net;
    public static class Email
    {
        public static readonly string SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"].ToString();
        public static readonly string SmtpClientUser = ConfigurationManager.AppSettings["SendAnwserEmail"].ToString();
        public static readonly string SmtpClientPWD = ConfigurationManager.AppSettings["SendAnwserPWD"].ToString();
        public static string Send(MailMessage msg)
        {
            string message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
            client.EnableSsl = false;//smtp服务器是否启用SSL加密
            client.Host = SmtpClientHost;
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential(SmtpClientUser,SmtpClientPWD);


            try
            {
                client.Send(msg);
                message = "success";
            }
            catch (SmtpException exception)
            {
                
                message = exception.Message;
            }
            finally
            {
                msg.To.Clear();
            }
            return message;
        }
    }
}

