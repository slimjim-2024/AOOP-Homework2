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
    private Student Student;
    private Dictionary<Guid, Teacher> Teachers { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Teacher>>(File.ReadAllText("teachers.json")) ?? [];
    private Dictionary<Guid, Student> Students { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Student>>(File.ReadAllText("students.json")) ?? [];
    private Dictionary<Guid, Subject> Subjects { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Subject>>(File.ReadAllText("subjects.json")) ?? [];
    
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
    public StudentPageViewModel(Student student, Guid studentId, DataDicts dataDicts)
    {
        Student = student;

        StudentName = student.Name;
        StudentId = studentId.ToString();
        
        Subjects = dataDicts.Subjects;
        Teachers = dataDicts.Teachers;
        
        SetSubjectCollections();
    }
    
    // Adds subjects to EnrolledSubjects and AvailableSubjects for display
    private void SetSubjectCollections()
    {
        // Gets subjects in currentStudent.EnrolledSubjects and adds them to EnrolledSubjects
        foreach (Guid id in Student.EnrolledSubjects)
        {
            if (Subjects.TryGetValue(id, out Subject? subject)) {
                EnrolledSubjects.Add(CompleteSubject(subject));
                // 
                Subjects.Remove(id);
            }
        }
        // Adds other subjects to AvailableSubjects
        foreach (KeyValuePair<Guid, Subject> pair in Subjects)
        {
            AvailableSubjects.Add(CompleteSubject(pair.Value));
        }
    }

    // Adds data needed for subject display not saved in JSON file
    private Subject CompleteSubject(Subject subject)
    {
        // Tries to find subject's teacher in Teachers dict
        if (Teachers.TryGetValue(subject.TeacherId, out Teacher? t))
        {
            subject.TeacherName = t.Name;
        }
        return subject;
    }
}