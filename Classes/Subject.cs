using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

class Subject
{
    private protected Guid Id { get; } = Guid.NewGuid();
    private protected string Name { get; set; }
    private protected string Description { get; set; }
    private protected Guid TeacherId { get; }
    private protected List<Guid> StudentsEnrolled { get; set; } = [];
}