using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AOOP_Homework2;

// Data bundled in a class
public class DataDicts
{
    public Dictionary<Guid, Teacher> Teachers { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Teacher>>(File.ReadAllText("teachers.json")) ?? [];
    public Dictionary<Guid, Student> Students { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Student>>(File.ReadAllText("students.json")) ?? [];
    public Dictionary<Guid, Subject> Subjects { get; set; } = JsonSerializer.Deserialize<Dictionary<Guid, Subject>>(File.ReadAllText("subjects.json")) ?? [];
}
