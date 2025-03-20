using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AOOP_Homework2;

public partial class NewSubjectWindow : Window
{
    private TeacherPageViewModel _viewModel;

    public NewSubjectWindow(ref TeacherPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
    }

    private void CreateSubject_Click(object? sender, RoutedEventArgs e)
    {
        var name = NameTextBox.Text;
        var description = DescriptionTextBox.Text;
        
        if (!string.IsNullOrWhiteSpace(name))
        {
            _viewModel.CreateNewSubject(name, description);
            this.Close();
        }
    }
}