using Mini_project_Note_App_np.Model;
using Mini_project_Note_App_np.Pages;
using System.Collections;

namespace Mini_project_Note_App_np.Pages;

public partial class MainPage : ContentPage
{

    private readonly NoteViewModel viewModel;
	public MainPage()
	{
        InitializeComponent();

        viewModel = new NoteViewModel();

        this.BindingContext = viewModel;

        notesView.ItemsSource = viewModel.NotesCollection;
    }


    private async void OnAddNewNoteClickedAsync(object sender, EventArgs e)
    {
        var note = new Note { Id = viewModel.GetNextNoteId() };
        viewModel.CurrentNote = note;
        var notePage = new NotePage(viewModel);
        await Navigation.PushAsync(notePage);
    }
    private async void OnNoteSelected(object sender, EventArgs e) 
    {
        // Check if the sender of this event is a Label and that its context is a Note.
        if (sender is Label label && label.BindingContext is Note tappedNote)
        {
            // Set the CurrentNote in the ViewModel to the tappedNote.
            viewModel.CurrentNote = tappedNote;

            // Create a new MakeNotePage to edit/view the selected note and pass the ViewModel instance to it.
            var notePage = new NotePage(viewModel);

            // Navigate to the MakeNotePage.
            await Navigation.PushAsync(notePage);
        }
    }
}

