
using System;
using System.Collections.Generic;

namespace AOOP_Homework2;
public class Student : IUser
{
    public Guid Id { get; set;} = Guid.NewGuid();
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public List<Guid> EnrolledSubjects { get; set; } = [];

    public Student(string name, string username, string password)
    {
        Name = name;
        Username = username;
        Password = password;
    }

    public static explicit operator Student(Teacher? v)
    {
        throw new NotImplementedException();
    }
}