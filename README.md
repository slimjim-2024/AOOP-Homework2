# AOOP-Homework2

## The Requiments

### Core Data Models

• Student class with id, name, username, password, enrolledSubjects.
• Teacher class with id, name, username, password, subjects.
• Subject class with id, name, description, teacherId, studentsEnrolled.


### Login System

• Role-based authentication for Students and Teachers


### Student Functionality

• View available subjects
• View enrolled subjects
• View subject's details (Name, teacher, description etc.)
• Enroll in available subjects
• Drop from enrolled subjects


### Teacher Functionality

• View own subjects
• Create new subjects
• Delete own subjects
• Edit own subject's details


### Data Persistence

• Data is stored in JSON files:
  - `students.json`
  - `teachers.json`
  - `subjects.json`

• Automatically loaded on start and saved on exit.


### UI Components

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
   git clone https://github.com/slimjim-2024/AOOP-Homework2.git

2. Build the project:
• dotnet build

3. Run the application:
• dotnet run

IMPORTANT!
JSON data files must be copied into the same folder as the executable.
These JSON files are found in the JSONFiles folder.

Student and teacher test users both have the same user and paswords:
Username: 1234
Password: 1234
