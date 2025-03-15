using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2;

public partial class StudentPage : Window
{
    Student currentStudent;
    public StudentPage(Student student)
    {
        currentStudent = student;
        DataContext = new StudentPageViewModel(currentStudent);
        InitializeComponent();
    }
}