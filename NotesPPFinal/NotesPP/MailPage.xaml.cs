﻿using NotesPP.Business;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MailPage : Page
    {
        private SendingBusiness sendingBusiness = new SendingBusiness();

        public MailPage()
        {
            this.InitializeComponent();
        }

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
