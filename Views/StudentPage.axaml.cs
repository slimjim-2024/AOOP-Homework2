using Avalonia;
using Avalonia.Controls;
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
        ViewModel.EnrolledSubjects = ViewModel.StudentSubjects.FindAll(sub => sub.StudentsEnrolled.Contains(currentStudent.Id));
    }
}