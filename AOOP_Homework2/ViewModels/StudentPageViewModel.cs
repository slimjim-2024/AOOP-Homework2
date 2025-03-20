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
    protected internal Student currentStudent;
    protected internal int currentStudentIndex;
    

    [ObservableProperty]
    private string _studentName = "";
    [ObservableProperty]
    private string _studentId = "";
    [ObservableProperty]
    private SubjectDisplay _selectedSubject = new();

    // [ObservableProperty]
    // public List<Subject> _enrolledSubjects = [];
    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _enrolledSubjects = [];

    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _availableSubects = [];

    protected internal List<Subject> AllSubjects = [];
    protected internal List<Teacher> Teachers = [];
    protected internal List<Student> Students = [];
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
    public StudentPageViewModel(Student student, ref List<Subject> subjects, ref List<Student> students, ref List<Teacher> teachers)
    {
        currentStudent = student;
        AllSubjects = subjects;
        Teachers = teachers;
        Students = students;
        currentStudentIndex = students.FindIndex(s => s.Id == student.Id);
        

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
        
        AvailableSubects = new(AllSubjects
            .Where(s => !s.StudentsEnrolled.Contains(currentStudent.Id))
            .Select(s => new SubjectDisplay
            {
                Name = s.Name,
                Description = s.Description,
                TeacherName = Teachers.Find(t => t.Id == s.TeacherId)?.Name ?? "Unknown Teacher",
                Id = s.Id
            }).ToList());
        
        Students[currentStudentIndex].EnrolledSubjects = EnrolledSubjects.Select(s => s.Id).ToList();
        
    }

    protected internal void SaveAll()
    {
        File.WriteAllText("subjects.json", JsonSerializer.Serialize(AllSubjects, new JsonSerializerOptions {WriteIndented = true}));
        File.WriteAllText("teachers.json", JsonSerializer.Serialize(Teachers, new JsonSerializerOptions {WriteIndented = true}));
        File.WriteAllText("students.json", JsonSerializer.Serialize(Students, new JsonSerializerOptions {WriteIndented = true}));
    }

    public void RegisterCourse(SubjectDisplay subject)
    {
        EnrolledSubjects.Add(subject);
        AvailableSubects.Remove(subject);
        AllSubjects.Find(s => s.Id == subject.Id)?.StudentsEnrolled.Add(currentStudent.Id);
        Students[currentStudentIndex].EnrolledSubjects.Add(subject.Id);
    }

}

public class SubjectDisplay
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string TeacherName { get; set; } = "";
    public Guid Id {get;set;} = Guid.Empty;
}
