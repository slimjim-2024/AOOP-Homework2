using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Tmds.DBus.Protocol;

namespace AOOP_Homework2;

public partial class Login : Window
{
    public Login()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
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