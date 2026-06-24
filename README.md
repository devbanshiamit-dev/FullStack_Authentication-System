# 🔐 Full Stack Authentication System

A modern full-stack authentication system built with ASP.NET Core Web API and React. The project implements secure JWT-based authentication with Refresh Token Rotation, global exception handling, and a responsive animated frontend.

---

## 🚀 Features

### Backend Features

* User Registration
* User Login
* Password Hashing using BCrypt
* JWT Access Token Authentication
* Refresh Token Authentication
* Refresh Token Rotation
* Authentication Middleware
* Global Exception Handling Middleware
* Repository Pattern Architecture
* Structured Logging with ILogger
* Entity Framework Core Integration

### Frontend Features

* Modern React UI
* Responsive Authentication Pages
* Smooth GSAP Animations
* Axios API Integration
* Login & Registration Forms
* Protected API Communication

---

## 🛠️ Tech Stack

### Backend

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt
* ILogger

### Frontend

* React
* Vite
* Tailwind CSS
* GSAP
* Axios

---

## 🏗️ Architecture

```text
React Client
      ↓
Controllers
      ↓
Services
      ↓
Repositories
      ↓
Entity Framework Core
      ↓
SQL Server
```

---

## 🔑 Authentication Flow

1. User registers with email and password.
2. Password is hashed using BCrypt before storage.
3. User logs in and receives:

   * Access Token
   * Refresh Token
4. Access Token is used for authenticated requests.
5. Refresh Token is stored in the database.
6. When the Access Token expires:

   * Refresh Token is validated.
   * Old Refresh Token is revoked.
   * New Access Token and Refresh Token are generated.
7. The database is updated with the new Refresh Token.

---

## 📡 API Endpoints

### Authentication

```http
POST /api/auth/register
POST /api/auth/login
POST /api/auth/refresh-token
```

---

## 📂 Project Structure

```text
Backend
├── Controllers
├── Services
├── Repositories
├── Middleware
├── Data
├── Models
└── DTOs

Frontend
├── Components
├── Pages
├── Animations
├── Services
└── Assets
```

---

## 🎨 Frontend Experience

The frontend includes smooth page transitions and interactive animations powered by GSAP, creating a modern and engaging user experience for login and registration workflows.

---

## 📈 Future Improvements

* Role-Based Authorization
* Email Verification
* Password Reset Functionality
* Docker Support
* PostgreSQL Support
* CI/CD Pipeline
* Cloud Deployment (Render + Vercel)

---

## 📌 Project Status

🚀 Active Development

This project started as a backend authentication practice project and has evolved into a full-stack authentication system with secure token-based authentication and a modern animated frontend.
