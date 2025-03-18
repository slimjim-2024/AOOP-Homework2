using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2;

public partial class StudentPage : Window
{
    StudentPageViewModel ViewModel;
    Student currentStudent;
    public StudentPage(Student student)
    {
        currentStudent = student;
        InitializeComponent();
        DataContext = new StudentPageViewModel(currentStudent);
        ViewModel = (StudentPageViewModel)DataContext;
        ViewModel.StudentName = currentStudent.Name;
        ViewModel.StudentId = currentStudent.Id.ToString();
        // ViewModel.EnrolledSubjects = ViewModel.EnrolledSubjects.FindAll(sub => sub..Contains(currentStudent.Id));
    }
    private void Unenroll_button(object? sender, RoutedEventArgs e)
    {
        SubjectDisplay subject = ViewModel.SelectedSubject;
        ViewModel.AvailableSubects.Add(subject);
        ViewModel.EnrolledSubjects.Remove(subject);
    }
    private void Enroll_button(object? sender, RoutedEventArgs e)
    {
        SubjectSelect selectionDialog = new(ref ViewModel);
        selectionDialog.Show();
    }
}