using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2;

public partial class TeacherPage : Window
{
    TeacherPageViewModel ViewModel;
    int currentTeacherIndex;
    Teacher currentTeacher;
    
    public TeacherPage(Teacher teacher)
    {
        currentTeacher = teacher;
        InitializeComponent();
        DataContext = new TeacherPageViewModel(currentTeacher);
        ViewModel = (TeacherPageViewModel)DataContext;
        ViewModel.TeacherName = currentTeacher.Name;
        Closing += (sender, e) => { ViewModel.SaveAll(); };
    }

    public TeacherPage(Teacher teacher, ref List<Subject> subjects, ref List<Student> students, ref List<Teacher> teachers)
    {
        currentTeacher = teacher;
        InitializeComponent();
        currentTeacherIndex = teachers.FindIndex(t => t.Id == teacher.Id);
        DataContext = new TeacherPageViewModel(currentTeacher, ref subjects, ref students, ref teachers);
        ViewModel = (TeacherPageViewModel)DataContext;
        ViewModel.TeacherName = currentTeacher.Name;
        Closing += (sender, e) => { ViewModel.SaveAll(); };
    }

    private void CreateSubject_Click(object? sender, RoutedEventArgs e)
    {
        NewSubjectWindow creationDialog = new(ref ViewModel);
        creationDialog.Show();
    }

    private void SaveChanges_Click(object? sender, RoutedEventArgs e)
    {
        if (ViewModel.SelectedSubject == null) return;
        var subjectIndex = ViewModel.AllSubjects.FindIndex(s => s.Id == ViewModel.SelectedSubject.Id);
        if (subjectIndex != -1)
        {
            AllSubjects[subjectIndex].Name = ViewModel.SelectedSubject.Name;
            AllSubjects[subject].Description = ViewModel.SelectedSubject.Description;
        }
    }
}