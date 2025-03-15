using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class StudentPageViewModel : ObservableObject
{
    private Student currentStudent;

    [ObservableProperty]
    public List<Subject> _enrolledSubjects = [];

    private List<Subject> StudentSubjects = [];
    private List<Teacher> Teachers = [];
    public StudentPageViewModel()
    {
        // Parameterless constructor for Avalonia
    }
    public StudentPageViewModel(Student student)
    {
        currentStudent = student;
        using (StreamReader sr = new("subjects.json"))
            {
                StudentSubjects = JsonSerializer.Deserialize<List<Subject>>(sr.ReadToEnd())?? [];
            }
        using (StreamReader sr = new("teachers.json"))
            {
                Teachers = JsonSerializer.Deserialize<List<Teacher>>(sr.ReadToEnd())?? [];
            }
        EnrolledSubjects = StudentSubjects.FindAll(sub => sub.StudentsEnrolled.Contains(currentStudent.Id));
        Teachers = Teachers.FindAll(teach => EnrolledSubjects.Exists(sub => sub.TeacherId == teach.Id));
    }
}
