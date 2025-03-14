using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

public class Teacher : IUser
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public List<Guid> Subjects { get; set; } = [];

    public Teacher(string name, string username, string password)
    {
        Name = name;
        Username = username;
        Password = password;
    }
}