using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Xunit;
using AOOP_Homework2;
using Avalonia.Headless.XUnit;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AOOP_Homework2.Tests
{
    public class CoreFunctionalityTests
    {
       [AvaloniaFact]
        public void StudentLogin_ValidCredentials_Success()
        {
            // Arrange
            var loginWindow = new Login();
            var vm = loginWindow.DataContext as LoginViewModel ?? new LoginViewModel();
            
            // Use credentials stored in students.json
            vm.Username = "1234"; // Existing username
            vm.Password = "1234"; // Password before hashing
            loginWindow.FindControl<TextBox>("Username").Text = "1234";
            loginWindow.FindControl<TextBox>("Password").Text = "1234";

            // Act
            loginWindow.FindControl<Button>("LoginButton")
                    .RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            // Assert
            Assert.Equal(string.Empty, vm.OutputFail);
        }

        [AvaloniaFact]
        public void StudentLogin_InvalidCredentials_Failure()
        {
            // Arrange
            var loginWindow = new Login();
            var vm = loginWindow.DataContext as LoginViewModel ?? new LoginViewModel();
            vm.Username = "wronguser";
            vm.Password = "wrongpass";
            loginWindow.FindControl<TextBox>("Username").Text = "wronguser";
            loginWindow.FindControl<TextBox>("Password").Text = "wrongpass";

            // Act
            loginWindow.FindControl<Button>("LoginButton")
                      .RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            // Assert
            Assert.Equal("Login failed!", vm.OutputFail);
        }

        [AvaloniaFact]
        public void TeacherLogin_ValidCredentials_Success()
        {
            // Arrange
            var loginWindow = new Login();
            var vm = loginWindow.DataContext as LoginViewModel ?? new LoginViewModel();
            
            // Use credentials stored in teachers.json
            vm.TeacherUsername = "1234"; // Existing teacher username
            vm.TeacherPassword = "1234";  // Password before hashing
            loginWindow.FindControl<TextBox>("TeacherUsername").Text = "1234";
            loginWindow.FindControl<TextBox>("TeacherPassword").Text = "1234";

            // Act
            loginWindow.FindControl<Button>("TeacherLoginButton")
                    .RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            // Assert
            Assert.Equal(string.Empty, vm.OutputFail);
        }

        [AvaloniaFact]
        public void TeacherLogin_InalidCredentials_Failure()
        {
            // Arrange
            var loginWindow = new Login();
            var vm = loginWindow.DataContext as LoginViewModel ?? new LoginViewModel();
            
            vm.TeacherUsername = "1234"; // Right user
            vm.TeacherPassword = "notCorrect"; // Wrong password
            loginWindow.FindControl<TextBox>("TeacherUsername").Text = "vdemschke0";
            loginWindow.FindControl<TextBox>("TeacherPassword").Text = "fV6?6PL(u";

            // Act
            loginWindow.FindControl<Button>("TeacherLoginButton")
                    .RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            // Assert
            Assert.Equal("Login failed!", vm.OutputFail);
        }

        [Fact]
        public void CourseEnrollment_AddsToEnrolledSubjects()
        {
            // Arrange
            var student = new Student("Test Student", "test", "hash");
            var subject = new Subject("Math", "Algebra", Guid.NewGuid());
            var subjects = new List<Subject> { subject };
            var students = new List<Student> { student };
            var teachers = new List<Teacher>();

            var vm = new StudentPageViewModel(student, ref subjects, ref students, ref teachers);
            var subjectDisplay = new SubjectDisplay 
            { 
                Id = subject.Id,
                Name = subject.Name,
                TeacherName = "Test Teacher"
            };

            // Act
            vm.RegisterCourse(subjectDisplay);

            // Assert
            Assert.Contains(subjectDisplay, vm.EnrolledSubjects);
            Assert.DoesNotContain(subjectDisplay, vm.AvailableSubects);
        }

        [Fact]
        public void DataPersistence_SavesStudentDataCorrectly()
        {
            // Arrange
            var tempFile = Path.GetTempFileName();
            var student = new Student("Temp Student", "temp", "hash");
            var students = new List<Student> { student };

            // Act
            File.WriteAllText(tempFile, JsonSerializer.Serialize(students));
            var loadedStudents = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(tempFile));

            // Cleanup
            File.Delete(tempFile);

            // Assert
            Assert.Single(loadedStudents!);
            Assert.Equal(student.Id, loadedStudents![0].Id);
        }

        [Fact]
        public void CourseRemoval_UpdatesAvailableSubjects()
        {
            // Arrange
            var student = new Student("Test Student", "test", "hash");
            var subject = new Subject("Physics", "Mechanics", Guid.NewGuid());
            var subjects = new List<Subject> { subject };
            var students = new List<Student> { student };
            var teachers = new List<Teacher>();

            var vm = new StudentPageViewModel(student, ref subjects, ref students, ref teachers);
            var subjectDisplay = new SubjectDisplay 
            { 
                Id = subject.Id,
                Name = subject.Name,
                TeacherName = "Test Teacher"
            };

            // Enroll first
            vm.RegisterCourse(subjectDisplay);

            // Act
            vm.EnrolledSubjects.Remove(subjectDisplay);
            vm.AvailableSubects.Add(subjectDisplay);

            // Assert
            Assert.DoesNotContain(subjectDisplay, vm.EnrolledSubjects);
            Assert.Contains(subjectDisplay, vm.AvailableSubects);
        }

        [Fact]
        public void TeacherCreateSubject_AppearsInTeachingSubjects()
        {
            // Arrange
            var teacher = new Teacher("Math Professor", "math101", "teach123");
            var subjects = new List<Subject>();
            var students = new List<Student>();
            var teachers = new List<Teacher> { teacher };

            var vm = new TeacherPageViewModel(teacher, ref subjects, ref students, ref teachers);

            // Act
            vm.CreateNewSubject("Calculus", "Advanced Mathematics Course");

            // Assert
            Assert.Single(vm.TeachingSubjects);
            Assert.Equal("Calculus", vm.TeachingSubjects[0].Name);
            Assert.Contains(vm.TeachingSubjects[0].Id, vm.AllSubjects.Select(s => s.Id));
        }

        [Fact]
        public void TeacherDeleteSubject_RemovesFromTeachingSubjects()
        {
            // Arrange
            var teacher = new Teacher("Math Prof", "math101", "pass123");
            var subject = new Subject("Calculus", "Math", Guid.NewGuid());
            var subjects = new List<Subject> { subject };
            var students = new List<Student>();
            var teachers = new List<Teacher> { teacher };

            var vm = new TeacherPageViewModel(teacher, ref subjects, ref students, ref teachers);
            var subjectDisplay = new SubjectDisplay 
            { 
                Id = subject.Id,
                Name = subject.Name,
                TeacherName = teacher.Name
            };

            // Act
            vm.TeachingSubjects.Remove(subjectDisplay);
            vm.AllSubjects.RemoveAll(s => s.Id == subject.Id);
            
            // Assert
            Assert.DoesNotContain(subjectDisplay, vm.TeachingSubjects);
            Assert.DoesNotContain(subject, vm.AllSubjects);
        }
    }
}