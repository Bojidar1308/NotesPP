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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotesPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NotesBusiness notesBusiness = new NotesBusiness();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void UpdateNotes()
        {
            NotesGrid.ItemsSource = notesBusiness.GetAllNotes();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            Notes note = new Notes()
            {
                Name = NoteName.Text,
                Content = NoteContent.Text,
                AccUsername = "Pesho"
            };
            notesBusiness.Add(note);
            UpdateNotes();
        }

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

        private void Button_Send(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MailPage));
        }
    }
}
