using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

class Subject
{
    protected internal Guid Id { get; } = Guid.NewGuid();
    protected internal string Name { get; set; } = "";
    protected internal string Description { get; set; } = "";
    protected internal Guid TeacherId { get; }

    protected internal List<Guid> StudentsEnrolled { get; set; } = [];

    public Subject(string name, string description, Guid teacherId)
    {
        Name = name;
        Description = description;
        TeacherId = teacherId;
    }
}