using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotesPP.Business
{
    /// <summary>
    /// Клас <c>SendingBusiness</c>, кoйто е част от бизнес логиката и
    /// отговаря за изпращането на Е-майл.
    /// </summary>
    
    class SendingBusiness
    {
        /// <summary>
        /// Метод, който изпраща Е-майл.
        /// </summary>
        /// <param name="from">Е-майл на човека който изпраща.</param>
        /// <param name="password">Парола за Е-майл на човека който изпраща.</param>
        /// <param name="to">Е-майл на човека който получава.</param>
        /// <param name="subject">Тема на съобщението което се изпраща.</param>
        /// <param name="body">Тяло на съобщението което се изпраща.</param>

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
