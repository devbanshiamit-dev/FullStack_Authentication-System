# 🔐 Full Stack Authentication System (ASP.NET Core Web API)

## 📌 Project Overview

This project is an ASP.NET Core Web API-based authentication system. It currently focuses on building a clean backend structure using the Repository Pattern and managing users and refresh tokens.

The project is in an early development stage and will be extended step by step to include full JWT authentication and advanced security features.

---

## 🛠️ Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* C#
* ILogger (Built-in Logging)

---

## 📂 Current Architecture

Controller
   ↓
Service            
   ↓
Repository
   ↓
DbContext
   ↓
SQL Server
```

---

## 📦 Implemented Features (Current Stage)

### 👤 User Management (Repository Layer)

* Get user by email
* Get user by ID
* Add new user

### 🔑 Refresh Token Management

* Add refresh token
* Get refresh token by token string
* Get all refresh tokens for a user
* Remove a specific refresh token
* Remove all refresh tokens of a user

---

## 📁 Repository Structure

```text id="d4e5f6"
Auth Repository
 ├── User-related queries
 ├── Refresh token queries
 ├── Create operations
 ├── Delete operations
 └── Logging using ILogger
```

---

## ⚙️ Project Status

🚧 Currently under development
🔜 Upcoming features:

* JWT Authentication (Access & Refresh Tokens)
* Login & Registration endpoints
* Auth Service layer implementation
* Password hashing (BCrypt)
* Global exception handling middleware

---

## 🎯 Purpose of This Project

The goal of this project is to:

* Understand clean backend architecture
* Practice Repository Pattern in real scenarios
* Build a real-world authentication system step by step
* Improve ASP.NET Core backend development skills

---

## 📌 Note

This project is continuously evolving. Features will be added and improved as learning progresses.
