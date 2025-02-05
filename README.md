# 📋 ASP.NET Core ToDo API with JWT Authentication & SQLite

This project is a RESTful API built with **ASP.NET Core**, **Entity Framework Core**, and **SQLite**. It implements **JWT Authentication** for secure access, managing **Users** and their **Tasks** with a one-to-many relationship.

---

## 🚀 Features

- ✅ User Registration & Authentication (JWT)
- 🔐 Secure Endpoints with Role-Based Authorization
- 📋 CRUD Operations for Users & Tasks
- 📊 SQLite Database with Entity Framework Core
- 🔄 Token-based Authentication

---

## 🏗️ Tech Stack

- **.NET 6+** (ASP.NET Core Web API)
- **Entity Framework Core** (ORM)
- **SQLite** (Database)
- **JWT (JSON Web Tokens)** (Authentication)

---

## ⚙️ Setup Instructions

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/joaodanilo123/TarefasWeb.git
cd TarefasWeb
```

### 2️⃣ Install Dependencies

```bash
dotnet restore
```

### 3️⃣ Update Configuration

In `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  },
  "JwtSettings": {
    "Key": "YourSuperSecretKey12345",
    "Issuer": "YourApp",
    "Audience": "YourAppUsers",
    "ExpiryInMinutes": 60
  }
}
```

### 4️⃣ Run Database Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Run the API

```bash
dotnet run
```

API will be available at:

```
http://localhost:5000/api
```

---

## 🔑 JWT Authentication

1. Login to receive a **JWT Token**.
2. Add the token in the request header:

```
Authorization: Bearer <your_token_here>
```

---

## 🚀 Future Improvements

- Password hashing with BCrypt
- Refresh Token mechanism
- Role-based access control (RBAC)
- API versioning

---

## 📜 License

This project is licensed under the [MIT License](LICENSE).

---

## 👨‍💻 Author

Developed by **João Danilo Zucolotto Diedrich**

