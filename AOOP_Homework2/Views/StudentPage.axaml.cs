using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2;

public partial class StudentPage : Window
{
    StudentPageViewModel ViewModel;
    int currentStudentIndex;
    Student currentStudent;
    public StudentPage(Student student)
    {
        currentStudent = student;
        InitializeComponent();
        DataContext = new StudentPageViewModel(currentStudent);
        ViewModel = (StudentPageViewModel)DataContext;
        ViewModel.StudentName = currentStudent.Name;
        ViewModel.StudentId = currentStudent.Id.ToString();
        Closing += (sender, e) => { ViewModel.SaveAll();};
        // ViewModel.EnrolledSubjects = ViewModel.EnrolledSubjects.FindAll(sub => sub..Contains(currentStudent.Id));
    }
    public StudentPage(Student student, ref List<Subject> subjects, ref List<Student> students, ref List<Teacher> teachers)
    {
        currentStudent = student;
        InitializeComponent();
        currentStudentIndex = students.FindIndex(s => s.Id == student.Id);
        DataContext = new StudentPageViewModel(currentStudent, ref subjects, ref students, ref teachers);
        ViewModel = (StudentPageViewModel)DataContext;
        ViewModel.StudentName = currentStudent.Name;
        ViewModel.StudentId = currentStudent.Id.ToString();
        this.Closing += (sender, e) => {ViewModel.SaveAll();};
        // ViewModel.EnrolledSubjects = ViewModel.EnrolledSubjects.FindAll(sub => sub..Contains(currentStudent.Id));
    }

    private void Unenroll_button(object? sender, RoutedEventArgs e)
    {
        if (ViewModel.SelectedSubject == null) return;
        SubjectDisplay subject = ViewModel.SelectedSubject;
        ViewModel.AvailableSubects.Add(subject);
        ViewModel.EnrolledSubjects.Remove(subject);
        ViewModel.AllSubjects.Find(s => s.Id == subject.Id).StudentsEnrolled.Remove(currentStudent.Id);
        ViewModel.Students[currentStudentIndex].EnrolledSubjects.Remove(subject.Id);
    }
    private void Enroll_button(object? sender, RoutedEventArgs e)
    {
        SubjectSelect selectionDialog = new(ref ViewModel);
        selectionDialog.Show();
    }
}