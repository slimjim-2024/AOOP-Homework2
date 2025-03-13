using System;

namespace AOOP_Homework2;

interface IUser
{
    private protected Guid Id { get; } // Unique identifier
    private protected string Name { get; set; }
    private protected string Username { get; set; }
    private protected string Password { get; set; }
    // Subjects, Enrolled Subjects in teacher/student
}