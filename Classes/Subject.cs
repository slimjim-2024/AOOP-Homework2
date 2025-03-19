using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AOOP_Homework2;

public class Subject
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Guid TeacherId { get; set; }
    [JsonIgnore]
    public string? TeacherName { get; set; } = "Unknown Teacher";
    public List<Guid> StudentsEnrolled { get; set; } = [];

    public Subject(string name, string description, Guid teacherId)
    {
        Name = name;
        Description = description;
        TeacherId = teacherId;
    }
}