using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Cryptography;
using System.Text;


namespace AOOP_Homework2;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username = "";
    
    [ObservableProperty]
    private string _password = "";
    [ObservableProperty]
    private string _teacherUsername = "";
    
    [ObservableProperty]
    private string _TeacherPassword = "";

    [ObservableProperty]
    private string _outputFail = String.Empty;
}
