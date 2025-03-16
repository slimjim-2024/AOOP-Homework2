using System;
using System.Collections.Generic;
using System.Data.Common;
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

    private static Guid ValidateLogin(string? username, string? password, AccountType role, ref Student? student)
    {
        // Student test account's username and password is 1234
        
        if (role == AccountType.Teacher)
        {
            List<Teacher> users = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")) ?? [];
            
            // Tries to find match in username and password
            Teacher? teacher = users.Find(
                user => user.Username == username &&
                PasswordManager.VerifyPassword(password, user.HashedPassword)
            );
            // If found
            if (teacher != null)
            {
                return ((IUser)teacher).Id;
            }
            
        }
        else if (role == AccountType.Student)
        {
            List<Student> users = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json")) ?? [];
 
            student = users.Find(
                user => user.Username == username &&
                PasswordManager.VerifyPassword(password, user.HashedPassword)
            );
            if (student != null)
            {
                return ((IUser)student).Id;
            }
        }
        return Guid.Empty;
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var loginVM = (LoginViewModel?)DataContext;
        Student? student = null;
        // Add pre-check that username and password aren't null
        if(ValidateLogin(Username.Text, Password.Text, AccountType.Student, ref student) != Guid.Empty)
        {
            StudentPage studentPage = new StudentPage(student);
            studentPage.Show();
            Close();
        }
        else
        {
            loginVM.OutputFail = "Login failed!";
        }


        // var loginViewModel = (LoginViewModel)DataContext;
        
        // if (loginViewModel.Login())
        // {
        //     MessageBox.Show("Login successful!");
        // }
        // else
        // {
        //     MessageBox.Show("Login failed!");
        // }
        Console.WriteLine("Login button clicked! Username: {0}, Password: {1}", Username.Text, Password.Text);
    }private void TeacherLoginButton_Click(object sender, RoutedEventArgs e)
    {
        // var loginVM = (LoginViewModel?)DataContext;
        // Teacher? teacher = null;
        // // Add pre-check that username and password aren't null
        // if(ValidateLogin(Username.Text, Password.Text, AccountType.Teacher, ref Student) teacher) != Guid.Empty)
        // {
        //     // StudentPage studentPage = new StudentPage();
        //     // studentPage.Show();
        //     Close();
        // }
        // else
        // {
        //     loginVM.OutputFail = "Login failed!";
        // }
        Console.WriteLine("Login button clicked! Username: {0}, Password: {1}", TeacherUsername.Text, TeacherPassword.Text);
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        // var loginViewModel = (LoginViewModel)DataContext;
        
        // if (loginViewModel.Register())
        // {
        //     MessageBox.Show("Registration successful!");
        // }
        // else
        // {
        //     MessageBox.Show("Registration failed!");
        // }

    /*
    Indent when serializing for more readability?:
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(weatherForecast, options);
    */
    }
    private void TeacherRegisterButton_Click(object sender, RoutedEventArgs e)
    {
        // var loginViewModel = (LoginViewModel)DataContext;
        
        // if (loginViewModel.Register())
        // {
        //     MessageBox.Show("Registration successful!");
        // }
        // else
        // {
        //     MessageBox.Show("Registration failed!");
        // }
    }
}