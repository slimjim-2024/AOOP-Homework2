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

    private LoginViewModel loginViewModel = new LoginViewModel();

    public Login()
    {
        InitializeComponent();
        DataContext = loginViewModel;

    }
    private const int keySize = 64;
    private const int iterations = 350000;
    private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

    private Guid ValidateLogin(string username, string password, AccountType role)
    {
        string path = role switch
        {
            AccountType.Teacher => "teacher.json",
            AccountType.Student => "student.json",
            _ => ""
        };

        /*
        Gets list of users by deserializing JSON file
        When deserializing,
        any JSON properties that aren't represented in the class are ignored by default,
        so this method can be used for accounts with different roles
        */
        List<IUser> users = JsonSerializer.Deserialize<List<IUser>>(File.ReadAllText(path)) ?? [];

        // Try to find match
        IUser? user = users.Find(user => user.Username == username && user.Password == password);
        if (user != null) return user.Id;
        return Guid.Empty;
    }

    // Try to avoid duplication in teacher and student login code
    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        // Add pre-check that username and password aren't null
        if(ValidateLogin(Username.Text, Password.Text, AccountType.Student) != Guid.Empty)
        {
            StudentPage studentPage = new StudentPage();
            studentPage.Show();
            Close();
        }
        else
        {
            loginViewModel.OutputFail = "Login failed!";
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
        // var loginViewModel = (LoginViewModel)DataContext;
        
        // if (loginViewModel.Login())
        // {
        //     MessageBox.Show("Login successful!");
        // }
        // else
        // {
        //     MessageBox.Show("Login failed!");
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