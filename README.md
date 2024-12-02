# **Recipe and Meal Planning Management System**

## **Task to be completed**
 - Match all the models with all the table columns writing the maxlengths and other validations
 - Update db command (which comes after migration command)
 - Check endpoints, e.g. customer endpoint isn't there
 - Fix errors

## **Project Overview**  
A web-based application that helps users plan meals, create recipes, track nutrition, and manage shopping lists. Features include user authentication, role-based access control (RBAC), recipe management, meal planning, and analytics.

---

## **Tech Stack**
- **Backend:** .NET 8 (C#)  
- **Frontend:** Angular 17+  
- **Database:** SQL Server 2022  
- **Authentication:** JWT  

---

## **Features**
1. **User Authentication & RBAC**  
   - Secure login for Admin, Chef, Nutritionist, Customer, and Meal Planner.  
   - Role-specific permissions.  
   - Only admin can register admins

2. **Recipe Management**  
   - Create, update, and manage recipes with categories and dietary preferences.  

3. **Meal Planning**  
   - Personalized meal plans with scheduling and nutritional tracking.  

4. **Shopping List Management**  
   - Generate and manage shopping lists based on meal plans.  

5. **Analytics & Reporting**  
   - Insights on recipe popularity, meal adherence, and grocery spending.

---

## **Setup Instructions**
1. **Clone the Repository**
   ```bash
   git clone <repository_url>
   cd MEALPLANNERAPI
   ```

2. **Database Configuration**  
   Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Your_Connection_String_Here"
   }
   ```

3. **Install Dependencies**
   ```bash
   dotnet restore
   ```

4. **Run Migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

---

## **API Endpoints**
![image](https://github.com/user-attachments/assets/9da8b9ac-cde0-4b43-a0dd-1a1bbdf16c27)
![image](https://github.com/user-attachments/assets/ed38391d-83a2-4ff3-937f-ae293d592b4c)

### **Authentication**  
| Endpoint               | Method | Description                         |
|------------------------|--------|-------------------------------------|
| `/api/auth/login`      | POST   | User login with JWT generation      |
| `/api/auth/register`   | POST   | Register a new user (Admin-only)    |
| `/api/auth/logout`     | POST   | User logout                         |

---

### **User Management**  
| Endpoint               | Method | Description                         |
|------------------------|--------|-------------------------------------|
| `/api/users`           | GET    | Get all users (Admin-only)          |
| `/api/users/{id}`      | GET    | Get user details by ID              |
| `/api/users/{id}`      | PUT    | Update user details (Admin-only)    |
| `/api/users/{id}`      | DELETE | Delete user (Admin-only)            |

---

### **Recipes**  
| Endpoint               | Method | Description                         |
|------------------------|--------|-------------------------------------|
| `/api/recipes`         | GET    | Get all recipes                     |
| `/api/recipes/{id}`    | GET    | Get a recipe by ID                  |
| `/api/recipes`         | POST   | Create a new recipe (Chef/Nutritionist) |
| `/api/recipes/{id}`    | PUT    | Update a recipe (Chef/Nutritionist) |
| `/api/recipes/{id}`    | DELETE | Delete a recipe (Chef/Nutritionist) |

---

### **Meal Planning**  
| Endpoint                   | Method | Description                               |
|----------------------------|--------|-------------------------------------------|
| `/api/mealplans`           | GET    | Get all meal plans for the logged-in user |
| `/api/mealplans/{id}`      | GET    | Get a specific meal plan by ID            |
| `/api/mealplans`           | POST   | Create a new meal plan                    |
| `/api/mealplans/{id}`      | PUT    | Update an existing meal plan              |
| `/api/mealplans/{id}`      | DELETE | Delete a meal plan                        |

---

### **Shopping List**  
| Endpoint                       | Method | Description                         |
|--------------------------------|--------|-------------------------------------|
| `/api/shoppinglists`           | GET    | Get all shopping lists              |
| `/api/shoppinglists/{id}`      | GET    | Get a shopping list by ID           |
| `/api/shoppinglists`           | POST   | Generate a shopping list for a meal plan |
| `/api/shoppinglists/{id}`      | PUT    | Update shopping list item status    |
| `/api/shoppinglists/{id}`      | DELETE | Delete a shopping list              |

---

### **Reviews**  
| Endpoint               | Method | Description                         |
|------------------------|--------|-------------------------------------|
| `/api/reviews`         | GET    | Get all reviews for a recipe        |
| `/api/reviews`         | POST   | Add a new review for a recipe       |
| `/api/reviews/{id}`    | GET    | Get review by Id                    |
| `/api/reviews/{id}`    | PUT    | Update a review                     |
| `/api/reviews/{id}`    | DELETE | Delete a review                     |

---

### **Subscriptions**  
| Endpoint                   | Method | Description                         |
|----------------------------|--------|-------------------------------------|
| `/api/subscriptions`       | GET    | Get all subscriptions for a user    |
| `/api/subscriptions/{id}`  | POST   | Create a new subscription           |
| `/api/subscriptions/{id}`  | PUT    | Update subscription details         |
| `/api/subscriptions/{id}`  | DELETE | Cancel a subscription               |

---

## **Frontend Integration**  
- Connect Angular frontend to the backend using the base URL:  
  `https://localhost:<port>/api/`

---

## **Additional Notes**
- Use Swagger (`/swagger`) for testing APIs.  
- Add CORS policies in `Program.cs` for external integrations.

---
