using System;

namespace AOOP_Homework2;

interface IUser
{
    Guid Id { get; } // Globally unique identifier
    string Name { get; set; }
    string Username { get; set; }
    string Password { get; set; }

    /*
    // For hashing later
    void HashPassword()
    {}
    void VerifyPassword()
    {}
    */
}