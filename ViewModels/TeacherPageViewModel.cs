using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class TeacherPageViewModel : ObservableObject
{
    protected internal Teacher currentTeacher;
    protected internal int currentTeacherIndex;
    
    [ObservableProperty]
    private string _teacherName = "";
    
    [ObservableProperty]
    private SubjectDisplay _selectedSubject;
    
    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _teachingSubjects = [];
    
    [ObservableProperty]
    private ObservableCollection<StudentDisplay> _enrolledStudents = [];

    protected internal List<Subject> AllSubjects = [];
    protected internal List<Teacher> Teachers = [];
    protected internal List<Student> Students = [];

    public TeacherPageViewModel() { }

    public TeacherPageViewModel(Teacher teacher)
    {
        currentTeacher = teacher;
        AllSubjects = JsonSerializer.Deserialize<List<Subject>>(File.ReadAllText("subjects.json")) ?? [];
        Students = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json")) ?? [];
        Teachers = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")) ?? [];
        LoadSubjects();
    }

    public TeacherPageViewModel(Teacher teacher, ref List<Subject> subjects, ref List<Student> students, ref List<Teacher> teachers)
    {
        currentTeacher = teacher;
        AllSubjects = subjects;
        Students = students;
        Teachers = teachers;
        currentTeacherIndex = teachers.FindIndex(t => t.Id == teacher.Id);
        LoadSubjects();
    }

    private void LoadSubjects()
    {
        TeachingSubjects = new(AllSubjects
            .Where(s => Teachers[currentTeacherIndex].Subjects.Contains(s.Id))
            .Select(s => new SubjectDisplay
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                TeacherName = currentTeacher.Name
            }).ToList());
    }

    protected internal void SaveAll()
    {
        File.WriteAllText("subjects.json", JsonSerializer.Serialize(AllSubjects, new JsonSerializerOptions { WriteIndented = true }));
        File.WriteAllText("teachers.json", JsonSerializer.Serialize(Teachers, new JsonSerializerOptions { WriteIndented = true }));
        File.WriteAllText("students.json", JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true }));
    }

    public void CreateNewSubject(string name, string description)
    {
        var newSubject = new Subject(name, description, currentTeacher.Id)
        {
            Id = Guid.NewGuid(),
            StudentsEnrolled = new List<Guid>()
        };

        AllSubjects.Add(newSubject);
        currentTeacher.Subjects.Add(newSubject.Id);
        Teachers[currentTeacherIndex].Subjects.Add(newSubject.Id);
        TeachingSubjects.Add(new SubjectDisplay
        {
            Id = newSubject.Id,
            Name = newSubject.Name,
            Description = newSubject.Description,
            TeacherName = currentTeacher.Name
        });
    }

    public void UpdateEnrolledStudents()
    {
        if (SelectedSubject == null) return;
        EnrolledStudents = new(Students
            .Where(s => AllSubjects
                .Find(sub => sub.Id == SelectedSubject.Id)?
                .StudentsEnrolled.Contains(s.Id) ?? false)
            .Select(s => new StudentDisplay
            {
                Name = s.Name,
                Id = s.Id
            }).ToList());
    }
}

public class StudentDisplay
{
    public string Name { get; set; } = "";
    public Guid Id { get; set; } = Guid.Empty;
}