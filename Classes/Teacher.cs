using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

class Teacher : IUser
{
    Guid IUser.Id { get; } = Guid.NewGuid();
    string IUser.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUser.Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUser.Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    private protected List<Guid> Subjects { get; set; }
}