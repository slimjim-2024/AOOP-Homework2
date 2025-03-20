using System;

namespace AOOP_Homework2;

interface IUser
{
    Guid Id { get; } // Globally unique identifier
    string Name { get; set; }
    string Username { get; set; }
    string HashedPassword { get; set; }
    // Might add salt later
    // (string HashedPassword, string Salt) HashPass { get; set; }
}