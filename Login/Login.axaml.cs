using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace AOOP_Homework2;

enum AccountType{
    Student,
    Teacher
}

public partial class Login : Window
{
    public DataDicts DataDicts = new(); // Stores student, teacher and subject data
public Dictionary<Guid, Student> Students { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Student>>(File.ReadAllText("students.json")) ?? [];
    public Login()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }

    // Student Login
    private void StudentLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = (LoginViewModel?)DataContext;

        // Tries to find student with given credentials
        var student = DataDicts.Students.FirstOrDefault(s => s.Value.Username == Username.Text && PasswordManager.VerifyPassword(Password.Text, s.Value.HashedPassword));
        // If found
        if (student.Key != Guid.Empty)
        {
            var studentPage = new StudentPage(student, DataDicts);
            studentPage.Show();
            Close();
        }
        else
        {
            loginVM.OutputFail = "Login failed!";
        }

        Debug.WriteLine("Login button clicked! Username: {0}, Password: {1}", Username.Text, Password.Text);
    }

    // Teacher Login
    private void TeacherLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = (LoginViewModel?)DataContext;
            List<Teacher> users = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")) ?? [];
            
        Debug.WriteLine("Login button clicked! Username: {0}, Password: {1}", TeacherUsername.Text, TeacherPassword.Text);
    }
}