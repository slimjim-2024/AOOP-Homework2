
using System;
using System.Collections.Generic;

namespace AOOP_Homework2;
class Student : IUser
{
    Guid IUser.Id { get; } = Guid.NewGuid();
    string IUser.Name { get; set; }
    string IUser.Username { get; set; }
    string IUser.Password { get; set;}
    protected internal List<int> Subjects { get; set; } = new List<int>();
}