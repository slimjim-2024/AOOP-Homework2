using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class StudentPageViewModel : ObservableObject
{
    private Student currentStudent;

    [ObservableProperty]
    private string _studentName = "";
    [ObservableProperty]
    private string _studentId = "";
    [ObservableProperty]
    private SubjectDisplay _selectedSubject;

    // [ObservableProperty]
    // public List<Subject> _enrolledSubjects = [];
    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _enrolledSubjects = [];

    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _availableSubects = [];

    protected internal List<Subject> AllSubjects = [];
    private List<Teacher> Teachers = [];
    public StudentPageViewModel()
    {
        // Parameterless constructor for Avalonia
    }
    public StudentPageViewModel(Student student)
    {
        currentStudent = student;
        AllSubjects = JsonSerializer.Deserialize<List<Subject>>(File.ReadAllText("subjects.json")) ?? [];
        Teachers = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")) ?? [];

        // Get enrolled subjects with teacher names
        EnrolledSubjects =new( AllSubjects
            .Where(s => s.StudentsEnrolled.Contains(currentStudent.Id))
            .Select(s => new SubjectDisplay
            {
                Name = s.Name,
                Description = s.Description,
                TeacherName = Teachers.Find(t => t.Id == s.TeacherId)?.Name ?? "Unknown Teacher",
                Id = s.Id
            }).ToList());
        
    }
}

public class SubjectDisplay
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string TeacherName { get; set; } = "";
    public Guid Id {get;set;} = Guid.Empty;
}
