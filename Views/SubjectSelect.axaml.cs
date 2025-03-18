
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AOOP_Homework2;

public partial class SubjectSelect : Window
{
    SubjectSelectViewModel ViewModel;

    StudentPageViewModel Reference;
    public SubjectSelect(ref StudentPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = new SubjectSelectViewModel(ref viewModel);
        ViewModel = (SubjectSelectViewModel) DataContext;
        Reference = viewModel;

    }
    private void AddSubject(object sender, RoutedEventArgs e)
    {
        Reference.EnrolledSubjects.Add(ViewModel.Subject);
        Reference.AvailableSubects.Remove(ViewModel.Subject);
        this.Close();
    }
}