using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mini_project_Note_App_np.Viewmodel
{
    public class NoteViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Note> NotesCollection { get; private set; }

        private Note _currentNote;
        public event PropertyChangedEventHandler PropertyChanged;

        public NoteViewModel()
        {
            NotesCollection = new ObservableCollection<Note>();
            NotesCollection = SeedNotes(3);
        }

        public Note CurrentNote
        {
            get => _currentNote;
            set
            {
                _currentNote = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddOrUpdateNote(Note note)
        {
            var existingNote = NotesCollection.FirstOrDefault(n => n.Id == note.Id);
            if (existingNote != null)
            {
                var index = NotesCollection.IndexOf(existingNote);
                NotesCollection[index] = note;
            }
            else
            {
                NotesCollection.Add(note);
            }
        }

        public void DeleteCurrentNote()
        {
            if (_currentNote != null)
            {
                NotesCollection.Remove(_currentNote);
            }
        }

        public int GetNextNoteId()
        {
            return (NotesCollection.Max(note => note.Id)) + 1;
        }

        private ObservableCollection<Note> SeedNotes(int amount)
        {
            var list = new ObservableCollection<Note>();
            for (int i = 0; i < amount; i++)
            {
                // id int, title string, content string 
                var note = new Note();
                note.Id = i;
                note.Title = $"note: {i}";
                note.Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc scelerisque erat ligula, et condimentum orci auctor et.
                    Aliquam dignissim dolor nulla, id mattis nunc tincidunt ut. Morbi nec enim ut felis pharetra posuere nec in augue. Aenean finibus risus id enim sagittis sagittis. 
                    Maecenas rhoncus dapibus vehicula. Etiam fermentum efficitur quam. Proin tempor nisl et sapien dapibus lobortis nec vitae massa. Fusce cursus accumsan venenatis.";
                list.Add(note);
            }
                

            return list;
        }
    }
}
