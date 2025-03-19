using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

public class Teacher : IUser
{
    public Guid Id { get; set;}
    public string Name { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }

    public List<Guid> Subjects { get; set; } = [];

    public Teacher(string name, string username, string hashedPassword)
    {
        Name = name;
        Username = username;
        HashedPassword = hashedPassword;
    }
}