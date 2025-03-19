using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2;

public partial class StudentPage : Window
{
    StudentPageViewModel ViewModel;
    Student currentStudent;

    //
    public StudentPage(Student student)
    {
        InitializeComponent();
        currentStudent = student;
        DataContext = new StudentPageViewModel(currentStudent);
        ViewModel = (StudentPageViewModel)DataContext;
        ViewModel.StudentName = currentStudent.Name;
        ViewModel.StudentId = currentStudent.Id.ToString();
    }

    //
    private void Unenroll_button(object? sender, RoutedEventArgs e)
    {
        if (ViewModel.SelectedSubject is null) return;

        Subject subject = ViewModel.SelectedSubject;
        ViewModel.AvailableSubjects.Add(subject);
        ViewModel.EnrolledSubjects.Remove(subject);
    }

    //
    private void Enroll_button(object? sender, RoutedEventArgs e)
    {
        SubjectSelect selectionDialog = new(ref ViewModel);
        selectionDialog.Show();
    }
}