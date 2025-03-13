using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string _username = "";
    
    [ObservableProperty]
    private string _password = "";
}
