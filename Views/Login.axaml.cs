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
    public Login()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();

    }
    private const int keySize = 64;
    private const int iterations = 350000;
    private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

    private void StudentLoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = (LoginViewModel?)DataContext;
        List<Student> users = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json")) ?? [];
 
            Student? student = users.Find(
                user => user.Username == Username.Text &&
                PasswordManager.VerifyPassword(Password.Text, user.HashedPassword)
            );
            if (student != null)
            {
            StudentPage studentPage = new(student);
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
            List<Teacher> users = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")) ?? [];
            
            // Tries to find match in username and password
            Teacher? teacher = users.Find(
                user => user.Username == Username.Text &&
                PasswordManager.VerifyPassword(Password.Text, user.HashedPassword)
            );
            // If found
            if (teacher != null)
            {
                // TeacherPage teacherPage = new(teacher);
                // teacherPage.Show();
                // Close();

            }
        Debug.WriteLine("Login button clicked! Username: {0}, Password: {1}", TeacherUsername.Text, TeacherPassword.Text);
    }
}