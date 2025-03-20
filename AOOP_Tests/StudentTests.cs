using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AOOP_Homework2;
using System.Text.Json;
using Avalonia.Headless.XUnit;

namespace AOOP_Homework2.Tests
{
    public class StudentTests
    {
        // [Fact]
        // public void EnrollmentTest()
        // {
        //     // Arrange
        //     var student = new Student("Test Student", "teststudent", "hashedpassword");
        //     var subject = new Subject("Test Subject", "Description", Guid.NewGuid());
        //     var subjects = new List<Subject> { subject };
        //     var students = new List<Student> { student };
        //     var teachers = new List<Teacher>();
        //     var viewModel = new StudentPageViewModel(student, ref subjects, ref students, ref teachers);

        //     // Act
        //     var subjectDisplay = new SubjectDisplay
        //     {
        //         Id = subject.Id,
        //         Name = subject.Name,
        //         Description = subject.Description,
        //         TeacherName = "Test Teacher"
        //     };
        //     viewModel.RegisterCourse(subjectDisplay);

        //     // Assert
        //     Assert.Contains(subjectDisplay, viewModel.EnrolledSubjects);
        // }

        // [Fact]
        // public void DropSubjectTest()
        // {
        //     // Arrange
        //     var student = new Student("Test Student", "teststudent", "hashedpassword");
        //     var subject = new Subject("Test Subject", "Description", Guid.NewGuid());
        //     var viewModel = new StudentPageViewModel(student, ref new List<Subject> { subject }, ref new List<Student> { student }, ref new List<Teacher>());
        //     var subjectDisplay = new SubjectDisplay
        //     {
        //         Id = subject.Id,
        //         Name = subject.Name,
        //         Description = subject.Description,
        //         TeacherName = "Test Teacher"
        //     };
        //     viewModel.RegisterCourse(subjectDisplay);

        //     // Act
        //     viewModel.EnrolledSubjects.Remove(subjectDisplay);
        //     viewModel.AvailableSubects.Add(subjectDisplay);

        //     // Assert
        //     Assert.DoesNotContain(subjectDisplay, viewModel.EnrolledSubjects);
        //     Assert.Contains(subjectDisplay, viewModel.AvailableSubects);
        // }

  [AvaloniaFact]
public void Should_Type_Text_Into_TextBox()
{

            // Arrange
            var students = new List<Student>
            {
                new Student("Mitch", "1234", PasswordManager.HashPassword("1234"))
            };
            var teachers = new List<Teacher>
            {
                new Teacher("Test Teacher", "1234", PasswordManager.HashPassword("1234"))
            };
            var loginWindow = new Login();
            var loginViewModel = loginWindow.DataContext as LoginViewModel;

            // Act
            loginViewModel.Username = "1234";
            loginViewModel.Password = "1234";
            var studentLoginResult = ValidateStudentLogin(loginWindow, loginViewModel.Username, loginViewModel.Password);

            loginViewModel.TeacherUsername = "1234";
            loginViewModel.Password = "1234";
            var teacherLoginResult = ValidateTeacherLogin(loginWindow, loginViewModel.Username, loginViewModel.Password);

            // Assert
            Assert.NotEqual(Guid.Empty, studentLoginResult);
            Assert.NotEqual(Guid.Empty, teacherLoginResult);
        }

        private Guid ValidateStudentLogin(Login loginWindow, string username, string password)
        {
            var student = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json"))
            .Find(user => user.Username == username && PasswordManager.VerifyPassword(password, user.HashedPassword));
            return student?.Id ?? Guid.Empty;
        }

        private Guid ValidateTeacherLogin(Login loginWindow, string username, string password)
        {
            var teacher = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("teachers.json")).Find(user => user.Username == username && PasswordManager.VerifyPassword(password, user.HashedPassword));
            return teacher?.Id ?? Guid.Empty;
        }
    }
}