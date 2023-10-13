
namespace Mini_project_Note_App_np.Pages;

public partial class NotePage : ContentPage
{
	private readonly NoteViewModel _noteViewModel;
	public NotePage(NoteViewModel viewModel)
	{
		InitializeComponent();

		this._noteViewModel = viewModel;

		BindingContext = this._noteViewModel;

		titleEntry.Text = viewModel.CurrentNote?.Title;
		contentEditor.Text = viewModel.CurrentNote?.Content;
	}

	private async void OnBackButtonClicked(object sender, EventArgs e)
	{
        if (_noteViewModel.CurrentNote == null)
        {
            return; // Exit the method if there's no note.
        }

        // Update the title and content of the current note based on user input.
        _noteViewModel.CurrentNote.Title = titleEntry.Text;
        _noteViewModel.CurrentNote.Content = contentEditor.Text;

        // Use the ViewModel to add or update the note in the collection.
        _noteViewModel.AddOrUpdateNote(_noteViewModel.CurrentNote);

        // Navigate back to the previous page (MainPage in this case).
        await Navigation.PopAsync();
    }

}