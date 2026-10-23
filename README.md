<div align="center">
  <h1>🎓 Campus One Digital Academy Management Platform</h1>
  <p><b>Enterprise System Architecture & Management Platform</b></p>
  <p>An enterprise-grade desktop solution engineered to streamline administrative workflows, student record maintenance, and operational analytics.</p>
</div>

<br>

<table align="center">
  <tr>
    <td align="center" width="33%">
      <h3>🛠️ Framework</h3>
      <p>C# WinForms</p>
    </td>
    <td align="center" width="33%">
      <h3>🗄️ Database</h3>
      <p>Microsoft SQL Server</p>
    </td>
    <td align="center" width="33%">
      <h3>🛡️ Security</h3>
      <p>Parameterized Queries</p>
    </td>
  </tr>
</table>

<br>

<h2>🚀 System Overview</h2>
<p>This technical specification outlines the underlying architecture, data operations, and user interaction layers across three key operational modules:</p>

<details open>
  <summary><b>🔐 1. Authentication Module</b></summary>
  <ul>
    <li>Ensures role-based access control and administrative session security.</li>
    <li>Validates user inputs against system credentials (Username: Admin, Password: Campusone@123) prior to granting system privileges.</li>
    <li>Clears active input fields on demand and resets input focus directly to the username field for streamlined re-entry.</li>
    <li>Prompts the user with a confirmation dialog before terminating the active application process.</li>
    <li>Intercepts unauthenticated requests and restricts system features behind authentication checks.</li>
    <li>Displays explicit alert dialogs detailing invalid login credentials without exposing internal system details.</li>
    <li>Instantiates and displays the Dashboard Form upon successful credential verification while concealing the login dialog.</li>
    <li>Manages window visibility transitions cleanly to maintain a seamless user experience during navigation.</li>
  </ul>
</details>

<details open>
  <summary><b>📊 2. Dashboard & Analytics Module</b></summary>
  <ul>
    <li>Provides centralized operational metrics, data aggregation, and live dataset searching.</li>
    <li>Establishes database connectivity via SqlConnection, runs aggregate operations (COUNT(*)) to calculate total registered metrics, and feeds data grids using standard data adapter bindings.</li>
    <li>Provides real-time dynamic filtering by evaluating parameter selection categories (Reg No, Names, Contact Info, NIC).</li>
    <li>Constructs safe parameterized queries with wildcards to render instant dataset views.</li>
    <li>Controls interface flow between student registration forms and session termination logic.</li>
    <li>Protects search and retrieval operations from SQL injection using strictly parameterized queries.</li>
    <li>Ensures database connections are safely managed and closed in exception blocks to avoid leakages.</li>
  </ul>
</details>

<details open>
  <summary><b>📝 3. Student Registration Module</b></summary>
  <ul>
    <li>Handles full CRUD lifecycle management for student records with synchronized validation.</li>
    <li>Fetches existing registration IDs (regNo) on initialization to populate choice drop-downs dynamically.</li>
    <li>Triggers on selection change to query full student details using parameterized queries, binding retrieved records directly to form fields, date pickers, and radio controls.</li>
    <li>Gathers input fields, resolves option controls, and executes parameterized SQL INSERT queries to persist new entries safely.</li>
    <li>Maps updated form entries onto a target student key via parameterized SQL UPDATE queries.</li>
    <li>Prompts user for deletion confirmation before executing an explicit parameterized SQL DELETE against the primary key.</li>
    <li>Provides unified clearing mechanisms to reset all control values, date parameters, and radio inputs back to defaults.</li>
    <li>Validates type requirements and input formatting prior to database execution.</li>
    <li>Employs try-catch error handling to safely notify users and reset connection states upon failures.</li>
  </ul>
</details>

<hr>

<h2>⚙️ Database Configuration</h2>
<p>The application relies on Microsoft SQL Server for data persistence. Configure your local server with the following connection string:</p>
<pre><code>Data Source=localhost\SQLEXPRESS; Initial Catalog=Student; Integrated Security=True; Encrypt=True; TrustServerCertificate=True</code></pre>

<br>

<div align="center">
  <i>Developed to deliver high-performance data processing, safe parameterized database interactions, and an intuitive user interface tailored for academic management.</i>
</div>
