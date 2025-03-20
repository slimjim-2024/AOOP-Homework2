using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
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
    public List<Student> Students;
    public List<Teacher> Teachers;
    public List<Subject> Subjects;
    public Login()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
        Students = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json")) ?? [];
        Teachers = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")) ?? [];
        Subjects = JsonSerializer.Deserialize<List<Subject>>(File.ReadAllText("subjects.json")) ?? [];
    }

    private void StudentLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = (LoginViewModel?)DataContext;
 
            Student? student = Students.Find(
                user => user.Username == Username.Text &&
                PasswordManager.VerifyPassword(Password.Text, user.HashedPassword)
            );
            if (student != null)
            {
                StudentPage studentPage = new(student, ref Subjects, ref Students, ref Teachers);
                studentPage.Show();
                Close();
            }
            else
            {
                loginVM.OutputFail = "Login failed!";
            }

        Debug.WriteLine("Login button clicked! Username: {0}, Password: {1}", Username.Text, Password.Text);
    }private void TeacherLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = (LoginViewModel?)DataContext;            
            // Tries to find match in username and password
            Teacher? teacher = Teachers.Find(
                user => user.Username == TeacherUsername.Text &&
                PasswordManager.VerifyPassword(TeacherPassword.Text, user.HashedPassword)
            );
            // If found
            if (teacher != null)
            {
                TeacherPage teacherPage = new(teacher, ref Subjects, ref Students, ref Teachers);
                teacherPage.Show();
                Close();

            }
        Debug.WriteLine("Login button clicked! Username: {0}, Password: {1}", TeacherUsername.Text, TeacherPassword.Text);
    }
}