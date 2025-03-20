using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AOOP_Homework2;

public partial class Login : Window
{
    public List<Student> Students;
    public List<Teacher> Teachers;
    public List<Subject> Subjects;

    public Login()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
        
        // Load data with validation
        try
        {
            Students = LoadData<List<Student>>("students.json");
            Teachers = LoadData<List<Teacher>>("teachers.json");
            Subjects = LoadData<List<Subject>>("subjects.json");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading data: {ex.Message}");
            throw;
        }
    }

    private T LoadData<T>(string filename)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
        if (!File.Exists(path)) throw new FileNotFoundException($"Missing {filename}");
        
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json) ?? throw new InvalidDataException($"Invalid {filename}");
    }

    private void StudentLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = DataContext as LoginViewModel;
        if (loginVM == null) return;

        var student = Students.Find(user => 
            user.Username == loginVM.Username &&
            PasswordManager.VerifyPassword(loginVM.Password, user.HashedPassword)
        );

        if (student != null)
        {
            var studentPage = new StudentPage(student, ref Subjects, ref Students, ref Teachers);
            studentPage.Show();
            Close();
        }
        else
        {
            loginVM.OutputFail = "Login failed!";
            Debug.WriteLine($"Student login failed: {loginVM.Username}");
        }
    }

    private void TeacherLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = DataContext as LoginViewModel;
        if (loginVM == null) return;

        var teacher = Teachers.Find(user => 
            user.Username == loginVM.TeacherUsername &&
            PasswordManager.VerifyPassword(loginVM.TeacherPassword, user.HashedPassword)
        );

        if (teacher != null)
        {
            var teacherPage = new TeacherPage(teacher, ref Subjects, ref Students, ref Teachers);
            teacherPage.Show();
            Close();
        }
        else
        {
            loginVM.OutputFail = "Login failed!";
            Debug.WriteLine($"Teacher login failed: {loginVM.TeacherUsername}");
        }
    }
}