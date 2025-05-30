
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AOOP_Homework2;

public partial class SubjectSelect : Window
{
    SubjectSelectViewModel ViewModel;
    StudentPageViewModel Reference;
    readonly StudentPage _studentPage;


    public SubjectSelect()
    {

    }
    public SubjectSelect(ref StudentPageViewModel viewModel, StudentPage studentPage)
    {
        InitializeComponent();
        DataContext = new SubjectSelectViewModel(ref viewModel);
        ViewModel = (SubjectSelectViewModel) DataContext;
        Reference = viewModel;
        _studentPage = studentPage;
        _studentPage.Closing += HandleWindowClosing;
        
    }

    private void AddSubject(object sender, RoutedEventArgs e)
    {
        if(ViewModel.Subject == null) return;
        Reference.RegisterCourse(ViewModel.Subject);
        this.Close();
    }

    private void HandleWindowClosing(object sender, WindowClosingEventArgs e)
    {
        Close();
    }
}