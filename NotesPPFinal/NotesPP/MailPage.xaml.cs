using NotesPP.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NotesPP
{
    /// <summary>
    /// Страницата, чрез която ще се изпращат Е-майли.
    /// </summary>
     
    public sealed partial class MailPage : Page
    {
        /// <summary>
        /// Инстанция на класа <c>SendingBusiness</c> 
        /// с име <c>sendingBusiness</c>
        /// </summary>
        
        private SendingBusiness sendingBusiness = new SendingBusiness();

        /// <summary>
        /// Метод, който инициализира компонентите
        /// от XAML кода на страница <c>MailPage</c>.
        /// </summary>

        public MailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Метод, който се активира след натискане
        /// на бутон <c>Button_SendMessage</c> и изпраща
        /// данни на класа <c>SendingBusiness</c>, като
        /// получава част от тях от класа <c>MainPage</c>.
        /// </summary>

        private void Button_SendMessage(object sender, RoutedEventArgs e)
        {
            MainPage main = new MainPage();
            string subject = main.Subject;
            string body = main.Body;
            string from = SenderMail.Text;
            string password = SenderPass.Text;
            string to = RecieverMail.Text;
            sendingBusiness.Send(from, password, to, subject, body);
            Frame.Navigate(typeof(MainPage));
        }
    }
}
