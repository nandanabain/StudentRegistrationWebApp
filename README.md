# 🎓 Student Registration Web Application

A role-based Student Registration Web Application developed using **ASP.NET Core MVC**, **Entity Framework Core**, and **ASP.NET Core Identity**. The application provides secure authentication, authorization, and student/course management features.

---

## 📌 Project Overview

This application allows users to register, log in, and manage student records while implementing Authentication and Role-Based Authorization.

The project includes:

- User Registration & Login
- ASP.NET Core Identity Authentication
- Administrator and Student Roles
- Course Management
- Student Management
- Profile Management
- Authorization using Roles
- SQL Server Database Integration

---

## 🚀 Features

### Authentication
- User Registration
- User Login
- Logout
- Identity Authentication
- Password Hashing

### Authorization
- Administrator Role
- Student Role
- Role-Based Navigation
- Access Denied page for unauthorized users

### Student Module
- Create Student Profile
- View Student Details
- Edit Student Profile
- Delete Student Profile (Admin Only)

### Course Module
- Add Courses
- Edit Courses
- Delete Courses
- View Course Details

### Profile Management
- Manage Account
- Manage Email
- Change Password
- Personal Data

---

## 🛠 Technologies Used

- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core
- SQL Server
- C#
- Razor Views
- Bootstrap 5
- Visual Studio 2022

---

## 🗄 Database

Two databases are used in the application.

### 1. Identity Database

Stores:

- Users
- Roles
- User Roles
- User Claims
- Login Information

### 2. StudentCourse Database

Stores:

- Students
- Courses

---

## 👥 Roles

### Administrator

Permissions:

- View all students
- Create students
- Edit students
- Delete students
- Manage courses
- View all course details

Navigation Menu

- Home
- Privacy
- Courses
- Students

---

### Student

Permissions:

- Register
- Login
- Create Profile
- Edit Own Profile
- View Own Profile
- Manage Account

Restrictions

- Cannot access Students list
- Cannot access Courses
- Cannot Delete Records
- Unauthorized access redirects to Access Denied page

Navigation Menu

- Home
- Privacy
- My Profile

---

## 📂 Project Structure

```
StudentRegistrationWebApp
│
├── Controllers
├── Models
├── Views
├── Data
├── Migrations
├── wwwroot
├── Properties
├── Screenshots
└── README.md
```

---

## 📸 Screenshots

### Home Page

![Home Page](Screenshots/home-page.png)

---

### Registration Page

![Registration](Screenshots/register-page.png)

---

### Login Page

![Login](Screenshots/login-page.png)

---

### Student Home

![Student Home](Screenshots/student-home.png)

---

### My Profile

![My Profile](Screenshots/my-profile.png)

---

### Access Denied

Student users attempting to access administrator pages are redirected to the Access Denied page.

![Access Denied](Screenshots/access-denied.png)

---

### Administrator Dashboard

Administrator navigation showing access to Courses and Students modules.

![Administrator Dashboard](Screenshots/admin-home.png)

---

### Student Management

Administrator can view and manage student records.

![Student Management](Screenshots/students-list.png)

---

### Identity Database

ASP.NET Identity tables used for Authentication and Authorization.

![Identity Database](Screenshots/identity-database.png)

---

### StudentCourse Database

Database containing Students and Courses.

![StudentCourse Database](Screenshots/studentcourse-database.png)

---

## ⚙ Installation

### Clone Repository

```bash
git clone https://github.com/YOUR-USERNAME/StudentRegistrationWebApp.git
```

Open the project in Visual Studio.

---

### Restore Packages

```
Build → Restore NuGet Packages
```

---

### Update Connection Strings

Modify the connection strings inside

```
appsettings.json
```

according to your SQL Server.

---

### Apply Migrations

Open Package Manager Console.

```
Update-Database
```

Run the project.

---

## 🔐 Test Accounts

### Administrator

```
Email:
nandanabain@gmail.com

Password:
********
```

### Student

Register a new account using the Register page.

Every newly registered user is automatically assigned the **Student** role.

---

## 📚 Learning Outcomes

This project helped me learn:

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- Authentication
- Authorization
- Role-Based Access Control
- SQL Server Integration
- CRUD Operations
- Razor Views
- Dependency Injection

---

## 🔮 Future Improvements

- Email Verification
- Forgot Password
- Search Students
- Pagination
- Dashboard Statistics
- Responsive UI Enhancements

---

## 👩‍💻 Author

**Nandana P Bain**

B.Tech Computer Science Engineering (AI & ML)

VIT Bhopal University

GitHub: https://github.com/nandanabain

---

## ⭐ If you like this project

Give this repository a ⭐ on GitHub!
