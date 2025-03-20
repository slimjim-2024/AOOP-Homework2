using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        Id = Guid.NewGuid(); // Add ID initialization
        Name = name;
        Username = username;
        HashedPassword = hashedPassword;
    }
}