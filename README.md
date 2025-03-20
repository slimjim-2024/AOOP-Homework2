# AOOP-Homework2

# The Requiments

Core Data Models:
• Student class with id, name, username, password, enrolledSubjects.
• Teacher class with id, name, username, password, subjects.
• Subject class with id, name, description, teacherId, studentsEnrolled.

Login System
• Role-based authentication for Students and Teachers

Student Functionality:
• View available subjects
• View enrolled subjects
• View subject's details (Name, teacher, description etc.)
• Enroll in available subjects
• Drop from enrolled subjects

Student Functionalityt:
• View available subjects
• View enrolled subjects
• View subject's details (Name, teacher, description etc.)
• Enroll in available subjects
• Drop from enrolled subjects

Teacher Functionalityr:
• View subjects they teach
• Create a new subjects
• Edit subject's details
• Delete their subject

Data Persistence
• Automatic save/load from JSON files:
  - `students.json`
  - `teachers.json`
  - `subjects.json`
• Save/load data to/from data.json on app start/exit.

UI Components
• Login screen.
• Student dashboard with tabs for available/enrolled subjects.
• Teacher dashboard with "My Subjects" list and buttons.
• Pop-up forms for creating/editing subjects.

## Getting Started

### Prerequisites
- .NET 7.0 SDK or newer
- Avalonia UI framework

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/slimjim-2024/AOOP-Homework2.git cd AOOP-Homework2

Build the project:
• dotnet build

Run the application:
• dotnet run

easy acess to check out the app: 
a student username: 1234
a student pasword: 1234

a teacher username: 1234
a teacher pasword: 1234