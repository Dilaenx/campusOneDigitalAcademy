<div align="center">
  <h1>🎓 Campus One Digital Academy Management Platform</h1>
  <p><b>Enterprise System Architecture & Student Management Solution</b></p>
  <p>An enterprise-grade desktop application engineered to streamline administrative workflows, maintain student records securely, and provide real-time operational analytics.</p>

  <!-- Badges -->
  <img src="https://img.shields.io/badge/Framework-C%23%20WinForms-blue?style=for-the-badge&logo=csharp" alt="C# WinForms" />
  <img src="https://img.shields.io/badge/Database-MS%20SQL%20Server-red?style=for-the-badge&logo=microsoftsqlserver" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Architecture-Enterprise--Grade-success?style=for-the-badge" alt="Enterprise Grade" />
</div>

<br>

## 🚀 System Overview

The **Campus One Digital Academy Management Platform** is designed to provide a seamless, secure, and highly efficient administrative experience. The technical specification outlines the underlying architecture, data operations, and user interaction layers across three core operational modules:

### 🔐 1. Authentication Module
* **Role-Based Access Control:** Ensures administrative session security. Validates user inputs against system credentials (`Username: Admin`, `Password: Campusone@123`) prior to granting system privileges.
* **Streamlined UX:** Clears active input fields on demand and resets input focus directly to the username field for quick re-entry.
* **Graceful Exit:** Prompts the user with a confirmation dialog before terminating the active application process.
* **Security & Encapsulation:** Intercepts unauthenticated requests, restricting system features behind strict authentication checks. Displays explicit alert dialogs for invalid credentials without exposing internal system details.
* **Seamless Transitions:** Instantiates and displays the Dashboard Form upon successful credential verification while cleanly concealing the login dialog to maintain a seamless user experience.

### 📊 2. Dashboard & Analytics Module
* **Centralized Metrics:** Provides real-time operational metrics, data aggregation, and live dataset searching capabilities.
* **Data Aggregation:** Establishes database connectivity via `SqlConnection` and runs aggregate operations (e.g., `COUNT(*)`) to calculate total registered student metrics, feeding data grids using standard data adapter bindings.
* **Dynamic Filtering:** Offers real-time dynamic search filtering by evaluating parameter selection categories (Reg No, First Name, Last Name, Phone Number, NIC).
* **Injection Protection:** Constructs safe parameterized queries utilizing wildcards to render instant dataset views while strictly protecting search and retrieval operations from SQL injection.
* **Resource Management:** Ensures database connections are safely managed and systematically closed within exception blocks to prevent memory and connection leaks.

### 📝 3. Student Registration Module
* **Full CRUD Lifecycle:** Handles complete Create, Read, Update, and Delete lifecycle management for student records with synchronized validation.
* **Dynamic Loading:** Fetches existing registration IDs (`regNo`) upon initialization to dynamically populate selection drop-downs. Triggers queries on selection changes to bind retrieved records directly to form fields, date pickers, and radio controls.
* **Data Persistence:** Gathers input fields, resolves option controls, and executes safe parameterized SQL `INSERT` and `UPDATE` queries to persist new entries or map updates to target student keys.
* **Secure Deletion:** Prompts administrators for confirmation before executing an explicit parameterized SQL `DELETE` against the primary key.
* **State Resetting:** Provides unified clearing mechanisms to reset all control values, date parameters, and radio inputs back to defaults.
* **Robust Error Handling:** Employs comprehensive `try-catch` error handling to safely notify users, validate type requirements/input formatting, and reset connection states upon failures.

---

## ⚙️ Technologies & Frameworks

| Component | Technology | Description |
| :--- | :--- | :--- |
| **Frontend UI** | C# .NET WinForms | Provides a responsive, event-driven desktop interface. |
| **Backend Logic** | C# | Handles data processing, validation, and system routing. |
| **Database** | Microsoft SQL Server | Relational database for persistent data storage. |
| **Security** | Parameterized SQL | Defends against SQL injection vulnerabilities. |

---

## 🗄️ Database Configuration

The application relies on Microsoft SQL Server for secure data persistence. The system utilizes a central database named `Student`, featuring `Credentials` and `Registration` tables. 

Configure your local SQL Server instance using the following connection string:
```csharp
Data Source=localhost\SQLEXPRESS; Initial Catalog=Student; Integrated Security=True; Encrypt=True; TrustServerCertificate=True
```

### Table Structures
* **Credentials:** `Id` (INT, PK), `Username` (NVARCHAR), `Password` (NVARCHAR)
* **Registration:** `regNo` (INT, PK), `firstName`, `lastName`, `dateOfBirth`, `gender`, `address`, `email`, `mobilePhone`, `homePhone`, `parentName`, `nic`, `contactNo`

---

## 💻 Getting Started

### Prerequisites
1. **Visual Studio 2019/2022** (with .NET desktop development workload).
2. **Microsoft SQL Server** (Express edition is sufficient) & **SQL Server Management Studio (SSMS)**.

### Installation & Setup
1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/campus-one-digital-academy.git
   ```
2. **Database Setup:**
   * Open SSMS and create a new database named `Student`.
   * Execute the provided SQL scripts (or manually create the `Credentials` and `Registration` tables based on the schema requirements).
   * Insert a default admin user into the `Credentials` table if tracking dynamic logins, or use the default `Admin` / `Campusone@123` credentials.
3. **Run the Application:**
   * Open the `.sln` file in Visual Studio.
   * Verify the connection string in the codebase aligns with your local SQL server instance name (e.g., `localhost\SQLEXPRESS`).
   * Build and run the project (Press `F5`).

---



<br>

<div align="center">
  <i>Developed to deliver high-performance data processing, safe parameterized database interactions, and an intuitive user interface tailored for academic management.</i>
</div>
