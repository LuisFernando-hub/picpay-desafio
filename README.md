# 💳 Wallet & Transaction API (.NET 10 Challenge)

This project is a backend challenge inspired by PicPay.  
It implements a **Wallet and Transaction system** using **.NET 10**, following clean architecture principles and best practices.

---

## 🚀 Features

- User Wallet creation  
- Balance management  
- Money transfer between wallets  
- Transaction validation rules  
- Service layer with business logic  
- Repository pattern  
- DTOs and Mappers  
- Enums for domain consistency  
- RESTful API with controllers  
- Dependency Injection  
- Entity Framework Core (MySQL / SQL Server support)

---

## 🏗️ Project Architecture

The project follows a layered architecture:
/Controllers -> API endpoints
/Services -> Business logic
/Repositories -> Data access layer
/Entities -> Domain models
/DTOs -> Data transfer objects
/Mappers -> Object mapping logic
/Enums -> Domain enums
/Infrastructure -> Database and external integrations




This structure keeps the code **modular, testable, and maintainable**.

---

## 🧠 Business Rules

- Users have wallets with balances  
- Transactions validate:
  - Sufficient balance  
  - Sender and receiver wallets exist  
  - Transaction type rules (e.g., User vs Merchant)  
- All operations are handled in the service layer  
- Data persistence is handled via repositories  

---

## 🛠️ Technologies Used

- .NET 10  
- C#  
- Entity Framework Core  
- MySQL / SQL Server  
- REST API  
- Clean Architecture principles  
- Dependency Injection  

---

## ▶️ How to Run the Project

### 1️⃣ Clone the repository

```bash
git clone https://github.com/your-username/picpay-desafio.git
cd picpay-desafio


"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=picpay_simplificado;User=root;Password=root;"
}
