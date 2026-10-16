using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotatkiWpf
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class AddNoteWindow : Window
    {
        // Właściwość, z której okno główne wyciągnie wpisany tekst
        public string NoteContent { get; private set; }

        public AddNoteWindow()
        {
            InitializeComponent();

            NoteContent = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtNoteContent.Text))
            {
                NoteContent = TxtNoteContent.Text;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Notatka nie może być pusta!");
            }
        }
    }
}
