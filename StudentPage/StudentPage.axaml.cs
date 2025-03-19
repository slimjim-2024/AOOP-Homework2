using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2;

public partial class StudentPage : Window
{
    StudentPageViewModel ViewModel;
    Student Student;
    Guid Id;

    //
    public StudentPage(KeyValuePair<Guid, Student> student, DataDicts dataDicts)
    {
        InitializeComponent();

        Student = student.Value;
        Id = student.Key;

        DataContext = new StudentPageViewModel(Student, Id, dataDicts);
        ViewModel = (StudentPageViewModel)DataContext;
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