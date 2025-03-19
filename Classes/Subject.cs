using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

 public class Subject
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Guid TeacherId { get; set; }
    public List<Guid> StudentsEnrolled { get; set; } = [];

    public Subject(string name, string description, Guid teacherId)
    {
        Name = name;
        Description = description;
        TeacherId = teacherId;
    }
}