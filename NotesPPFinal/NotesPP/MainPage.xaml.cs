using NotesPP.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
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
    /// Страницата, чрез която се правят, актуализират
    /// и изтриват бележките.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Инстанция на класа <c>SendingBusiness</c> 
        /// с име <c>sendingBusiness</c>
        /// </summary>

        private SendingBusiness sendingBusiness = new SendingBusiness();

        /// <summary>
        /// Инстанция на класа <c>NotesBusiness</c> 
        /// с име <c>notesBusiness</c>
        /// </summary>

        private NotesBusiness notesBusiness = new NotesBusiness();

        /// <summary>
        /// Метод, който инициализира компонентите
        /// от XAML кода на страница <c>MainPage</c>.
        /// </summary>

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Метод, който актуализира листата от бележки
        /// като получава данни от <c>NotesBusiness</c>.
        /// </summary>

        public void UpdateNotes()
        {
            NotesGrid.ItemsSource = notesBusiness.GetAllNotes();
        }

        /// <summary>
        /// Метод, който се активира след натискане
        /// на бутон <c>Button_Add</c> и изпраща
        /// данни на класа <c>NotesBusiness</c>, като ги
        /// получава от формите <c>NoteName</c> и <c>NoteContent</c>.
        /// </summary>

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Notes note = new Notes()
            {
                Name = NoteName.Text,
                Content = NoteContent.Text,
                AccUsername = "Admin"
            };
            notesBusiness.Add(note);
            UpdateNotes();
        }

        /// <summary>
        /// Метод, който се активира след натискане
        /// на бутон <c>Button_Delete</c> и изпраща
        /// данни на класа <c>NotesBusiness</c>, като ги
        /// получава от селектираните елементи от 
        /// листата <c>NotesGrid</c>.
        /// </summary>

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (NotesGrid.SelectedItems.Count > 0)
            {
                var item = (Notes)NotesGrid.SelectedItem;
                var id = int.Parse(item.Id.ToString());
                notesBusiness.Delete(id);
                UpdateNotes();
            }
        }

        /// <summary>
        /// Метод, който се активира след натискане
        /// на бутон <c>Button_Update</c> и актуализира
        /// данните в листата <c>NotesGrid</c>, като ги
        /// получава от формите <c>NoteName</c> и <c>NoteContent</c>.
        /// </summary>

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            if (NotesGrid.SelectedItems.Count > 0)
            {
                var item = (Notes)NotesGrid.SelectedItem;
                var id = int.Parse(item.Id.ToString());
                Notes update = notesBusiness.Get(id);
                NoteName.Text = update.Name;
                NoteContent.Text = update.Content;
                UpdateNotes();
            }
        }

        /// <summary>
        /// Метод, който се активира след натискане
        /// на бутон <c>Button_Send</c> и изпраща
        /// данни на класа <c>SendingBusiness</c>.
        /// </summary>

        private void Button_Send(object sender, RoutedEventArgs e)
        {
            string subject = NoteName.Text;
            string body = NoteContent.Text;
            string from = SenderMail.Text;
            string password = SenderPass.Text;
            string to = RecieverMail.Text;
            sendingBusiness.Send(from, password, to, subject, body);
        }
    }
}
