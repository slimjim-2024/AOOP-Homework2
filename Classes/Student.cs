
using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

public class Student : IUser
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }

    public List<Guid> EnrolledSubjects { get; set; } = [];

    public Student(string name, string username, string hashedPassword)
    {
        Name = name;
        Username = username;
        HashedPassword = hashedPassword;
    }
}