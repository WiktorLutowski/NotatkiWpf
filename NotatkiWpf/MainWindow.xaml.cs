using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace NotatkiWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Note> _notes = [];
        private const string DefaultFileName = "notatki.json";

        public MainWindow()
        {
            InitializeComponent();
            NotesDataGrid.ItemsSource = _notes;

            LoadNotesOnStartup();
        }

        private void LoadNotesOnStartup()
        {
            if (File.Exists(DefaultFileName))
            {
                string jsonString = File.ReadAllText(DefaultFileName);
                var loadedNotes = JsonSerializer.Deserialize<ObservableCollection<Note>>(jsonString);
                if (loadedNotes != null)
                {
                    _notes = loadedNotes;
                    NotesDataGrid.ItemsSource = _notes;
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNoteWindow addWindow = new()
            {
                Owner = this
            };

            if (addWindow.ShowDialog() == true)
                _notes.Add(new Note { Content = addWindow.NoteContent });
        }

        private void BtnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Pliki JSON (*.json)|*.json",
                FileName = "notatki"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string jsonString = JsonSerializer.Serialize(_notes, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, jsonString);

                File.WriteAllText(DefaultFileName, jsonString);

                MessageBox.Show("Zapisano pomyślnie!");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button? button = (Button)sender;
            if (button != null)
            {
                Note? noteToDelete = (Note)button.DataContext;
                if (noteToDelete != null)
                    _notes.Remove(noteToDelete);
            }
        }
    }
}