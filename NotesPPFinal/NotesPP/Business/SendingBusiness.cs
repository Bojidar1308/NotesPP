using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotesPP.Business
{
    class SendingBusiness
    {
        public void Send(string from, string password, string to, string subject, string body)
        {
            MailMessage mail = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Credentials = new NetworkCredential(from, password);
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
