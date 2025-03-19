using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class StudentPageViewModel : ObservableObject
{
    private Student currentStudent;
    private Dictionary<Guid, Subject> allSubjects = [];
    private Dictionary<Guid, Teacher> teachers = [];

    // Observable Properties
    [ObservableProperty]
    private string _studentName = "";
    [ObservableProperty]
    private string _studentId = "";
    [ObservableProperty]
    private Subject _selectedSubject;
    [ObservableProperty]
    private ObservableCollection<Subject> _enrolledSubjects = [];
    [ObservableProperty]
    private ObservableCollection<Subject> _availableSubjects = [];

    public StudentPageViewModel()
    {
        // Parameterless constructor for Avalonia
    }
    public StudentPageViewModel(Student student)
    {
        currentStudent = student;

        StudentName = currentStudent.Name;
        StudentId = currentStudent.Id.ToString();
        
        teachers = JsonSerializer.Deserialize<Dictionary<Guid, Teacher>>(File.ReadAllText("teachers.json")) ?? [];
        allSubjects = JsonSerializer.Deserialize<Dictionary<Guid, Subject>>(File.ReadAllText("subjects.json")) ?? [];
        
        // Gets subjects in currentStudent.EnrolledSubjects and adds them to EnrolledSubjects
        foreach (Guid id in currentStudent.EnrolledSubjects)
        {
            if (allSubjects.TryGetValue(id, out Subject? subject)) {
                EnrolledSubjects.Add(CompleteSubject(subject));
                allSubjects.Remove(id);
            }
        }
        // Adds other subjects to AvailableSubjects
        foreach (KeyValuePair<Guid, Subject> pair in allSubjects)
        {
            AvailableSubjects.Add(CompleteSubject(pair.Value));
        }
        // foreach (Subject x in AvailableSubjects) Console.WriteLine(x.Name);
    }

    private Subject CompleteSubject(Subject subject)
    {
        // subject.Id = id;

        // Tries to find subject's teacher in Teachers dict
        if (teachers.TryGetValue(subject.TeacherId, out Teacher? t))
        {
            subject.TeacherName = t.Name;
        }
        return subject;
    }
}