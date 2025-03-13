using System;

namespace AOOP_Homework2;

interface IUser
{
    protected internal Guid Id { get; } // Unique identifier
    protected internal string Name { get; set; }
    protected internal string Username { get; set; }
    protected internal string Password { get; set; }
    // Subjects, Enrolled Subjects in teacher/student
}