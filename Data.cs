using System;
using System.Collections.Generic;

namespace AOOP_Homework2;

    public class Student
    {
        public int Id { get; set; } //student ID
        public string Name { get; set; } //full name of student
        public string Username { get; set; } //username for authentication
        public string Password { get; set; } //password for authentication
        public List<int> EnrolledSubjects { get; set; } = new List<int>(); // List of subject IDs the student is enrolled in
    }

    public class Teacher
    {
        public int Id { get; set; } //teacher ID
        public string Name { get; set; } // Full name of teacher
        public string Username { get; set; } //username for authentication
        public string Password { get; set; } //password for authentication
        public List<int> Subjects { get; set; } = new List<int>(); // List of subject IDs the teacher has created
    }

    public class Subject
    {
        public int Id { get; set; } //subject ID
        public string Name { get; set; } //subject name
        public string Description { get; set; } //Description of the subject
        public int TeacherId { get; set; } // ID of the teacher who created the subject (will display the teacher name)
        public List<int> StudentsEnrolled { get; set; } = new List<int>(); // List of student IDs enrolled in the subject
    }