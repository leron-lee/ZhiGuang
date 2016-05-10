using System;
using System.Web;
using System.Web.Mail;
public class mail
{
    private static HttpContext context = HttpContext.Current;
    public static string f_username()
    {
        string fig = "";
        object ob = new SqlHelper().ExecuteScalar("select f_username from mail where id = 1");
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string f_password()
    {
        string fig = "";
        object ob = new SqlHelper().ExecuteScalar("select f_password from mail where id = 1");
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string f_smtp()
    {
        string fig = "";
        object ob = new SqlHelper().ExecuteScalar("select f_smtp from mail where id = 1");
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static string j_username()
    {
        string fig = "";
        object ob = new SqlHelper().ExecuteScalar("select j_username from mail where id = 1");
        if (ob != null)
        {
            fig = ob.ToString();
        }
        return fig;
    }
    public static bool SendMail(string toMail, string subject, string body)
    {
        bool result;
        try
        {
            string username = mail.f_username();
            string password = mail.f_password();
            string smtp = mail.f_smtp();
            MailMessage myMail = new MailMessage();
            myMail.From = username;
            myMail.To = toMail;
            myMail.Cc = toMail;
            myMail.Bcc = toMail;
            myMail.Subject = subject;
            myMail.Body = body;
            myMail.BodyFormat = MailFormat.Html;
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", username);
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
            SmtpMail.SmtpServer = smtp;
            SmtpMail.Send(myMail);
            result = true;
        }
        catch (System.Exception)
        {
            result = false;
        }
        return result;
    }
}
